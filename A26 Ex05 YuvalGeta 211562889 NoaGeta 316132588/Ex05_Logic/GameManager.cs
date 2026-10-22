using System;

namespace Ex05_Logic
{
    public class GameManager
    {
        private static readonly Random sr_RandomGenerator = new Random();

        private readonly Board r_GameBoard;
        private readonly Player r_Player1;
        private readonly Player r_Player2;

        private eCell m_CurrPlayer;
        private bool m_IsGameOver;

        public GameManager(
            int i_Rows,
            int i_Cols,
            string i_Player1Name,
            string i_Player2Name,
            bool i_IsAgainstMachine)
        {
            r_GameBoard = new Board(i_Rows, i_Cols);
            r_Player1 = new Player(i_Player1Name, false);
            r_Player2 = new Player(i_Player2Name, i_IsAgainstMachine);
            m_CurrPlayer = eCell.Player1;
            m_IsGameOver = false;
        }

        public Board GameBoard
        {
            get { return r_GameBoard; }
        }

        public Player Player1
        {
            get { return r_Player1; }
        }

        public Player Player2
        {
            get { return r_Player2; }
        }

        public eCell CurrPlayer
        {
            get { return m_CurrPlayer; }
        }

        public Player CurrentPlayerObject
        {
            get
            {
                return m_CurrPlayer == eCell.Player1 ? r_Player1 : r_Player2;
            }
        }

        public bool IsGameOver
        {
            get { return m_IsGameOver; }
        }

        public bool PlayTurn(
            int i_Col,
            out int o_LandedRow,
            out bool o_IsWin,
            out bool o_IsTie)
        {
            bool moveSuccessful = false;

            o_LandedRow = -1;
            o_IsWin = false;
            o_IsTie = false;

            if (!r_GameBoard.IsColumnFull(i_Col))
            {
                o_LandedRow = r_GameBoard.GetNextAvailableRow(i_Col);
                r_GameBoard.SetCellValue(o_LandedRow, i_Col, m_CurrPlayer);
                moveSuccessful = true;

                if (r_GameBoard.CheckForWin(o_LandedRow, i_Col, m_CurrPlayer))
                {
                    o_IsWin = true;
                    updateWinnerScore();
                    m_IsGameOver = true;
                }
                else if (r_GameBoard.IsBoardFull())
                {
                    o_IsTie = true;
                    m_IsGameOver = true;
                }
                else
                {
                    switchCurrentPlayer();
                }
            }

            return moveSuccessful;
        }

        public int GetComputerMove()
        {
            int boardCols = r_GameBoard.Cols;
            int[] availableColumns = new int[boardCols];
            int availableCount = 0;

            for (int col = 0; col < boardCols; col++)
            {
                if (!r_GameBoard.IsColumnFull(col))
                {
                    availableColumns[availableCount] = col;
                    availableCount++;
                }
            }

            return availableCount > 0
                ? availableColumns[sr_RandomGenerator.Next(availableCount)]
                : -1;
        }

        public void ResetGame()
        {
            r_GameBoard.ClearBoard();
            m_CurrPlayer = eCell.Player1;
            m_IsGameOver = false;
        }

        private void switchCurrentPlayer()
        {
            m_CurrPlayer =
                m_CurrPlayer == eCell.Player1
                    ? eCell.Player2
                    : eCell.Player1;
        }

        private void updateWinnerScore()
        {
            if (m_CurrPlayer == eCell.Player1)
            {
                r_Player1.Score++;
            }
            else
            {
                r_Player2.Score++;
            }
        }
    }
}
