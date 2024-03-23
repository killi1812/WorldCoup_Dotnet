namespace FormGui
{
    partial class Error
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
            btnOk = new Button();
            lblMsg = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(185, 92);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Location = new Point(12, 9);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(0, 20);
            lblMsg.TabIndex = 1;
            // 
            // Error
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 133);
            Controls.Add(lblMsg);
            Controls.Add(btnOk);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Error";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ErrorForm";
            Load += ErrorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Label lblMsg;
    }
}