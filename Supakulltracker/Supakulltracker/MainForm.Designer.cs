namespace Supakulltracker
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateIndexesForSearchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.searchControl = new Supakulltracker.SearchControl();
            this.taskDetailTabControl = new System.Windows.Forms.TabControl();
            this.btnUdateAllTasks = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.generateIndexesForSearchingToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            //this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // generateIndexesForSearchingToolStripMenuItem
            // 
            this.generateIndexesForSearchingToolStripMenuItem.Name = "generateIndexesForSearchingToolStripMenuItem";
            this.generateIndexesForSearchingToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.generateIndexesForSearchingToolStripMenuItem.Text = "Generate Indexes for searching";
            //this.generateIndexesForSearchingToolStripMenuItem.Click += new System.EventHandler(this.generateIndexesForSearchingToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.searchControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.taskDetailTabControl);
            this.splitContainer.Size = new System.Drawing.Size(894, 516);
            this.splitContainer.SplitterDistance = 305;
            this.splitContainer.SplitterWidth = 15;
            this.splitContainer.TabIndex = 3;
            // 
            // searchControl
            // 
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchControl.Location = new System.Drawing.Point(0, 0);
            this.searchControl.Name = "searchControl";
            this.searchControl.Size = new System.Drawing.Size(305, 516);
            this.searchControl.TabIndex = 0;
            this.searchControl.Tasks = null;
            //this.searchControl.BoardCellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Board_CellContentClick);
            // 
            // taskDetailTabControl
            // 
            this.taskDetailTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDetailTabControl.Location = new System.Drawing.Point(0, 0);
            this.taskDetailTabControl.Name = "taskDetailTabControl";
            this.taskDetailTabControl.SelectedIndex = 0;
            this.taskDetailTabControl.Size = new System.Drawing.Size(574, 516);
            this.taskDetailTabControl.TabIndex = 0;
            // 
            // btnUdateAllTasks
            // 
            this.btnUdateAllTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUdateAllTasks.Location = new System.Drawing.Point(808, 1);
            this.btnUdateAllTasks.Name = "btnUdateAllTasks";
            this.btnUdateAllTasks.Size = new System.Drawing.Size(75, 23);
            this.btnUdateAllTasks.TabIndex = 4;
            this.btnUdateAllTasks.Text = "Update";
            this.btnUdateAllTasks.UseVisualStyleBackColor = true;
            //this.btnUdateAllTasks.Click += new System.EventHandler(this.btnUdateAllTasks_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 562);
            this.Controls.Add(this.btnUdateAllTasks);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(910, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupaKull";
            //this.Load += new System.EventHandler(this.StartApplication_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl taskDetailTabControl;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

        private System.Windows.Forms.Button btnUdateAllTasks;

        private SearchControl searchControl;
        private System.Windows.Forms.ToolStripMenuItem generateIndexesForSearchingToolStripMenuItem;
    }
}

