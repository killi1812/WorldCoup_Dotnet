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
    //TODO ovo ostavlja zombije jao
    public partial class MainForm : Form
    {
        private Button _holdButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO save to txt dat
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pnlDragOmiljeniIgraci.AllowDrop = true;

        }

        private void Igrac_Click(object sender, EventArgs e)
        {
            //TODO detali igraca
            throw new NotImplementedException();
        }
        //TODO ovo je nesto neznam kj radi
        private void Igrac_MouseDown(object sender, MouseEventArgs e)
        {
            _holdButton = (Button)sender;
            pnlDragIgraci.Controls.Remove(_holdButton);
            
            pnlDragOmiljeniIgraci.DragDrop += (obj, e) =>
            {
                pnlDragOmiljeniIgraci.Controls.Add(_holdButton);
            };

            Controls.Add(_holdButton);
            _holdButton.BringToFront();
            _holdButton.MouseMove += (sender, e) =>
            {
                var point = PointToClient(MousePosition);
                point.X -= _holdButton.Width / 2;
                point.Y -= _holdButton.Height / 2;
                _holdButton.Location = point;
            };
        }
        private void igrac_MouseUp(object sender, MouseEventArgs e)
        {
            _holdButton = (Button)sender;
            pnlDragIgraci.Controls.Remove(_holdButton);
        }
    }
}
