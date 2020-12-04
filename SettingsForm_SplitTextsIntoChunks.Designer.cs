namespace SplitTextsIntoChunks
{
    partial class SettingsForm_SplitTextsIntoChunks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_SplitTextsIntoChunks));
            this.OKButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SegmentationParameterTextboxRegex = new System.Windows.Forms.TextBox();
            this.SegmentationOptionRegex = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionEqualSegments = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionWordsPerSegment = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionRollingWC = new System.Windows.Forms.RadioButton();
            this.SegmentationParameterTextboxEqualSize = new System.Windows.Forms.TextBox();
            this.SegmentationParameterTextboxWordsPerSegment = new System.Windows.Forms.TextBox();
            this.SegmentIntervalWCTextbox = new System.Windows.Forms.TextBox();
            this.WindowSizeWCTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WindowSizePctTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SegmentIntervalPctTextbox = new System.Windows.Forms.TextBox();
            this.SegmentationOptionRollingPct = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(313, 433);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(100, 208);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(216, 17);
            this.label17.TabIndex = 13;
            this.label17.Text = "Capture Segment Every X Words";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Segmentation (by Token)";
            // 
            // SegmentationParameterTextboxRegex
            // 
            this.SegmentationParameterTextboxRegex.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationParameterTextboxRegex.Location = new System.Drawing.Point(344, 128);
            this.SegmentationParameterTextboxRegex.MaxLength = 999999999;
            this.SegmentationParameterTextboxRegex.Name = "SegmentationParameterTextboxRegex";
            this.SegmentationParameterTextboxRegex.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentationParameterTextboxRegex.Size = new System.Drawing.Size(383, 23);
            this.SegmentationParameterTextboxRegex.TabIndex = 11;
            // 
            // SegmentationOptionRegex
            // 
            this.SegmentationOptionRegex.AutoSize = true;
            this.SegmentationOptionRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionRegex.Location = new System.Drawing.Point(15, 128);
            this.SegmentationOptionRegex.Name = "SegmentationOptionRegex";
            this.SegmentationOptionRegex.Size = new System.Drawing.Size(275, 21);
            this.SegmentationOptionRegex.TabIndex = 10;
            this.SegmentationOptionRegex.Text = "Segment Texts with Regular Expression";
            this.SegmentationOptionRegex.UseVisualStyleBackColor = true;
            this.SegmentationOptionRegex.CheckedChanged += new System.EventHandler(this.OptionSelectChanged);
            // 
            // SegmentationOptionEqualSegments
            // 
            this.SegmentationOptionEqualSegments.AutoSize = true;
            this.SegmentationOptionEqualSegments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionEqualSegments.Location = new System.Drawing.Point(15, 62);
            this.SegmentationOptionEqualSegments.Name = "SegmentationOptionEqualSegments";
            this.SegmentationOptionEqualSegments.Size = new System.Drawing.Size(289, 21);
            this.SegmentationOptionEqualSegments.TabIndex = 9;
            this.SegmentationOptionEqualSegments.Text = "Split Texts into N Equally-Sized Segments";
            this.SegmentationOptionEqualSegments.UseVisualStyleBackColor = true;
            this.SegmentationOptionEqualSegments.CheckedChanged += new System.EventHandler(this.OptionSelectChanged);
            // 
            // SegmentationOptionWordsPerSegment
            // 
            this.SegmentationOptionWordsPerSegment.AutoSize = true;
            this.SegmentationOptionWordsPerSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionWordsPerSegment.Location = new System.Drawing.Point(15, 95);
            this.SegmentationOptionWordsPerSegment.Name = "SegmentationOptionWordsPerSegment";
            this.SegmentationOptionWordsPerSegment.Size = new System.Drawing.Size(313, 21);
            this.SegmentationOptionWordsPerSegment.TabIndex = 8;
            this.SegmentationOptionWordsPerSegment.Text = "Desired Segment Size (Tokens Per Segment)";
            this.SegmentationOptionWordsPerSegment.UseVisualStyleBackColor = true;
            this.SegmentationOptionWordsPerSegment.CheckedChanged += new System.EventHandler(this.OptionSelectChanged);
            // 
            // SegmentationOptionRollingWC
            // 
            this.SegmentationOptionRollingWC.AutoSize = true;
            this.SegmentationOptionRollingWC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionRollingWC.Location = new System.Drawing.Point(13, 173);
            this.SegmentationOptionRollingWC.Name = "SegmentationOptionRollingWC";
            this.SegmentationOptionRollingWC.Size = new System.Drawing.Size(282, 21);
            this.SegmentationOptionRollingWC.TabIndex = 14;
            this.SegmentationOptionRollingWC.Text = "\"Rolling\" Segments based on # of Words";
            this.SegmentationOptionRollingWC.UseVisualStyleBackColor = true;
            this.SegmentationOptionRollingWC.CheckedChanged += new System.EventHandler(this.OptionSelectChanged);
            // 
            // SegmentationParameterTextboxEqualSize
            // 
            this.SegmentationParameterTextboxEqualSize.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationParameterTextboxEqualSize.Location = new System.Drawing.Point(344, 60);
            this.SegmentationParameterTextboxEqualSize.MaxLength = 999999999;
            this.SegmentationParameterTextboxEqualSize.Name = "SegmentationParameterTextboxEqualSize";
            this.SegmentationParameterTextboxEqualSize.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentationParameterTextboxEqualSize.Size = new System.Drawing.Size(383, 23);
            this.SegmentationParameterTextboxEqualSize.TabIndex = 15;
            // 
            // SegmentationParameterTextboxWordsPerSegment
            // 
            this.SegmentationParameterTextboxWordsPerSegment.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationParameterTextboxWordsPerSegment.Location = new System.Drawing.Point(344, 95);
            this.SegmentationParameterTextboxWordsPerSegment.MaxLength = 999999999;
            this.SegmentationParameterTextboxWordsPerSegment.Name = "SegmentationParameterTextboxWordsPerSegment";
            this.SegmentationParameterTextboxWordsPerSegment.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentationParameterTextboxWordsPerSegment.Size = new System.Drawing.Size(383, 23);
            this.SegmentationParameterTextboxWordsPerSegment.TabIndex = 16;
            // 
            // SegmentIntervalWCTextbox
            // 
            this.SegmentIntervalWCTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentIntervalWCTextbox.Location = new System.Drawing.Point(344, 206);
            this.SegmentIntervalWCTextbox.MaxLength = 999999999;
            this.SegmentIntervalWCTextbox.Name = "SegmentIntervalWCTextbox";
            this.SegmentIntervalWCTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentIntervalWCTextbox.Size = new System.Drawing.Size(158, 23);
            this.SegmentIntervalWCTextbox.TabIndex = 17;
            // 
            // WindowSizeWCTextbox
            // 
            this.WindowSizeWCTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowSizeWCTextbox.Location = new System.Drawing.Point(344, 239);
            this.WindowSizeWCTextbox.MaxLength = 999999999;
            this.WindowSizeWCTextbox.Name = "WindowSizeWCTextbox";
            this.WindowSizeWCTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.WindowSizeWCTextbox.Size = new System.Drawing.Size(158, 23);
            this.WindowSizeWCTextbox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 241);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Word Window Size (# of Words)";
            // 
            // WindowSizePctTextbox
            // 
            this.WindowSizePctTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowSizePctTextbox.Location = new System.Drawing.Point(344, 350);
            this.WindowSizePctTextbox.MaxLength = 999999999;
            this.WindowSizePctTextbox.Name = "WindowSizePctTextbox";
            this.WindowSizePctTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.WindowSizePctTextbox.Size = new System.Drawing.Size(158, 23);
            this.WindowSizePctTextbox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 352);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Word Window Size (% of Text)";
            // 
            // SegmentIntervalPctTextbox
            // 
            this.SegmentIntervalPctTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentIntervalPctTextbox.Location = new System.Drawing.Point(344, 317);
            this.SegmentIntervalPctTextbox.MaxLength = 999999999;
            this.SegmentIntervalPctTextbox.Name = "SegmentIntervalPctTextbox";
            this.SegmentIntervalPctTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentIntervalPctTextbox.Size = new System.Drawing.Size(158, 23);
            this.SegmentIntervalPctTextbox.TabIndex = 22;
            // 
            // SegmentationOptionRollingPct
            // 
            this.SegmentationOptionRollingPct.AutoSize = true;
            this.SegmentationOptionRollingPct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionRollingPct.Location = new System.Drawing.Point(15, 284);
            this.SegmentationOptionRollingPct.Name = "SegmentationOptionRollingPct";
            this.SegmentationOptionRollingPct.Size = new System.Drawing.Size(320, 21);
            this.SegmentationOptionRollingPct.TabIndex = 21;
            this.SegmentationOptionRollingPct.Text = "\"Rolling\" Segments based on % of Text Length";
            this.SegmentationOptionRollingPct.UseVisualStyleBackColor = true;
            this.SegmentationOptionRollingPct.CheckedChanged += new System.EventHandler(this.OptionSelectChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Capture Segment Every X%";
            // 
            // SettingsForm_SplitTextsIntoChunks
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 485);
            this.Controls.Add(this.WindowSizePctTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SegmentIntervalPctTextbox);
            this.Controls.Add(this.SegmentationOptionRollingPct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WindowSizeWCTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SegmentIntervalWCTextbox);
            this.Controls.Add(this.SegmentationParameterTextboxWordsPerSegment);
            this.Controls.Add(this.SegmentationParameterTextboxEqualSize);
            this.Controls.Add(this.SegmentationOptionRollingWC);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SegmentationParameterTextboxRegex);
            this.Controls.Add(this.SegmentationOptionRegex);
            this.Controls.Add(this.SegmentationOptionEqualSegments);
            this.Controls.Add(this.SegmentationOptionWordsPerSegment);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_SplitTextsIntoChunks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SegmentationParameterTextboxRegex;
        private System.Windows.Forms.RadioButton SegmentationOptionRegex;
        private System.Windows.Forms.RadioButton SegmentationOptionEqualSegments;
        private System.Windows.Forms.RadioButton SegmentationOptionWordsPerSegment;
        private System.Windows.Forms.RadioButton SegmentationOptionRollingWC;
        private System.Windows.Forms.TextBox SegmentationParameterTextboxEqualSize;
        private System.Windows.Forms.TextBox SegmentationParameterTextboxWordsPerSegment;
        private System.Windows.Forms.TextBox SegmentIntervalWCTextbox;
        private System.Windows.Forms.TextBox WindowSizeWCTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WindowSizePctTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SegmentIntervalPctTextbox;
        private System.Windows.Forms.RadioButton SegmentationOptionRollingPct;
        private System.Windows.Forms.Label label3;
    }
}