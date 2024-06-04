namespace FormGui
{
    partial class FavoritePlayerView
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
            pnlIgraci = new FlowLayoutPanel();
            BtnAllLeft = new Button();
            pnlFavorite = new FlowLayoutPanel();
            btnOneLeft = new Button();
            btnAllRight = new Button();
            btnSelectedRight = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // pnlIgraci
            // 
            pnlIgraci.AutoScroll = true;
            pnlIgraci.BorderStyle = BorderStyle.Fixed3D;
            pnlIgraci.Dock = DockStyle.Left;
            pnlIgraci.FlowDirection = FlowDirection.TopDown;
            pnlIgraci.Location = new Point(0, 0);
            pnlIgraci.Name = "pnlIgraci";
            pnlIgraci.Size = new Size(237, 529);
            pnlIgraci.TabIndex = 7;
            pnlIgraci.WrapContents = false;
            // 
            // BtnAllLeft
            // 
            BtnAllLeft.Location = new Point(346, 294);
            BtnAllLeft.Name = "BtnAllLeft";
            BtnAllLeft.Size = new Size(75, 23);
            BtnAllLeft.TabIndex = 12;
            BtnAllLeft.Text = "<<";
            BtnAllLeft.UseVisualStyleBackColor = true;
            BtnAllLeft.Click += BtnAllLeft_Click;
            // 
            // pnlFavorite
            // 
            pnlFavorite.AutoScroll = true;
            pnlFavorite.BorderStyle = BorderStyle.Fixed3D;
            pnlFavorite.Dock = DockStyle.Right;
            pnlFavorite.FlowDirection = FlowDirection.TopDown;
            pnlFavorite.Location = new Point(527, 0);
            pnlFavorite.Name = "pnlFavorite";
            pnlFavorite.Size = new Size(242, 529);
            pnlFavorite.TabIndex = 8;
            pnlFavorite.WrapContents = false;
            // 
            // btnOneLeft
            // 
            btnOneLeft.Location = new Point(346, 265);
            btnOneLeft.Name = "btnOneLeft";
            btnOneLeft.Size = new Size(75, 23);
            btnOneLeft.TabIndex = 11;
            btnOneLeft.Text = "<";
            btnOneLeft.UseVisualStyleBackColor = true;
            btnOneLeft.Click += btnOneLeft_Click;
            // 
            // btnAllRight
            // 
            btnAllRight.Location = new Point(346, 183);
            btnAllRight.Name = "btnAllRight";
            btnAllRight.Size = new Size(75, 23);
            btnAllRight.TabIndex = 9;
            btnAllRight.Text = ">>";
            btnAllRight.UseVisualStyleBackColor = true;
            btnAllRight.Click += btnAllRight_Click;
            // 
            // btnSelectedRight
            // 
            btnSelectedRight.Location = new Point(346, 212);
            btnSelectedRight.Name = "btnSelectedRight";
            btnSelectedRight.Size = new Size(75, 23);
            btnSelectedRight.TabIndex = 10;
            btnSelectedRight.Text = ">";
            btnSelectedRight.UseVisualStyleBackColor = true;
            btnSelectedRight.Click += btnSelectedRight_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(427, 10);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // FavoritePlayerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pnlIgraci);
            Controls.Add(BtnAllLeft);
            Controls.Add(pnlFavorite);
            Controls.Add(btnOneLeft);
            Controls.Add(btnAllRight);
            Controls.Add(btnSelectedRight);
            Name = "FavoritePlayerView";
            Size = new Size(769, 529);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlIgraci;
        private Button BtnAllLeft;
        private FlowLayoutPanel pnlFavorite;
        private Button btnOneLeft;
        private Button btnAllRight;
        private Button btnSelectedRight;
        private Label label1;
    }
}
