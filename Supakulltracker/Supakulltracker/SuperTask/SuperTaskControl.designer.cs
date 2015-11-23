namespace Supakulltracker
{
    partial class SuperTaskControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubtaskType = new System.Windows.Forms.TextBox();
            this.TaskSummary = new System.Windows.Forms.TextBox();
            this.superTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.superTaskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subtask Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Summary";
            // 
            // SubtaskType
            // 
            this.SubtaskType.Location = new System.Drawing.Point(104, 50);
            this.SubtaskType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubtaskType.Name = "SubtaskType";
            this.SubtaskType.ReadOnly = true;
            this.SubtaskType.Size = new System.Drawing.Size(167, 20);
            this.SubtaskType.TabIndex = 2;
            // 
            // TaskSummary
            // 
            this.TaskSummary.Location = new System.Drawing.Point(104, 83);
            this.TaskSummary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TaskSummary.Multiline = true;
            this.TaskSummary.Name = "TaskSummary";
            this.TaskSummary.ReadOnly = true;
            this.TaskSummary.Size = new System.Drawing.Size(167, 93);
            this.TaskSummary.TabIndex = 3;
            // 
            // superTaskBindingSource
            // 
            this.superTaskBindingSource.DataSource = typeof(Supakulltracker.SuperTask);
            // 
            // SuperTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TaskSummary);
            this.Controls.Add(this.SubtaskType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SuperTaskControl";
            this.Size = new System.Drawing.Size(303, 221);
            ((System.ComponentModel.ISupportInitialize)(this.superTaskBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubtaskType;
        private System.Windows.Forms.TextBox TaskSummary;
        private System.Windows.Forms.BindingSource superTaskBindingSource;
    }
}
