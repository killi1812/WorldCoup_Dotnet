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
            pnlDragIgraci.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 41);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 0;
            label1.Text = "Omiljena Reprezentacija";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(195, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pnlDragOmiljeniIgraci
            // 
            pnlDragOmiljeniIgraci.Location = new Point(55, 114);
            pnlDragOmiljeniIgraci.Name = "pnlDragOmiljeniIgraci";
            pnlDragOmiljeniIgraci.Size = new Size(195, 239);
            pnlDragOmiljeniIgraci.TabIndex = 5;
            // 
            // pnlDragIgraci
            // 
            pnlDragIgraci.Controls.Add(Igrac);
            pnlDragIgraci.Location = new Point(341, 114);
            pnlDragIgraci.Name = "pnlDragIgraci";
            pnlDragIgraci.Size = new Size(195, 239);
            pnlDragIgraci.TabIndex = 6;
            // 
            // Igrac
            // 
            Igrac.Anchor = AnchorStyles.None;
            Igrac.Location = new Point(3, 3);
            Igrac.Name = "Igrac";
            Igrac.Size = new Size(89, 23);
            Igrac.TabIndex = 0;
            Igrac.Text = "Igrac";
            Igrac.UseVisualStyleBackColor = true;
            Igrac.Click += Igrac_Click;
            Igrac.MouseDown += Igrac_MouseDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 86);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 7;
            label5.Text = "Omiljeni Igraci";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(341, 86);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 8;
            label6.Text = "Ostali Igraci";
            // 
            // panel1
            // 
            panel1.Location = new Point(55, 404);
            panel1.Name = "panel1";
            panel1.Size = new Size(481, 142);
            panel1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 376);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 0;
            label2.Text = "Detalji Igraca";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 584);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pnlDragIgraci);
            Controls.Add(pnlDragOmiljeniIgraci);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            pnlDragIgraci.ResumeLayout(false);
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
    }
}