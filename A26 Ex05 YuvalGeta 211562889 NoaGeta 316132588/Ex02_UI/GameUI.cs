using System;
using Ex02_Logic;

namespace Ex02_UI
{
    public class GameUI
    {
        // Class member names start with m_ 
        private GameManager m_GameManager;

        public void Start()
        {
            initGame();
            runGameLoop();
        }

        private void initGame()
        {
            Console.WriteLine("Welcome to 4-in-a-Row!");

            // Requirements: Board size 4x4 to 8x8 [cite: 32]
            int rows = getValidDimension("rows", 4, 8);
            int cols = getValidDimension("columns", 4, 8);

            // Requirements: PvP or PvC [cite: 32]
            int modeChoice = getValidChoice("Choose Mode: (1) Player vs Player (2) Player vs Computer", 1, 2);
            bool v_IsAgainstMachine = modeChoice == 2; // Local bool prefix v_ 

            m_GameManager = new GameManager(rows, cols, v_IsAgainstMachine);
        }

        private void runGameLoop()
        {
            bool v_IsPlaying = true;

            while (v_IsPlaying)
            {
                playRound();
                displayScores();
                v_IsPlaying = askToPlayAgain();

                if (v_IsPlaying)
                {
                    m_GameManager.ResetGame(); // Clear board logic [cite: 73]
                    Console.Clear(); // Using standard clear as DLL is unavailable
                }
            }
        }

        private void playRound()
        {
            bool v_RoundEnded = false;

            while (!v_RoundEnded)
            {
                Console.Clear(); // Refresh board view [cite: 84]
                Console.WriteLine(m_GameManager.GameBoard.GetBoardString());
                v_RoundEnded = handleCurrentTurn();
            }
        }

        private bool handleCurrentTurn()
        {
            bool v_GameOver = false;
            int chosenCol;

            // Requirements: Human starts against computer [cite: 34]
            if (m_GameManager.CurrPlayer == eCell.Player2 && m_GameManager.IsAgainstMachine)
            {
                chosenCol = m_GameManager.GetComputerMove(); // Logic: Random move [cite: 80]
            }
            else
            {
                chosenCol = getPlayerMove();
            }

            if (chosenCol == -1) // Player entered 'Q' to quit [cite: 72]
            {
                m_GameManager.HandleQuit();
                Console.WriteLine("A player has resigned!");
                v_GameOver = true;
            }
            else
            {
                bool v_IsWin, v_IsTie;
                bool v_ValidMove = m_GameManager.PlayTurn(chosenCol, out v_IsWin, out v_IsTie);

                if (v_ValidMove)
                {
                    if (v_IsWin)
                    {
                        Console.Clear();
                        Console.WriteLine(m_GameManager.GameBoard.GetBoardString());
                        Console.WriteLine($"Winner is {m_GameManager.CurrPlayer}!"); // [cite: 69]
                        v_GameOver = true;
                    }
                    else if (v_IsTie)
                    {
                        Console.WriteLine("The board is full. It's a Tie!"); // [cite: 70]
                        v_GameOver = true;
                    }
                }
                else
                {
                    Console.WriteLine("This column is full! Press any key to try again..."); // [cite: 46]
                    Console.ReadKey();
                }
            }

            return v_GameOver;
        }

        private int getPlayerMove()
        {
            int chosenCol = -1;
            bool v_IsValidInput = false;

            while (!v_IsValidInput)
            {
                Console.WriteLine($"{m_GameManager.CurrPlayer}, enter column (1-{m_GameManager.GameBoard.Cols}) or 'Q' to quit:"); // [cite: 45, 72]
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                {
                    chosenCol = -1;
                    v_IsValidInput = true;
                }
                else if (int.TryParse(input, out chosenCol) &&
                         chosenCol >= 1 && chosenCol <= m_GameManager.GameBoard.Cols)
                {
                    chosenCol -= 1; // Convert 1-based UI to 0-based Logic
                    v_IsValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid column or 'Q'."); // [cite: 83]
                }
            }

            return chosenCol;
        }

        private void displayScores()
        {
            // Requirement: Show points [cite: 69, 70]
            Console.WriteLine("\n--- Scoreboard ---");
            Console.WriteLine($"Player 1: {m_GameManager.Player1Score}");
            Console.WriteLine($"Player 2: {m_GameManager.Player2Score}");
            Console.WriteLine("------------------\n");
        }

        private int getValidDimension(string i_DimensionName, int i_Min, int i_Max)
        {
            int result = 0;

            while (true)
            {
                Console.Write($"Enter number of {i_DimensionName} ({i_Min}-{i_Max}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out result) && result >= i_Min && result <= i_Max)
                {
                    break;
                }

                Console.WriteLine($"Invalid input! Enter a value between {i_Min} and {i_Max}.");
            }

            return result;
        }

        private int getValidChoice(string i_Message, int i_Min, int i_Max)
        {
            int choice = 0;

            while (true)
            {
                Console.WriteLine(i_Message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= i_Min && choice <= i_Max)
                {
                    break;
                }

                Console.WriteLine("Invalid choice.");
            }

            return choice;
        }

        private bool askToPlayAgain()
        {
            bool v_Continue = false;

            while (true)
            {
                Console.WriteLine("Would you like to play another round? (Y/N)"); // [cite: 73]
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    v_Continue = true;
                    break;
                }
                else if (input == "N")
                {
                    v_Continue = false;
                    break;
                }
            }

            return v_Continue;
        }
    }
}


