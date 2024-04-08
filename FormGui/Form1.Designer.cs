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
            SuspendLayout();
            // 
            // pnlIgraci
            // 
            pnlIgraci.AutoScroll = true;
            pnlIgraci.BorderStyle = BorderStyle.Fixed3D;
            pnlIgraci.FlowDirection = FlowDirection.TopDown;
            pnlIgraci.Location = new Point(128, 12);
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
            pnlFavorite.Location = new Point(500, 12);
            pnlFavorite.Name = "pnlFavorite";
            pnlFavorite.Size = new Size(175, 426);
            pnlFavorite.TabIndex = 1;
            pnlFavorite.WrapContents = false;
            // 
            // btnAllRight
            // 
            btnAllRight.Location = new Point(363, 120);
            btnAllRight.Name = "btnAllRight";
            btnAllRight.Size = new Size(75, 23);
            btnAllRight.TabIndex = 2;
            btnAllRight.Text = ">>";
            btnAllRight.UseVisualStyleBackColor = true;
            btnAllRight.Click += btnAllRight_Click;
            // 
            // btnSelectedRight
            // 
            btnSelectedRight.Location = new Point(363, 149);
            btnSelectedRight.Name = "btnSelectedRight";
            btnSelectedRight.Size = new Size(75, 23);
            btnSelectedRight.TabIndex = 4;
            btnSelectedRight.Text = ">";
            btnSelectedRight.UseVisualStyleBackColor = true;
            btnSelectedRight.Click += btnSelectedRight_Click;
            // 
            // BtnAllLeft
            // 
            BtnAllLeft.Location = new Point(363, 231);
            BtnAllLeft.Name = "BtnAllLeft";
            BtnAllLeft.Size = new Size(75, 23);
            BtnAllLeft.TabIndex = 6;
            BtnAllLeft.Text = "<<";
            BtnAllLeft.UseVisualStyleBackColor = true;
            BtnAllLeft.Click += BtnAllLeft_Click;
            // 
            // btnOneLeft
            // 
            btnOneLeft.Location = new Point(363, 202);
            btnOneLeft.Name = "btnOneLeft";
            btnOneLeft.Size = new Size(75, 23);
            btnOneLeft.TabIndex = 5;
            btnOneLeft.Text = "<";
            btnOneLeft.UseVisualStyleBackColor = true;
            btnOneLeft.Click += btnOneLeft_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnAllLeft);
            Controls.Add(btnOneLeft);
            Controls.Add(btnSelectedRight);
            Controls.Add(btnAllRight);
            Controls.Add(pnlFavorite);
            Controls.Add(pnlIgraci);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlIgraci;
        private FlowLayoutPanel pnlFavorite;
        private Button btnAllRight;
        private Button btnSelectedRight;
        private Button BtnAllLeft;
        private Button btnOneLeft;
    }
}