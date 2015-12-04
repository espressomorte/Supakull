namespace Supakulltracker
{
    partial class GenerateIndexesForm
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
            this.GenerateIndexesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateIndexesButton
            // 
            this.GenerateIndexesButton.Location = new System.Drawing.Point(96, 45);
            this.GenerateIndexesButton.Name = "GenerateIndexesButton";
            this.GenerateIndexesButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateIndexesButton.TabIndex = 0;
            this.GenerateIndexesButton.Text = "Start";
            this.GenerateIndexesButton.UseVisualStyleBackColor = true;
            this.GenerateIndexesButton.Click += new System.EventHandler(this.GenerateIndexesButton_Click);
            // 
            // GenerateIndexesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 119);
            this.Controls.Add(this.GenerateIndexesButton);
            this.Name = "GenerateIndexesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenerateIndexes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GenerateIndexesButton;
    }
}