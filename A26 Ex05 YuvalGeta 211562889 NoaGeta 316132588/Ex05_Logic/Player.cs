namespace Ex05_Logic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly bool r_IsComputer;
        private int m_Score;

        public Player(string i_Name, bool i_IsComputer)
        {
            r_Name = i_Name;
            r_IsComputer = i_IsComputer;
            m_Score = 0;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public bool IsComputer
        {
            get { return r_IsComputer; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
    }
}
