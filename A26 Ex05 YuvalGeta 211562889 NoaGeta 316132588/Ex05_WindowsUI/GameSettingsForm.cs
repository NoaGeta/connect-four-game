using System;
using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_WindowsUI
{
    public partial class GameSettingsForm : Form
    {
        private readonly GameSettings r_Settings;

        public GameSettingsForm()
        {
            InitializeComponent();
            r_Settings = new GameSettings();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = string.Empty;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            r_Settings.Rows = (int)numericUpDownRows.Value;
            r_Settings.Cols = (int)numericUpDownCols.Value;
            r_Settings.Player1Name = textBoxPlayer1.Text;
            r_Settings.Player2Name = textBoxPlayer2.Text;
            r_Settings.IsAgainstComputer = !checkBoxPlayer2.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        public GameSettings Settings
        {
            get
            {
                return r_Settings;
            }
        }
    }
}
