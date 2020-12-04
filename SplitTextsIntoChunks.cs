using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;


namespace SplitTextsIntoChunks
{
    public class SplitTextsIntoChunks : Plugin
    {


        public string[] InputType { get; } = { "String", "Tokens" };
        public string OutputType { get; } = "String";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenizedText" } };
        public bool InheritHeader { get; } = true;

        #region Plugin Details and Info

        public string PluginName { get; } = "Segment Text into Chunks";
        public string PluginType { get; } = "Preprocessing";
        public string PluginVersion { get; } = "1.0.3";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Splits a text into multiple texts based on your plugin settings. For example, if you want to split each text into 5 approximately equal chunks, this plugin will do this for you. For most of the settings in this plugin, segmentation is done using a whitespace tokenizer. For many non-Western languages, this means that your text will need to first be tokenized (e.g., the CoreNLP Chinese Tokenizer), then reassembled back into a string, prior to running the text through this plugin. However, for most Western languages (e.g., English, French, German), you can use this plugin immediately following the input of your texts.";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";




        private Dictionary<string, string> SegmentParameters { get; set; } = new Dictionary<string, string>() {
            {"EqualSizeParam" , "5"},
            {"WordsPerSegmentParam" , "250"},
            {"RegexParam" , @"\r\n"},
            {"RollinWCParam" , "250"},
            {"RollingWCWindowParam" , "500"},
            {"RollingPctParam" , "1.0"},
            {"RollingPctWindowParam" , "5.0"},
        };

        private string SegmentationType { get; set; } = "SegmentationOptionEqualSegments";
        private TextSegmenter textSegmenter { get; } = new TextSegmenter();
        private Regex RegexSegmenter { get; } = new Regex("");

        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        public void ChangeSettings()
        {

            using (var form = new SettingsForm_SplitTextsIntoChunks(SegmentParameters, SegmentationType))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;


                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SegmentParameters = form.SegmentParameters;
                    SegmentationType = form.SegmentationType;
                }
            }



        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = new List<string>();
            pData.StringList = new List<string>();

            int maxCount = 0;
            
            switch (Input.Type)
            {
                case "Tokens":
                    maxCount = Input.StringArrayList.Count;
                    break;
                case "String":
                    maxCount = Input.StringList.Count;
                    break;
            }



            for (int i = 0; i < maxCount; i++)
            {

                List<string> segmentedText = new List<string>();

                switch (Input.Type)
                {
                    case "Tokens":
                        segmentedText = textSegmenter.SegmentTokens(SegmentationType, SegmentParameters, Input.StringArrayList[i]);
                        break;
                    case "String":
                        segmentedText = textSegmenter.SegmentStrings(SegmentationType, SegmentParameters, Input.StringList[i]);
                        break;
                }

                
                
                pData.StringList.AddRange(segmentedText);
                for (int j = 0; j < segmentedText.Count; j++)
                {
                    pData.SegmentNumber.Add(Convert.ToUInt64(j + 1));
                    if (Input.SegmentID.Count > 0) pData.SegmentID.Add(Input.SegmentID[i]);

                }


            }
            
            return (pData);



        }



        public void Initialize()
        {

            if (SegmentationType == "SegmentationOptionRegex") textSegmenter.RegexSegmenter = new Regex(SegmentParameters["RegexParam"], RegexOptions.Compiled);

        }


        public bool InspectSettings()
        {
            return true;
        }


        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }


        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            SegmentationType = SettingsDict["SegmentationType"];
            SegmentParameters["EqualSizeParam"] = SettingsDict["EqualSizeParam"];
            SegmentParameters["WordsPerSegmentParam"] = SettingsDict["WordsPerSegmentParam"];
            SegmentParameters["RegexParam"] = SettingsDict["RegexParam"];
            SegmentParameters["RollinWCParam"] = SettingsDict["RollinWCParam"];
            SegmentParameters["RollingWCWindowParam"] = SettingsDict["RollingWCWindowParam"];
            SegmentParameters["RollingPctParam"] = SettingsDict["RollingPctParam"];
            SegmentParameters["RollingPctWindowParam"] = SettingsDict["RollingPctWindowParam"];
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            SettingsDict.Add("SegmentationType", SegmentationType);
            SettingsDict.Add("EqualSizeParam", SegmentParameters["EqualSizeParam"]);
            SettingsDict.Add("WordsPerSegmentParam", SegmentParameters["WordsPerSegmentParam"]);
            SettingsDict.Add("RegexParam", SegmentParameters["RegexParam"]);
            SettingsDict.Add("RollinWCParam", SegmentParameters["RollinWCParam"]);
            SettingsDict.Add("RollingWCWindowParam", SegmentParameters["RollingWCWindowParam"]);
            SettingsDict.Add("RollingPctParam", SegmentParameters["RollingPctParam"]);
            SettingsDict.Add("RollingPctWindowParam", SegmentParameters["RollingPctWindowParam"]);


            return (SettingsDict);
        }
        #endregion


    }
}
