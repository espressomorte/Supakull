namespace Supakulltracker
{
    partial class PopUpMultipleEditor
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
            this.popUpFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // popUpFLP
            // 
            this.popUpFLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popUpFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.popUpFLP.Location = new System.Drawing.Point(0, 0);
            this.popUpFLP.MinimumSize = new System.Drawing.Size(315, 30);
            this.popUpFLP.Name = "popUpFLP";
            this.popUpFLP.Size = new System.Drawing.Size(325, 298);
            this.popUpFLP.TabIndex = 0;
            // 
            // PopUpMultipleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 298);
            this.Controls.Add(this.popUpFLP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PopUpMultipleEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PopUpMultipleEditor";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel popUpFLP;
    }
}