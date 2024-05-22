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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            cmbRep = new ToolStripComboBox();
            tabs = new TabControl();
            tabPage1 = new TabPage();
            favoritePlayerView1 = new FavoritePlayerView();
            tabPage2 = new TabPage();
            panelPlayersRank = new FlowLayoutPanel();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, cmbRep });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(887, 27);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem, saveSettingsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(61, 23);
            toolStripMenuItem1.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            openSettingsToolStripMenuItem.Size = new Size(148, 22);
            openSettingsToolStripMenuItem.Text = "Open Settings";
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new Size(148, 22);
            saveSettingsToolStripMenuItem.Text = "Save Settings";
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // cmbRep
            // 
            cmbRep.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRep.Name = "cmbRep";
            cmbRep.Size = new Size(106, 23);
            cmbRep.Sorted = true;
            cmbRep.SelectedIndexChanged += cmbRep_SelectedIndexChanged;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage1);
            tabs.Controls.Add(tabPage2);
            tabs.Controls.Add(tabAttendence);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 27);
            tabs.Margin = new Padding(2);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(887, 575);
            tabs.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(favoritePlayerView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(879, 547);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "FavoritePlayers";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // favoritePlayerView1
            // 
            favoritePlayerView1.Location = new Point(41, 13);
            favoritePlayerView1.Name = "favoritePlayerView1";
            favoritePlayerView1.Size = new Size(769, 529);
            favoritePlayerView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelPlayersRank);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(879, 547);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Player ranks";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelPlayersRank
            // 
            panelPlayersRank.Location = new Point(277, 33);
            panelPlayersRank.Margin = new Padding(2);
            panelPlayersRank.Name = "panelPlayersRank";
            panelPlayersRank.Size = new Size(326, 304);
            panelPlayersRank.TabIndex = 0;
            // 
            // tabAttendence
            // 
            tabAttendence.Controls.Add(attendenceView1);
            tabAttendence.Location = new Point(4, 24);
            tabAttendence.Margin = new Padding(2);
            tabAttendence.Name = "tabAttendence";
            tabAttendence.Padding = new Padding(2);
            tabAttendence.Size = new Size(879, 547);
            tabAttendence.TabIndex = 2;
            tabAttendence.Text = "Attendence";
            tabAttendence.UseVisualStyleBackColor = true;
            // 
            // attendenceView1
            // 
            attendenceView1.Location = new Point(8, 5);
            attendenceView1.Name = "attendenceView1";
            attendenceView1.Size = new Size(863, 521);
            attendenceView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 602);
            Controls.Add(tabs);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += MainForm_Load;
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
        private FlowLayoutPanel panelPlayersRank;
        private TabPage tabAttendence;
        private FavoritePlayerView favoritePlayerView1;
        private AttendenceView attendenceView1;
    }
}