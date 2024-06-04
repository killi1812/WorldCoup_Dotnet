namespace FormGui
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            prToolStripMenuItem = new ToolStripMenuItem();
            cmbRep = new ToolStripComboBox();
            tabs = new TabControl();
            tabPage1 = new TabPage();
            favoritePlayerView1 = new FavoritePlayerView();
            tabPage2 = new TabPage();
            rangListView1 = new RangListView();
            tabAttendence = new TabPage();
            attendenceView1 = new AttendenceView();
            menuStrip1.SuspendLayout();
            tabs.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabAttendence.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, viewToolStripMenuItem, cmbRep });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem, saveSettingsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            resources.ApplyResources(openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            resources.ApplyResources(saveSettingsToolStripMenuItem, "saveSettingsToolStripMenuItem");
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { printToolStripMenuItem, prToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(printToolStripMenuItem, "printToolStripMenuItem");
            printToolStripMenuItem.Click += printToolStripMenuItem_Click;
            // 
            // prToolStripMenuItem
            // 
            prToolStripMenuItem.Name = "prToolStripMenuItem";
            resources.ApplyResources(prToolStripMenuItem, "prToolStripMenuItem");
            prToolStripMenuItem.Click += prToolStripMenuItem_Click;
            // 
            // cmbRep
            // 
            cmbRep.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRep.Name = "cmbRep";
            resources.ApplyResources(cmbRep, "cmbRep");
            cmbRep.Sorted = true;
            cmbRep.SelectedIndexChanged += cmbRep_SelectedIndexChanged;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage1);
            tabs.Controls.Add(tabPage2);
            tabs.Controls.Add(tabAttendence);
            resources.ApplyResources(tabs, "tabs");
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(favoritePlayerView1);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // favoritePlayerView1
            // 
            resources.ApplyResources(favoritePlayerView1, "favoritePlayerView1");
            favoritePlayerView1.Name = "favoritePlayerView1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(rangListView1);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // rangListView1
            // 
            resources.ApplyResources(rangListView1, "rangListView1");
            rangListView1.Name = "rangListView1";
            // 
            // tabAttendence
            // 
            tabAttendence.Controls.Add(attendenceView1);
            resources.ApplyResources(tabAttendence, "tabAttendence");
            tabAttendence.Name = "tabAttendence";
            tabAttendence.UseVisualStyleBackColor = true;
            // 
            // attendenceView1
            // 
            resources.ApplyResources(attendenceView1, "attendenceView1");
            attendenceView1.Name = "attendenceView1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabs);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Shown += MainForm_Show;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabAttendence.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripComboBox cmbRep;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private TabControl tabs;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabPage tabAttendence;
        private AttendenceView attendenceView1;
        private RangListView rangListView1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem prToolStripMenuItem;
        private FavoritePlayerView favoritePlayerView1;
    }
}