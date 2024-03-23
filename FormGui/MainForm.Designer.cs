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
            label1 = new Label();
            comboBox1 = new ComboBox();
            pnlDragOmiljeniIgraci = new FlowLayoutPanel();
            pnlDragIgraci = new FlowLayoutPanel();
            Igrac = new Button();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            menuStrip1 = new MenuStrip();
            cmbRep = new ToolStripComboBox();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openSettingsToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            pnlDragIgraci.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 24);
            label1.Name = "label1";
            label1.Size = new Size(171, 20);
            label1.TabIndex = 0;
            label1.Text = "Omiljena Reprezentacija";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 48);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pnlDragOmiljeniIgraci
            // 
            pnlDragOmiljeniIgraci.Location = new Point(59, 119);
            pnlDragOmiljeniIgraci.Margin = new Padding(3, 4, 3, 4);
            pnlDragOmiljeniIgraci.Name = "pnlDragOmiljeniIgraci";
            pnlDragOmiljeniIgraci.Size = new Size(223, 319);
            pnlDragOmiljeniIgraci.TabIndex = 5;
            // 
            // pnlDragIgraci
            // 
            pnlDragIgraci.Controls.Add(Igrac);
            pnlDragIgraci.Location = new Point(425, 84);
            pnlDragIgraci.Margin = new Padding(3, 4, 3, 4);
            pnlDragIgraci.Name = "pnlDragIgraci";
            pnlDragIgraci.Size = new Size(223, 319);
            pnlDragIgraci.TabIndex = 6;
            // 
            // Igrac
            // 
            Igrac.Anchor = AnchorStyles.None;
            Igrac.Location = new Point(3, 4);
            Igrac.Margin = new Padding(3, 4, 3, 4);
            Igrac.Name = "Igrac";
            Igrac.Size = new Size(102, 31);
            Igrac.TabIndex = 0;
            Igrac.Text = "Igrac";
            Igrac.UseVisualStyleBackColor = true;
            Igrac.Click += Igrac_Click;
            Igrac.MouseDown += Igrac_MouseDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 95);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 7;
            label5.Text = "Omiljeni Igraci";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(203, 32);
            label6.Name = "label6";
            label6.Size = new Size(88, 20);
            label6.TabIndex = 8;
            label6.Text = "Ostali Igraci";
            // 
            // panel1
            // 
            panel1.Location = new Point(59, 510);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 189);
            panel1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(247, 465);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 0;
            label2.Text = "Detalji Igraca";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(361, 38);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(699, 765);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pnlDragIgraci);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(pnlDragOmiljeniIgraci);
            tabPage1.Controls.Add(label6);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(691, 732);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(691, 732);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, cmbRep });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1238, 32);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // cmbRep
            // 
            cmbRep.Name = "cmbRep";
            cmbRep.Size = new Size(121, 28);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSettingsToolStripMenuItem, saveSettingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 28);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            openSettingsToolStripMenuItem.Size = new Size(224, 26);
            openSettingsToolStripMenuItem.Text = "Open Settings";
            openSettingsToolStripMenuItem.Click += openSettingsToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new Size(224, 26);
            saveSettingsToolStripMenuItem.Text = "Save Settings";
            saveSettingsToolStripMenuItem.Click += saveSettingsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 883);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            Shown += MainForm_Show;
            pnlDragIgraci.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private FlowLayoutPanel pnlDragOmiljeniIgraci;
        private FlowLayoutPanel pnlDragIgraci;
        private Label label5;
        private Label label6;
        private Button Igrac;
        private Panel panel1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem openSettingsToolStripMenuItem;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private ToolStripComboBox cmbRep;
    }
}