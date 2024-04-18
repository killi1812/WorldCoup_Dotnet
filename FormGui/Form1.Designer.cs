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
            pnlIgraci = new FlowLayoutPanel();
            BtnAllLeft = new Button();
            pnlFavorite = new FlowLayoutPanel();
            btnOneLeft = new Button();
            btnAllRight = new Button();
            btnSelectedRight = new Button();
            tabPage2 = new TabPage();
            panelPlayersRank = new FlowLayoutPanel();
            tabAttendence = new TabPage();
            pnlRankAttendence = new FlowLayoutPanel();
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
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1267, 39);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem, saveSettingsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(92, 33);
            toolStripMenuItem1.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            openSettingsToolStripMenuItem.Size = new Size(227, 34);
            openSettingsToolStripMenuItem.Text = "Open Settings";
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new Size(227, 34);
            saveSettingsToolStripMenuItem.Text = "Save Settings";
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // cmbRep
            // 
            cmbRep.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRep.Name = "cmbRep";
            cmbRep.Size = new Size(150, 33);
            cmbRep.Sorted = true;
            cmbRep.SelectedIndexChanged += cmbRep_SelectedIndexChanged;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage1);
            tabs.Controls.Add(tabPage2);
            tabs.Controls.Add(tabAttendence);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 39);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(1267, 964);
            tabs.TabIndex = 8;
            tabs.SelectedIndexChanged += tabs_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnlIgraci);
            tabPage1.Controls.Add(BtnAllLeft);
            tabPage1.Controls.Add(pnlFavorite);
            tabPage1.Controls.Add(btnOneLeft);
            tabPage1.Controls.Add(btnAllRight);
            tabPage1.Controls.Add(btnSelectedRight);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1259, 926);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "FavoritePlayers";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlIgraci
            // 
            pnlIgraci.AutoScroll = true;
            pnlIgraci.BorderStyle = BorderStyle.Fixed3D;
            pnlIgraci.FlowDirection = FlowDirection.TopDown;
            pnlIgraci.Location = new Point(47, 37);
            pnlIgraci.Margin = new Padding(4, 5, 4, 5);
            pnlIgraci.Name = "pnlIgraci";
            pnlIgraci.Size = new Size(284, 789);
            pnlIgraci.TabIndex = 0;
            pnlIgraci.WrapContents = false;
            // 
            // BtnAllLeft
            // 
            BtnAllLeft.Location = new Point(432, 482);
            BtnAllLeft.Margin = new Padding(4, 5, 4, 5);
            BtnAllLeft.Name = "BtnAllLeft";
            BtnAllLeft.Size = new Size(107, 38);
            BtnAllLeft.TabIndex = 6;
            BtnAllLeft.Text = "<<";
            BtnAllLeft.UseVisualStyleBackColor = true;
            BtnAllLeft.Click += BtnAllLeft_Click;
            // 
            // pnlFavorite
            // 
            pnlFavorite.AutoScroll = true;
            pnlFavorite.BorderStyle = BorderStyle.Fixed3D;
            pnlFavorite.FlowDirection = FlowDirection.TopDown;
            pnlFavorite.Location = new Point(640, 37);
            pnlFavorite.Margin = new Padding(4, 5, 4, 5);
            pnlFavorite.Name = "pnlFavorite";
            pnlFavorite.Size = new Size(284, 789);
            pnlFavorite.TabIndex = 1;
            pnlFavorite.WrapContents = false;
            // 
            // btnOneLeft
            // 
            btnOneLeft.Location = new Point(432, 434);
            btnOneLeft.Margin = new Padding(4, 5, 4, 5);
            btnOneLeft.Name = "btnOneLeft";
            btnOneLeft.Size = new Size(107, 38);
            btnOneLeft.TabIndex = 5;
            btnOneLeft.Text = "<";
            btnOneLeft.UseVisualStyleBackColor = true;
            btnOneLeft.Click += btnOneLeft_Click;
            // 
            // btnAllRight
            // 
            btnAllRight.Location = new Point(432, 297);
            btnAllRight.Margin = new Padding(4, 5, 4, 5);
            btnAllRight.Name = "btnAllRight";
            btnAllRight.Size = new Size(107, 38);
            btnAllRight.TabIndex = 2;
            btnAllRight.Text = ">>";
            btnAllRight.UseVisualStyleBackColor = true;
            btnAllRight.Click += btnAllRight_Click;
            // 
            // btnSelectedRight
            // 
            btnSelectedRight.Location = new Point(432, 345);
            btnSelectedRight.Margin = new Padding(4, 5, 4, 5);
            btnSelectedRight.Name = "btnSelectedRight";
            btnSelectedRight.Size = new Size(107, 38);
            btnSelectedRight.TabIndex = 4;
            btnSelectedRight.Text = ">";
            btnSelectedRight.UseVisualStyleBackColor = true;
            btnSelectedRight.Click += btnSelectedRight_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelPlayersRank);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1259, 926);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Player ranks";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelPlayersRank
            // 
            panelPlayersRank.Location = new Point(396, 55);
            panelPlayersRank.Name = "panelPlayersRank";
            panelPlayersRank.Size = new Size(465, 506);
            panelPlayersRank.TabIndex = 0;
            // 
            // tabAttendence
            // 
            tabAttendence.Controls.Add(pnlRankAttendence);
            tabAttendence.Location = new Point(4, 34);
            tabAttendence.Name = "tabAttendence";
            tabAttendence.Padding = new Padding(3);
            tabAttendence.Size = new Size(1259, 926);
            tabAttendence.TabIndex = 2;
            tabAttendence.Text = "Attendence";
            tabAttendence.UseVisualStyleBackColor = true;
            // 
            // pnlRankAttendence
            // 
            pnlRankAttendence.Location = new Point(382, 78);
            pnlRankAttendence.Name = "pnlRankAttendence";
            pnlRankAttendence.Size = new Size(465, 506);
            pnlRankAttendence.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1267, 1003);
            Controls.Add(tabs);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
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
        private FlowLayoutPanel pnlIgraci;
        private Button BtnAllLeft;
        private FlowLayoutPanel pnlFavorite;
        private Button btnOneLeft;
        private Button btnAllRight;
        private Button btnSelectedRight;
        private FlowLayoutPanel panelPlayersRank;
        private TabPage tabAttendence;
        private FlowLayoutPanel pnlRankAttendence;
    }
}