namespace Supakulltracker
{
    partial class LabeledTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SourceLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(3, 9);
            this.SourceLabel.MaximumSize = new System.Drawing.Size(100, 20);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(35, 13);
            this.SourceLabel.TabIndex = 0;
            this.SourceLabel.Text = "label1";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(112, 6);
            this.valueTextBox.MinimumSize = new System.Drawing.Size(200, 20);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(200, 20);
            this.valueTextBox.TabIndex = 1;
            // 
            // LabeledTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.SourceLabel);
            this.Name = "LabeledTextBox";
            this.Size = new System.Drawing.Size(315, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.TextBox valueTextBox;
    }
}
