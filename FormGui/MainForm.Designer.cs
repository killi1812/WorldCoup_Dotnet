namespace FormGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            cmbRep = new ToolStripComboBox();
            pnlIgraci = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, cmbRep });
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem, saveSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // openSettingsToolStripMenuItem
            // 
            resources.ApplyResources(openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            resources.ApplyResources(saveSettingsToolStripMenuItem, "saveSettingsToolStripMenuItem");
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // cmbRep
            // 
            resources.ApplyResources(cmbRep, "cmbRep");
            cmbRep.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRep.Name = "cmbRep";
            cmbRep.Sorted = true;
            cmbRep.SelectedIndexChanged += cmbRep_SelectedIndexChanged;
            // 
            // pnlIgraci
            // 
            resources.ApplyResources(pnlIgraci, "pnlIgraci");
            pnlIgraci.Name = "pnlIgraci";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlIgraci);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Load += MainForm_Load;
            Shown += MainForm_Show;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private ToolStripComboBox cmbRep;
        private FlowLayoutPanel pnlIgraci;
    }
}