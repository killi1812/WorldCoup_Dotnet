using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGui
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //TODO check if the file exists
            //then don't show
            //else show
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //TODO submit data from form to FootbalData for saving the settings
            var form = new MainForm();
            form.Show();
            Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
