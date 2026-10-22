namespace Ex05_WindowsUI
{
    partial class GameSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Button buttonStart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.labelCols = new System.Windows.Forms.Label();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();

            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Text = "Players:";

            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(22, 38);
            this.labelPlayer1.Text = "Player 1:";

            this.textBoxPlayer1.Location = new System.Drawing.Point(122, 35);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(121, 22);

            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(25, 69);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.CheckedChanged +=
                new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);

            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(122, 67);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(121, 22);
            this.textBoxPlayer2.Text = "[Computer]";

            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 110);
            this.labelBoardSize.Text = "Board Size:";

            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(22, 140);
            this.labelRows.Text = "Rows:";

            this.numericUpDownRows.Location = new System.Drawing.Point(72, 138);
            this.numericUpDownRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            this.numericUpDownRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownRows.Value = new decimal(new int[] { 4, 0, 0, 0 });

            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(142, 140);
            this.labelCols.Text = "Cols:";

            this.numericUpDownCols.Location = new System.Drawing.Point(192, 138);
            this.numericUpDownCols.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            this.numericUpDownCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(50, 22);
            this.numericUpDownCols.Value = new decimal(new int[] { 4, 0, 0, 0 });

            this.buttonStart.Location = new System.Drawing.Point(15, 180);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(228, 30);
            this.buttonStart.Text = "Start!";
            this.buttonStart.Click +=
                new System.EventHandler(this.buttonStart_Click);

            this.ClientSize = new System.Drawing.Size(262, 230);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
