using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SplitTextsIntoChunks
{
    internal partial class SettingsForm_SplitTextsIntoChunks : Form
    {


        #region Get and Set Options

        public Dictionary<string, string> SegmentParameters { get; set; } = new Dictionary<string, string>();
        public string SegmentationType { get; set; }

       #endregion



        public SettingsForm_SplitTextsIntoChunks(Dictionary<string, string> SegmentParameter, string SegmentationType)
        {
            InitializeComponent();



            SegmentationParameterTextboxEqualSize.Enabled = false;
            SegmentationParameterTextboxWordsPerSegment.Enabled = false;
            SegmentationParameterTextboxRegex.Enabled = false;
            SegmentIntervalWCTextbox.Enabled = false;
            WindowSizeWCTextbox.Enabled = false;
            SegmentIntervalPctTextbox.Enabled = false;
            WindowSizePctTextbox.Enabled = false;

            SegmentationParameterTextboxEqualSize.Text = SegmentParameter["EqualSizeParam"];
            SegmentationParameterTextboxWordsPerSegment.Text = SegmentParameter["WordsPerSegmentParam"];
            SegmentationParameterTextboxRegex.Text = SegmentParameter["RegexParam"];
            SegmentIntervalWCTextbox.Text = SegmentParameter["RollinWCParam"];
            WindowSizeWCTextbox.Text = SegmentParameter["RollingWCWindowParam"];
            SegmentIntervalPctTextbox.Text = SegmentParameter["RollingPctParam"];
            WindowSizePctTextbox.Text = SegmentParameter["RollingPctWindowParam"];


            switch (SegmentationType)
            {
                case "SegmentationOptionEqualSegments":
                    SegmentationOptionEqualSegments.Checked = true;
                    SegmentationParameterTextboxEqualSize.Enabled = true;
                    break;
                case "SegmentationOptionWordsPerSegment":
                    SegmentationOptionWordsPerSegment.Checked = true;
                    SegmentationParameterTextboxWordsPerSegment.Enabled = true;
                    break;
                case "SegmentationOptionRegex":
                    SegmentationOptionRegex.Checked = true;
                    SegmentationParameterTextboxRegex.Enabled = true;
                    break;
                case "SegmentationOptionRollingWC":
                    SegmentationOptionRollingWC.Checked = true;
                    SegmentIntervalWCTextbox.Enabled = true;
                    WindowSizeWCTextbox.Enabled = true;
                    break;
                case "SegmentationOptionRollingPct":
                    SegmentationOptionRollingPct.Checked = true;
                    SegmentIntervalPctTextbox.Enabled = true;
                    WindowSizePctTextbox.Enabled = true;
                    break;

            }
            
            
            



        }






        private void OKButton_Click(object sender, System.EventArgs e)
        {

            if (SegmentationParameterTextboxRegex.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must input a segmentation parameter.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            bool paramsValid = true;

            #region Check Settings for Equal Segmentation
            if (SegmentationOptionEqualSegments.Checked)
            {

                bool isNumeric = int.TryParse(SegmentationParameterTextboxEqualSize.Text.Trim(), out int n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (int.Parse(SegmentationParameterTextboxEqualSize.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                }

                if (paramsValid == false)
                {
                    MessageBox.Show("Your segmentation parameter must be a positive integer.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            #region Check Settings for Words Per Segment Segmentation
            else if (SegmentationOptionWordsPerSegment.Checked)
            {

                bool isNumeric = int.TryParse(SegmentationParameterTextboxWordsPerSegment.Text.Trim(), out int n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (int.Parse(SegmentationParameterTextboxWordsPerSegment.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                }

                if (paramsValid == false)
                {
                    MessageBox.Show("Your segmentation parameter must be a positive integer.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            #region Regular Expression Segmentation Validation
            else if (SegmentationOptionRegex.Checked)
            {

                try
                {
                    Regex Test = new Regex(SegmentationParameterTextboxRegex.Text, RegexOptions.Compiled);
                }
                catch 
                {
                    MessageBox.Show("Your regular expression does not appear to be valid.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            #endregion

            #region Check Settings for Rolling WC Segmentation
            else if (SegmentationOptionRollingWC.Checked)
            {

                # region check the first parameter
                bool isNumeric = int.TryParse(SegmentIntervalWCTextbox.Text.Trim(), out int n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (int.Parse(SegmentIntervalWCTextbox.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                }
                if (paramsValid == false)
                {
                    MessageBox.Show("Your \"Capture Segment Every X Words\" parameter must be a positive integer.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                # region check the second parameter
                isNumeric = int.TryParse(WindowSizeWCTextbox.Text.Trim(), out n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (int.Parse(WindowSizeWCTextbox.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                }
                if (paramsValid == false)
                {
                    MessageBox.Show("Your \"Word Window Size (# of Words)\" parameter must be a positive integer.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion


            }
            #endregion

            #region Check Settings for % Segmentation
            else if (SegmentationOptionRollingPct.Checked)
            {

                # region check the first parameter
                bool isNumeric = double.TryParse(SegmentIntervalPctTextbox.Text.Trim(), out double n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (double.Parse(SegmentIntervalPctTextbox.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                    else if (double.Parse(SegmentIntervalPctTextbox.Text.Trim()) >= 100.0)
                    {
                        paramsValid = false;
                    }
                }
                if (paramsValid == false)
                {
                    MessageBox.Show("Your \"Capture Segment Every X%\" parameter must be between 0 and 100.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                # region check the second parameter
                isNumeric = double.TryParse(WindowSizePctTextbox.Text.Trim(), out n);
                if (!isNumeric)
                {
                    paramsValid = false;
                }
                else
                {
                    if (double.Parse(WindowSizePctTextbox.Text.Trim()) <= 0)
                    {
                        paramsValid = false;
                    }
                    else if (double.Parse(WindowSizePctTextbox.Text.Trim()) >= 100)
                    {
                        paramsValid = false;
                    }
                }
                if (paramsValid == false)
                {
                    MessageBox.Show("Your \"Word Window Size (% of Text)\" parameter must be between 0 and 100.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion


            }
            #endregion







            if (SegmentationOptionEqualSegments.Checked) SegmentationType = "SegmentationOptionEqualSegments";
            else if (SegmentationOptionWordsPerSegment.Checked) SegmentationType = "SegmentationOptionWordsPerSegment";
            else if (SegmentationOptionRegex.Checked) SegmentationType = "SegmentationOptionRegex";
            else if (SegmentationOptionRollingWC.Checked) SegmentationType = "SegmentationOptionRollingWC";
            else if (SegmentationOptionRollingPct.Checked) SegmentationType = "SegmentationOptionRollingPct";

            SegmentParameters["EqualSizeParam"] = SegmentationParameterTextboxEqualSize.Text.Trim();
            SegmentParameters["WordsPerSegmentParam"] = SegmentationParameterTextboxWordsPerSegment.Text.Trim();
            SegmentParameters["RegexParam"] = SegmentationParameterTextboxRegex.Text;
            SegmentParameters["RollinWCParam"] = SegmentIntervalWCTextbox.Text.Trim();
            SegmentParameters["RollingWCWindowParam"] = WindowSizeWCTextbox.Text.Trim();
            SegmentParameters["RollingPctParam"] = SegmentIntervalPctTextbox.Text.Trim();
            SegmentParameters["RollingPctWindowParam"] = WindowSizePctTextbox.Text.Trim();




            this.DialogResult = DialogResult.OK;

        }










        private void OptionSelectChanged(object sender, System.EventArgs e)
        {
            SegmentationParameterTextboxEqualSize.Enabled = false;
            SegmentationParameterTextboxWordsPerSegment.Enabled = false;
            SegmentationParameterTextboxRegex.Enabled = false;
            SegmentIntervalWCTextbox.Enabled = false;
            WindowSizeWCTextbox.Enabled = false;
            SegmentIntervalPctTextbox.Enabled = false;
            WindowSizePctTextbox.Enabled = false;


            if (SegmentationOptionEqualSegments.Checked)
            {
                SegmentationType = "SegmentationOptionEqualSegments";
                SegmentationParameterTextboxEqualSize.Enabled = true;
            }
            else if (SegmentationOptionWordsPerSegment.Checked)
            {
                SegmentationType = "SegmentationOptionWordsPerSegment";
                SegmentationParameterTextboxWordsPerSegment.Enabled = true;
            }
            else if (SegmentationOptionRegex.Checked)
            {
                SegmentationType = "SegmentationOptionRegex";
                SegmentationParameterTextboxRegex.Enabled = true;
            }
            else if (SegmentationOptionRollingWC.Checked)
            {
                SegmentationType = "SegmentationOptionRollingWC";
                SegmentIntervalWCTextbox.Enabled = true;
                WindowSizeWCTextbox.Enabled = true;
            }
            else if (SegmentationOptionRollingPct.Checked)
            {
                SegmentationType = "SegmentationOptionRollingPct";
                SegmentIntervalPctTextbox.Enabled = true;
                WindowSizePctTextbox.Enabled = true;
            }


        }



    }
}
