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
    public partial class Error : Form
    {
        private string _message;
        public Error(string message)
        {
            Icon = SystemIcons.Error;
            _message = message;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            lblMsg.Text = _message;
        }
    }
}
