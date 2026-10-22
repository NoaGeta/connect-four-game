using System;

namespace Ex05_Logic
{
    public class Board
    {
        private readonly int r_Rows;
        private readonly int r_Cols;
        private eCell[,] m_Matrix;

        public Board(int i_Rows, int i_Cols)
        {
            r_Rows = i_Rows;
            r_Cols = i_Cols;
            m_Matrix = new eCell[r_Rows, r_Cols];
            initializeBoard();
        }

        public int Rows
        {
            get { return r_Rows; }
        }

        public int Cols
        {
            get { return r_Cols; }
        }

        private void initializeBoard()
        {
            for (int row = 0; row < r_Rows; row++)
            {
                for (int col = 0; col < r_Cols; col++)
                {
                    m_Matrix[row, col] = eCell.Empty;
                }
            }
        }

        public bool IsColumnFull(int i_Col)
        {
            return m_Matrix[0, i_Col] != eCell.Empty;
        }

        public int GetNextAvailableRow(int i_Col)
        {
            int availableRow = -1;

            for (int row = r_Rows - 1; row >= 0; row--)
            {
                if (m_Matrix[row, i_Col] == eCell.Empty)
                {
                    availableRow = row;
                    break;
                }
            }

            return availableRow;
        }

        public void SetCellValue(int i_Row, int i_Col, eCell i_CellValue)
        {
            m_Matrix[i_Row, i_Col] = i_CellValue;
        }

        public eCell GetCellValue(int i_Row, int i_Col)
        {
            return m_Matrix[i_Row, i_Col];
        }

        public bool CheckForWin(int i_Row, int i_Col, eCell i_Player)
        {
            return
                checkDirection(i_Row, i_Col, 1, 0, i_Player) ||
                checkDirection(i_Row, i_Col, 0, 1, i_Player) ||
                checkDirection(i_Row, i_Col, 1, 1, i_Player) ||
                checkDirection(i_Row, i_Col, 1, -1, i_Player);
        }

        private bool checkDirection(
            int i_Row,
            int i_Col,
            int i_RowStep,
            int i_ColStep,
            eCell i_Player)
        {
            int count = 1;

            count += countInDirection(i_Row, i_Col, i_RowStep, i_ColStep, i_Player);
            count += countInDirection(i_Row, i_Col, -i_RowStep, -i_ColStep, i_Player);

            return count >= 4;
        }

        private int countInDirection(
            int i_Row,
            int i_Col,
            int i_RowStep,
            int i_ColStep,
            eCell i_Player)
        {
            int count = 0;
            int currentRow = i_Row + i_RowStep;
            int currentCol = i_Col + i_ColStep;

            while (
                currentRow >= 0 &&
                currentRow < r_Rows &&
                currentCol >= 0 &&
                currentCol < r_Cols &&
                m_Matrix[currentRow, currentCol] == i_Player)
            {
                count++;
                currentRow += i_RowStep;
                currentCol += i_ColStep;
            }

            return count;
        }

        public bool IsBoardFull()
        {
            for (int col = 0; col < r_Cols; col++)
            {
                if (m_Matrix[0, col] == eCell.Empty)
                {
                    return false;
                }
            }

            return true;
        }

        public void ClearBoard()
        {
            initializeBoard();
        }
    }
}
