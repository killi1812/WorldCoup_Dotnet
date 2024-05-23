namespace FormGui
{
    public partial class PlayerLabel : UserControl
    {
        public PlayerLabel(string name, int number, bool captain = false) : this(name, number, captain, "")
        {

        }

        public PlayerLabel(string name, int number, bool captain, string text)
        {
            InitializeComponent();
            Name = name;
            Number = number;
            Captain = captain;
            label1.Text = $"{Name} {Number} {(Captain ? "C" : "")} {text}";
            pictureBox1.Visible = Favorite;
            pictureBox2.Visible = true;
        }

        public string Name { get; private set; }
        public bool Captain { get; private set; }
        public bool Favorite { get; private set; } = false;
        public int Number { get; private set; }
        public string text { get; private set; }

        public void setFavorite(bool favorite)
        {
            Favorite = favorite;
            pictureBox1.Visible = Favorite;
            this.Width = label1.Width + pictureBox2.Width + pictureBox1.Width + 10;
        }
        public void LoadPicture(string path)
        {
            //TODO load picture if exists
            throw new NotImplementedException();
        }
        private void addPicture()
        {
            FileDialog fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //TODO save picture for local path 
                pictureBox2.ImageLocation = fileDialog.FileName;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            var args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Left)
            {
                this.OnMouseDown(args);
            }
            else if (args.Button == MouseButtons.Right)
            {
                var location = this.PointToScreen(args.Location);
                contextMenuStrip1.Show(location);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Left)
            {
                this.OnMouseDown(args);
            }
            else if (args.Button == MouseButtons.Right)
            {
                var location = this.PointToScreen(args.Location);
                contextMenuStrip1.Show(location);
            }
        }

        private void PlayerLabel_MouseDown(object sender, MouseEventArgs e)
        {
            var args = e;
            if (args.Button == MouseButtons.Right)
            {
                var location = this.PointToScreen(args.Location);
                contextMenuStrip1.Show(location);
            }
        }

        private void addPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPicture();
        }
    }
}
