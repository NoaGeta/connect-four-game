using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_WindowsUI
{
    public partial class GameForm : Form
    {
        private const int k_ButtonSize = 60;
        private const int k_ButtonMargin = 10;
        private const int k_TopButtonsHeight = 30;
        private const int k_ScoreLabelHeight = 30;

        private readonly GameManager r_GameManager;
        private Button[,] m_ButtonsMatrix;
        private Button[] m_TopRowButtons;
        private Label m_LabelScore;

        public GameForm(GameManager i_GameManager)
        {
            InitializeComponent();
            r_GameManager = i_GameManager;

            initializeBoardGrid();
        }

        private void initializeBoardGrid()
        {
            int rows = r_GameManager.GameBoard.Rows;
            int cols = r_GameManager.GameBoard.Cols;

            m_ButtonsMatrix = new Button[rows, cols];
            m_TopRowButtons = new Button[cols];

            createTopButtonsRow(cols);
            createBoardButtons(rows, cols);
            createScoreLabel();

            ClientSize = new Size(
                (cols * (k_ButtonSize + 5)) + (k_ButtonMargin * 2),
                (rows * (k_ButtonSize + 5)) + k_TopButtonsHeight + k_ScoreLabelHeight + 40);
        }

        private void createTopButtonsRow(int i_Cols)
        {
            for (int col = 0; col < i_Cols; col++)
            {
                Button topButton = new Button();
                topButton.Size = new Size(k_ButtonSize, k_TopButtonsHeight);
                topButton.Location = new Point(
                    k_ButtonMargin + (col * (k_ButtonSize + 5)),
                    k_ButtonMargin);
                topButton.Text = (col + 1).ToString();
                topButton.Tag = col;
                topButton.Click += topRowButton_Click;

                Controls.Add(topButton);
                m_TopRowButtons[col] = topButton;
            }
        }

        private void createBoardButtons(int i_Rows, int i_Cols)
        {
            for (int row = 0; row < i_Rows; row++)
            {
                for (int col = 0; col < i_Cols; col++)
                {
                    Button boardCell = new Button();
                    boardCell.Size = new Size(k_ButtonSize, k_ButtonSize);
                    boardCell.Location = new Point(
                        k_ButtonMargin + (col * (k_ButtonSize + 5)),
                        k_ButtonMargin + k_TopButtonsHeight + 10 + (row * (k_ButtonSize + 5)));
                    boardCell.Enabled = false;

                    Controls.Add(boardCell);
                    m_ButtonsMatrix[row, col] = boardCell;
                }
            }
        }

        private void createScoreLabel()
        {
            m_LabelScore = new Label();
            m_LabelScore.AutoSize = true;
            updateScoreLabel();

            m_LabelScore.Location = new Point(
                k_ButtonMargin,
                ClientSize.Height - k_ScoreLabelHeight);

            Controls.Add(m_LabelScore);
        }

        private void topRowButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int selectedColumn = (int)clickedButton.Tag;

            processMove(selectedColumn);
        }

        private void processMove(int i_Column)
        {
            int landedRow;
            bool isWin;
            bool isTie;
            eCell actingPlayer = r_GameManager.CurrPlayer;

            if (r_GameManager.PlayTurn(i_Column, out landedRow, out isWin, out isTie))
            {
                updateButtonInUi(landedRow, i_Column, actingPlayer);

                if (isWin)
                {
                    handleGameEnd(string.Format("{0} Won!!", r_GameManager.CurrentPlayerObject.Name));
                }
                else if (isTie)
                {
                    handleGameEnd("Tie!!");
                }
                else if (r_GameManager.Player2.IsComputer && r_GameManager.CurrPlayer == eCell.Player2)
                {
                    processMove(r_GameManager.GetComputerMove());
                }
            }
        }

        private void updateButtonInUi(int i_Row, int i_Column, eCell i_ActingPlayer)
        {
            m_ButtonsMatrix[i_Row, i_Column].Text =
                i_ActingPlayer == eCell.Player1 ? "X" : "O";

            if (r_GameManager.GameBoard.IsColumnFull(i_Column))
            {
                m_TopRowButtons[i_Column].Enabled = false;
            }
        }

        private void updateScoreLabel()
        {
            m_LabelScore.Text = string.Format(
                "{0}: {1}    {2}: {3}",
                r_GameManager.Player1.Name,
                r_GameManager.Player1.Score,
                r_GameManager.Player2.Name,
                r_GameManager.Player2.Score);
        }

        private void handleGameEnd(string i_Message)
        {
            updateScoreLabel();

            string message = string.Format(
                "{0}{1}Another Round?",
                i_Message,
                Environment.NewLine);

            DialogResult result = MessageBox.Show(
                message,
                "4 in a Row !!",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                r_GameManager.ResetGame();
                resetUiBoard();
            }
            else
            {
                Close();
            }
        }

        private void resetUiBoard()
        {
            foreach (Button button in m_ButtonsMatrix)
            {
                button.Text = string.Empty;
            }

            foreach (Button button in m_TopRowButtons)
            {
                button.Enabled = true;
            }
        }
    }
}
