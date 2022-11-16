namespace SoftwareFinder
{
    partial class SoftwareFinderForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftwareFinderForm));
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConvertToHTMLButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameCheck = new System.Windows.Forms.CheckBox();
            this.AnnotationCheck = new System.Windows.Forms.CheckBox();
            this.TypeCheck = new System.Windows.Forms.CheckBox();
            this.VersionCheck = new System.Windows.Forms.CheckBox();
            this.DeveloperCheck = new System.Windows.Forms.CheckBox();
            this.DistributionCheck = new System.Windows.Forms.CheckBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AnnotationBox = new System.Windows.Forms.TextBox();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.VersionBox = new System.Windows.Forms.TextBox();
            this.DeveloperBox = new System.Windows.Forms.TextBox();
            this.DistributionBox = new System.Windows.Forms.TextBox();
            this.DomButton = new System.Windows.Forms.RadioButton();
            this.SaxButton = new System.Windows.Forms.RadioButton();
            this.LinqButton = new System.Windows.Forms.RadioButton();
            this.ResultsBox = new System.Windows.Forms.RichTextBox();
            this.HTMLSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ConvertToHTMLButton
            // 
            resources.ApplyResources(this.ConvertToHTMLButton, "ConvertToHTMLButton");
            this.ConvertToHTMLButton.Name = "ConvertToHTMLButton";
            this.ConvertToHTMLButton.UseVisualStyleBackColor = true;
            this.ConvertToHTMLButton.Click += new System.EventHandler(this.ConvertToHTMLButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("NameBox.AutoCompleteCustomSource"),
            resources.GetString("NameBox.AutoCompleteCustomSource1"),
            resources.GetString("NameBox.AutoCompleteCustomSource2"),
            resources.GetString("NameBox.AutoCompleteCustomSource3"),
            resources.GetString("NameBox.AutoCompleteCustomSource4"),
            resources.GetString("NameBox.AutoCompleteCustomSource5"),
            resources.GetString("NameBox.AutoCompleteCustomSource6"),
            resources.GetString("NameBox.AutoCompleteCustomSource7"),
            resources.GetString("NameBox.AutoCompleteCustomSource8"),
            resources.GetString("NameBox.AutoCompleteCustomSource9"),
            resources.GetString("NameBox.AutoCompleteCustomSource10"),
            resources.GetString("NameBox.AutoCompleteCustomSource11"),
            resources.GetString("NameBox.AutoCompleteCustomSource12"),
            resources.GetString("NameBox.AutoCompleteCustomSource13"),
            resources.GetString("NameBox.AutoCompleteCustomSource14"),
            resources.GetString("NameBox.AutoCompleteCustomSource15"),
            resources.GetString("NameBox.AutoCompleteCustomSource16"),
            resources.GetString("NameBox.AutoCompleteCustomSource17"),
            resources.GetString("NameBox.AutoCompleteCustomSource18")});
            this.NameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.NameBox, "NameBox");
            this.NameBox.Name = "NameBox";
            // 
            // NameCheck
            // 
            resources.ApplyResources(this.NameCheck, "NameCheck");
            this.NameCheck.Name = "NameCheck";
            this.NameCheck.UseVisualStyleBackColor = true;
            // 
            // AnnotationCheck
            // 
            resources.ApplyResources(this.AnnotationCheck, "AnnotationCheck");
            this.AnnotationCheck.Name = "AnnotationCheck";
            this.AnnotationCheck.UseVisualStyleBackColor = true;
            // 
            // TypeCheck
            // 
            resources.ApplyResources(this.TypeCheck, "TypeCheck");
            this.TypeCheck.Name = "TypeCheck";
            this.TypeCheck.UseVisualStyleBackColor = true;
            // 
            // VersionCheck
            // 
            resources.ApplyResources(this.VersionCheck, "VersionCheck");
            this.VersionCheck.Name = "VersionCheck";
            this.VersionCheck.UseVisualStyleBackColor = true;
            // 
            // DeveloperCheck
            // 
            resources.ApplyResources(this.DeveloperCheck, "DeveloperCheck");
            this.DeveloperCheck.Name = "DeveloperCheck";
            this.DeveloperCheck.UseVisualStyleBackColor = true;
            // 
            // DistributionCheck
            // 
            resources.ApplyResources(this.DistributionCheck, "DistributionCheck");
            this.DistributionCheck.Name = "DistributionCheck";
            this.DistributionCheck.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AnnotationBox
            // 
            resources.ApplyResources(this.AnnotationBox, "AnnotationBox");
            this.AnnotationBox.Name = "AnnotationBox";
            // 
            // TypeBox
            // 
            resources.ApplyResources(this.TypeBox, "TypeBox");
            this.TypeBox.Name = "TypeBox";
            // 
            // VersionBox
            // 
            resources.ApplyResources(this.VersionBox, "VersionBox");
            this.VersionBox.Name = "VersionBox";
            // 
            // DeveloperBox
            // 
            resources.ApplyResources(this.DeveloperBox, "DeveloperBox");
            this.DeveloperBox.Name = "DeveloperBox";
            // 
            // DistributionBox
            // 
            this.DistributionBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("DistributionBox.AutoCompleteCustomSource"),
            resources.GetString("DistributionBox.AutoCompleteCustomSource1"),
            resources.GetString("DistributionBox.AutoCompleteCustomSource2")});
            this.DistributionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DistributionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.DistributionBox, "DistributionBox");
            this.DistributionBox.Name = "DistributionBox";
            // 
            // DomButton
            // 
            resources.ApplyResources(this.DomButton, "DomButton");
            this.DomButton.Name = "DomButton";
            this.DomButton.TabStop = true;
            this.DomButton.UseVisualStyleBackColor = true;
            // 
            // SaxButton
            // 
            resources.ApplyResources(this.SaxButton, "SaxButton");
            this.SaxButton.Name = "SaxButton";
            this.SaxButton.TabStop = true;
            this.SaxButton.UseVisualStyleBackColor = true;
            // 
            // LinqButton
            // 
            resources.ApplyResources(this.LinqButton, "LinqButton");
            this.LinqButton.Name = "LinqButton";
            this.LinqButton.TabStop = true;
            this.LinqButton.UseVisualStyleBackColor = true;
            // 
            // ResultsBox
            // 
            this.ResultsBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.ResultsBox, "ResultsBox");
            this.ResultsBox.Name = "ResultsBox";
            this.ResultsBox.ReadOnly = true;
            // 
            // HTMLSaveDialog
            // 
            this.HTMLSaveDialog.FileName = "ResultHTML";
            resources.ApplyResources(this.HTMLSaveDialog, "HTMLSaveDialog");
            // 
            // SoftwareFinderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ResultsBox);
            this.Controls.Add(this.LinqButton);
            this.Controls.Add(this.SaxButton);
            this.Controls.Add(this.DomButton);
            this.Controls.Add(this.DistributionBox);
            this.Controls.Add(this.DeveloperBox);
            this.Controls.Add(this.VersionBox);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.AnnotationBox);
            this.Controls.Add(this.DistributionCheck);
            this.Controls.Add(this.DeveloperCheck);
            this.Controls.Add(this.VersionCheck);
            this.Controls.Add(this.TypeCheck);
            this.Controls.Add(this.AnnotationCheck);
            this.Controls.Add(this.NameCheck);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.ConvertToHTMLButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SearchButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftwareFinderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Button ClearButton;
        public TextBox NameBox;
        public Button SearchButton;
        public TextBox AnnotationBox;
        public TextBox TypeBox;
        public TextBox VersionBox;
        public TextBox DeveloperBox;
        public TextBox DistributionBox;
        public SaveFileDialog HTMLSaveDialog;
        internal CheckBox NameCheck;
        internal CheckBox AnnotationCheck;
        internal CheckBox TypeCheck;
        internal CheckBox VersionCheck;
        internal CheckBox DeveloperCheck;
        internal CheckBox DistributionCheck;
        internal RadioButton DomButton;
        internal RadioButton SaxButton;
        internal RadioButton LinqButton;
        internal RichTextBox ResultsBox;
        internal Button ConvertToHTMLButton;
    }
}