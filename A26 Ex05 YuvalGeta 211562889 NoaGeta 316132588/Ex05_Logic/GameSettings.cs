namespace Ex05_Logic
{
    public class GameSettings
    {
        private int m_Rows;
        private int m_Cols;
        private string m_Player1Name;
        private string m_Player2Name;
        private bool m_IsAgainstComputer;

        public GameSettings()
        {
        }

        public int Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }

        public int Cols
        {
            get { return m_Cols; }
            set { m_Cols = value; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
            set { m_Player1Name = value; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
            set { m_Player2Name = value; }
        }

        public bool IsAgainstComputer
        {
            get { return m_IsAgainstComputer; }
            set { m_IsAgainstComputer = value; }
        }
    }
}
