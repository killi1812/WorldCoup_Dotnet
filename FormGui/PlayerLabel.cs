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
        }

        public string Name { get; private set; }
        public bool Captain { get; private set; }
        public bool Favorite { get; private set; } = false;
        public int Number { get; private set; }
        public string picture {  get; private set; }
        public string text { get; private set; }

        public void setFavorite(bool favorite)
        {
            Favorite = favorite;
            pictureBox1.Visible = Favorite;
        }
        public void setPicture(string path)
        {
            //TODO do stuff w picture

            throw new NotImplementedException();
        }

        private void evRedirect(object obj, MouseEventArgs args)
        {
           //TODO trigger Mousedown event na ovjo formi
        }

    }
}
