namespace FormGui
{
    partial class SettingsForm
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
            groupLang = new GroupBox();
            btnEng = new RadioButton();
            btnHrv = new RadioButton();
            groupGender = new GroupBox();
            btnWoman = new RadioButton();
            btnMan = new RadioButton();
            Save = new Button();
            Cancel = new Button();
            groupLang.SuspendLayout();
            groupGender.SuspendLayout();
            SuspendLayout();
            // 
            // groupLang
            // 
            groupLang.Controls.Add(btnEng);
            groupLang.Controls.Add(btnHrv);
            groupLang.Location = new Point(42, 40);
            groupLang.Name = "groupLang";
            groupLang.Size = new Size(200, 100);
            groupLang.TabIndex = 0;
            groupLang.TabStop = false;
            groupLang.Text = "Language";
            // 
            // btnEng
            // 
            btnEng.AutoSize = true;
            btnEng.Location = new Point(20, 35);
            btnEng.Name = "btnEng";
            btnEng.Size = new Size(63, 19);
            btnEng.TabIndex = 1;
            btnEng.Text = "English";
            btnEng.UseVisualStyleBackColor = true;
            btnEng.CheckedChanged += Language_CheckedChanged;
            // 
            // btnHrv
            // 
            btnHrv.AutoSize = true;
            btnHrv.Checked = true;
            btnHrv.Location = new Point(20, 63);
            btnHrv.Name = "btnHrv";
            btnHrv.Size = new Size(70, 19);
            btnHrv.TabIndex = 0;
            btnHrv.TabStop = true;
            btnHrv.Text = "Croatian";
            btnHrv.UseVisualStyleBackColor = true;
            btnHrv.CheckedChanged += Language_CheckedChanged;
            // 
            // groupGender
            // 
            groupGender.Controls.Add(btnWoman);
            groupGender.Controls.Add(btnMan);
            groupGender.Location = new Point(248, 40);
            groupGender.Name = "groupGender";
            groupGender.Size = new Size(200, 100);
            groupGender.TabIndex = 2;
            groupGender.TabStop = false;
            groupGender.Text = "Gender";
            // 
            // btnWoman
            // 
            btnWoman.AutoSize = true;
            btnWoman.Location = new Point(24, 63);
            btnWoman.Name = "btnWoman";
            btnWoman.Size = new Size(75, 19);
            btnWoman.TabIndex = 1;
            btnWoman.TabStop = true;
            btnWoman.Text = "Woman's";
            btnWoman.UseVisualStyleBackColor = true;
            btnWoman.CheckedChanged += LeagueGender_SelectedIndexChanged;
            // 
            // btnMan
            // 
            btnMan.AutoSize = true;
            btnMan.Location = new Point(25, 35);
            btnMan.Name = "btnMan";
            btnMan.Size = new Size(57, 19);
            btnMan.TabIndex = 0;
            btnMan.TabStop = true;
            btnMan.Text = "Man's";
            btnMan.UseVisualStyleBackColor = true;
            btnMan.CheckedChanged += LeagueGender_SelectedIndexChanged;
            // 
            // Save
            // 
            Save.BackColor = SystemColors.ControlLightLight;
            Save.DialogResult = DialogResult.OK;
            Save.Location = new Point(167, 188);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 3;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = false;
            Save.Click += Save_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(248, 188);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 4;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = Save;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel;
            ClientSize = new Size(490, 223);
            Controls.Add(Cancel);
            Controls.Add(Save);
            Controls.Add(groupGender);
            Controls.Add(groupLang);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            Load += Settings_Load;
            groupLang.ResumeLayout(false);
            groupLang.PerformLayout();
            groupGender.ResumeLayout(false);
            groupGender.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupLang;
        private RadioButton btnEng;
        private RadioButton btnHrv;
        private GroupBox groupGender;
        private RadioButton btnWoman;
        private RadioButton btnMan;
        private Button Save;
        private Button Cancel;
    }
}