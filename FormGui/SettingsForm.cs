using FootballData.ProjectSettings;
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
        private Settings _settings;
        public SettingsForm()
        {
            _settings = Settings.GetSettings();
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            btnEng.Checked = _settings.Values.Language == "en";
            btnHrv.Checked = _settings.Values.Language == "hr";

            btnMan.Checked = _settings.Values.LeagueGender == "men";
            btnWoman.Checked = _settings.Values.LeagueGender == "women";

        }

        private async void Save_Click(object sender, EventArgs e)
        {
            await _settings.SaveSettingsAsync();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Language_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _settings.Values.Language = rb.Name switch
            {
                "btnEng" => "en",
                "btnHrv" => "hr",
                _ => throw new NotImplementedException()
            };
        }

        private void LeagueGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _settings.Values.LeagueGender = rb.Name switch
            {
                "btnMan" => "men",
                "btnWoman" => "women",
                _ => throw new NotImplementedException()
            };
        }
    }
}
