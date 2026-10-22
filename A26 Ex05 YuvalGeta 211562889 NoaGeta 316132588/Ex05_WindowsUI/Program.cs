using System;
using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_WindowsUI
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameSettingsForm settingsForm = new GameSettingsForm();
            DialogResult dialogResult = settingsForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                GameSettings settings = settingsForm.Settings;

                GameManager gameManager = new GameManager(
                    settings.Rows,
                    settings.Cols,
                    settings.Player1Name,
                    settings.Player2Name,
                    settings.IsAgainstComputer);

                GameForm gameForm = new GameForm(gameManager);
                Application.Run(gameForm);
            }
        }
    }
}
