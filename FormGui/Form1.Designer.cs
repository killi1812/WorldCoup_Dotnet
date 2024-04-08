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
            pnlIgraci = new FlowLayoutPanel();
            pnlFavorite = new FlowLayoutPanel();
            btnAllRight = new Button();
            btnSelectedRight = new Button();
            BtnAllLeft = new Button();
            btnOneLeft = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            cmbRep = new ToolStripComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIgraci
            // 
            pnlIgraci.AutoScroll = true;
            pnlIgraci.BorderStyle = BorderStyle.Fixed3D;
            pnlIgraci.FlowDirection = FlowDirection.TopDown;
            pnlIgraci.Location = new Point(165, 117);
            pnlIgraci.Name = "pnlIgraci";
            pnlIgraci.Size = new Size(175, 426);
            pnlIgraci.TabIndex = 0;
            pnlIgraci.WrapContents = false;
            // 
            // pnlFavorite
            // 
            pnlFavorite.AutoScroll = true;
            pnlFavorite.BorderStyle = BorderStyle.Fixed3D;
            pnlFavorite.FlowDirection = FlowDirection.TopDown;
            pnlFavorite.Location = new Point(537, 117);
            pnlFavorite.Name = "pnlFavorite";
            pnlFavorite.Size = new Size(175, 426);
            pnlFavorite.TabIndex = 1;
            pnlFavorite.WrapContents = false;
            // 
            // btnAllRight
            // 
            btnAllRight.Location = new Point(400, 225);
            btnAllRight.Name = "btnAllRight";
            btnAllRight.Size = new Size(75, 23);
            btnAllRight.TabIndex = 2;
            btnAllRight.Text = ">>";
            btnAllRight.UseVisualStyleBackColor = true;
            btnAllRight.Click += btnAllRight_Click;
            // 
            // btnSelectedRight
            // 
            btnSelectedRight.Location = new Point(400, 254);
            btnSelectedRight.Name = "btnSelectedRight";
            btnSelectedRight.Size = new Size(75, 23);
            btnSelectedRight.TabIndex = 4;
            btnSelectedRight.Text = ">";
            btnSelectedRight.UseVisualStyleBackColor = true;
            btnSelectedRight.Click += btnSelectedRight_Click;
            // 
            // BtnAllLeft
            // 
            BtnAllLeft.Location = new Point(400, 336);
            BtnAllLeft.Name = "BtnAllLeft";
            BtnAllLeft.Size = new Size(75, 23);
            BtnAllLeft.TabIndex = 6;
            BtnAllLeft.Text = "<<";
            BtnAllLeft.UseVisualStyleBackColor = true;
            BtnAllLeft.Click += BtnAllLeft_Click;
            // 
            // btnOneLeft
            // 
            btnOneLeft.Location = new Point(400, 307);
            btnOneLeft.Name = "btnOneLeft";
            btnOneLeft.Size = new Size(75, 23);
            btnOneLeft.TabIndex = 5;
            btnOneLeft.Text = "<";
            btnOneLeft.UseVisualStyleBackColor = true;
            btnOneLeft.Click += btnOneLeft_Click;
            // 
            // menuStrip1
            // 
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
            cmbRep.Click += cmbRep_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 602);
            Controls.Add(BtnAllLeft);
            Controls.Add(btnOneLeft);
            Controls.Add(btnSelectedRight);
            Controls.Add(btnAllRight);
            Controls.Add(pnlFavorite);
            Controls.Add(pnlIgraci);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += MainForm_Load;
            Shown += MainForm_Show;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlIgraci;
        private FlowLayoutPanel pnlFavorite;
        private Button btnAllRight;
        private Button btnSelectedRight;
        private Button BtnAllLeft;
        private Button btnOneLeft;
        private MenuStrip menuStrip1;
        private ToolStripComboBox cmbRep;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
    }
}