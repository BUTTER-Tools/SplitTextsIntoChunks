using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;


namespace SplitTextsIntoChunks
{




    class TextSegmenter
    {

        public Regex RegexSegmenter { get; set; }
        private Regex WhitespaceSplit { get; } = new Regex(@"\s+", RegexOptions.Compiled);



        public List<string> SegmentTokens(string SegmentOption, Dictionary<string, string> SegmentationParameter, string[] raw_text)
        {
            List<string> TokenizedText = raw_text.Where(s => s != string.Empty).ToList();
            //we want to create a string version of the tokenized text just in case they're using RegEx segmentation
            string reconstitutedText = string.Join(" ", raw_text);
            return SegmentIncomingText(SegmentOption, SegmentationParameter, TokenizedText, reconstitutedText);
        }

        public List<string> SegmentStrings(string SegmentOption, Dictionary<string, string> SegmentationParameter, string raw_text)
        {

            List<string> WhiteSpaceTokenizedText = WhitespaceSplit.Split(raw_text).Where(s => s != string.Empty).ToList();
            return SegmentIncomingText(SegmentOption, SegmentationParameter, WhiteSpaceTokenizedText, raw_text);
        }



        public List<string> SegmentIncomingText(string SegmentOption, Dictionary<string, string> SegmentationParameter, List<string> TokenizedText, string StringText)
        {


            
            int NumberOfSegments = 1;
            List<List<string>> Segments = new List<List<string>>();
            List<string> SegmentsToReturn = new List<string>();



            if (SegmentOption == "SegmentationOptionEqualSegments")
            {
                NumberOfSegments = Math.Max(int.Parse(SegmentationParameter["EqualSizeParam"]), 1); 
                Segments = Partition<string>(TokenizedText, NumberOfSegments);
                for (int i = 0; i < Segments.Count; i++) SegmentsToReturn.Add(string.Join(" ", Segments[i]));
            }

            else if (SegmentOption == "SegmentationOptionWordsPerSegment")
            {
                NumberOfSegments = Math.Max((int)System.Math.Ceiling((double)TokenizedText.Count / int.Parse(SegmentationParameter["WordsPerSegmentParam"])), 1);
                Segments = Partition<string>(TokenizedText, NumberOfSegments);
                for (int i = 0; i < Segments.Count; i++) SegmentsToReturn.Add(string.Join(" ", Segments[i]));
            }

            else if (SegmentOption == "SegmentationOptionRegex")
            {
                SegmentsToReturn = RegexSegmenter.Split(StringText).ToList();
            }

            else if (SegmentOption == "SegmentationOptionRollingWC")
            {
                int numWords = TokenizedText.Count;
                
                int SampleRate = int.Parse(SegmentationParameter["RollinWCParam"]);
                int WordsPerSegment = int.Parse(SegmentationParameter["RollingWCWindowParam"]);

                //set up the amount that we're going to subtract from each
                //"anchor" point
                int leftSamplingWindow = 0;
                if (WordsPerSegment % 2 == 0)
                {
                    leftSamplingWindow = WordsPerSegment / 2;
                }
                else
                {
                    leftSamplingWindow = (WordsPerSegment + 1) / 2;
                }
                for (int i = SampleRate - 1; i < numWords; i += SampleRate)
                {
                    //make sure that we don't go too far left
                    int leftStartingPoint = i - leftSamplingWindow;
                    if (leftStartingPoint < 0)
                    {
                        leftStartingPoint = 0;
                    }


                    //make sure that we aren't trying to sample words past the end of the text
                    int wordsToTake = WordsPerSegment + Math.Min(0, i - leftSamplingWindow);
                    if (leftStartingPoint + wordsToTake > numWords - 1) wordsToTake = numWords - leftStartingPoint;

                    SegmentsToReturn.Add(string.Join(" ", TokenizedText.GetRange(leftStartingPoint, wordsToTake)));
                }

            }

            else if (SegmentOption == "SegmentationOptionRollingPct")
            {
                int numWords = TokenizedText.Count;

                double SampleRate = double.Parse(SegmentationParameter["RollingPctParam"]) / 100;
                int WordsPerSegment = (int)Math.Ceiling((double.Parse(SegmentationParameter["RollingPctWindowParam"]) / 100) * numWords);


                //set up the amount that we're going to subtract from each
                //"anchor" point
                int leftSamplingWindow = 0;
                if (WordsPerSegment % 2 == 0)
                {
                    leftSamplingWindow = WordsPerSegment / 2;
                }
                else
                {
                    leftSamplingWindow = (WordsPerSegment + 1) / 2;
                }
                for (double i = SampleRate; i < 1; i += SampleRate)
                {

                    int anchorPoint = (int)Math.Round(numWords * i);

                    //make sure that we don't go too far left
                    int leftStartingPoint = anchorPoint - leftSamplingWindow;
                    if (leftStartingPoint < 0)
                    {
                        leftStartingPoint = 0;
                    }


                    //make sure that we aren't trying to sample words past the end of the text
                    int wordsToTake = WordsPerSegment + Math.Min(0, anchorPoint - leftSamplingWindow);
                    if (leftStartingPoint + wordsToTake > numWords - 1) wordsToTake = numWords - leftStartingPoint;

                    SegmentsToReturn.Add(string.Join(" ", TokenizedText.GetRange(leftStartingPoint, wordsToTake)));
                }

            }

            return (SegmentsToReturn);

        }










        //modified version of
        //https://stackoverflow.com/a/3893011

        /// <summary>
        /// Partition a list of elements into a smaller group of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="totalPartitions"></param>
        /// <returns></returns>
        public static List<List<string>> Partition<T>(List<string> list, int totalPartitions)
        {

            List<string>[] partitions = new List<string>[totalPartitions];

            //if (list == null)
            //    throw new ArgumentNullException("list");

            //if (totalPartitions < 1)
            //    throw new ArgumentOutOfRangeException("totalPartitions");

            if (list == null || totalPartitions < 1)
            {
                partitions[0] = new List<string>() { "" };
                return partitions.ToList();
            }
                


            int maxSize = (int)Math.Ceiling(list.Count / (double)totalPartitions);
            int k = 0;

            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = new List<string>();
                for (int j = k; j < k + maxSize; j++)
                {
                    if (j >= list.Count)
                        break;
                    partitions[i].Add(list[j]);
                }
                k += maxSize;
            }

            return partitions.ToList();
        }




















        //old and busted. some of this is broken code from MEH that simply fails in some cases.
        //tried to modify, got distracted, opted for a *far* cleaner approach instead (above).

        //private List<string> Segment_Chopper(string[] array_to_split, int number_of_splits)
        //{

        //    if (array_to_split.Length < number_of_splits) number_of_splits = array_to_split.Length;

        //    string[][] Segmented_Array = new string[number_of_splits][];
        //    int Segment_Size = (int)System.Math.Ceiling((double)array_to_split.Length / number_of_splits);


        //    for (int i = 0; i < number_of_splits; i++)
        //    {

        //        int SegmentStart = i * Segment_Size;
        //        int SegmentEnd = ((i + 1) * Segment_Size);
        //        int SegmentLength = SegmentEnd - SegmentStart;

                

        //        //if ((i != number_of_splits - 1))
        //        //{

        //            Segmented_Array[i] = new string[SegmentLength];

        //            if (SegmentEnd + 1 <= array_to_split.Length)
        //            {
        //                Array.Copy(array_to_split, SegmentStart, Segmented_Array[i], 0, SegmentLength);
        //            }
        //            else
        //            {
        //                SegmentLength = Segment_Size;
        //                string[] tailstring = new string[SegmentLength];
        //                for (int j = 0; j < SegmentLength; j++) tailstring[j] = "";
        //                for (int j = SegmentStart; j < array_to_split.Length; j++) tailstring[j - SegmentStart] = array_to_split[j];
        //                Array.Copy(tailstring, SegmentStart, Segmented_Array[i], 0, SegmentLength);
        //            }



        //        //}
        //        //else
        //        //{
        //        //    SegmentLength = array_to_split.Length - SegmentStart;

        //        //    Segmented_Array[i] = new string[SegmentLength];

        //        //    if (SegmentEnd + 1 <= array_to_split.Length)
        //        //    {
        //        //        Array.Copy(array_to_split, SegmentStart, Segmented_Array[i], 0, SegmentLength);
        //        //    }
        //        //    else
        //        //    {
        //        //        string[] tailstring = new string[SegmentLength];
        //        //        for (int j = 0; j < SegmentLength; j++) tailstring[j] = "";
        //        //        for (int j = SegmentStart; j < array_to_split.Length; j++) tailstring[j - SegmentStart] = "";
        //        //        Array.Copy(tailstring, 0, Segmented_Array[i], 0, SegmentLength);
        //        //    }
        //        //}

        //    }



        //    List<string> TextSegments = new List<string>();

        //    for (int i = 0; i < number_of_splits; i++) TextSegments.Add(string.Join(" ", Segmented_Array[i]));

        //    return TextSegments;
        //}








    }


       
}
