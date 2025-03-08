using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class clsTicTacToe
    {
        private string[,] saBoard;
        private int iPlayer1Wins;
        private int iPlayer2Wins;
        private int iTies;
        private WinningMove eWinningMove;
        public bool bPlayer1Turn;


        /// <summary>
        /// represents possible winning moves in Tic Tac Toe.
        /// </summary>
        public enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        
        // Public properties that are accessed by the UI
        
        /// <summary>
        /// Propetry for the game board
        /// </summary>
        public string[,] SaBoard
        {
            get { return saBoard; }
        }

        /// <summary>
        /// Property for the number of wins for Player 1
        /// </summary>
        public int Player1Wins
        {
            get { return iPlayer1Wins; }
            set { iPlayer1Wins = value; }
        }

        /// <summary>
        /// Property for the number of wins for Player 2
        /// </summary>
        public int Player2Wins
        {
            get { return iPlayer2Wins; }
            set { iPlayer2Wins = value; }
        }

        /// <summary>
        /// Property for the number of ties
        /// </summary>
        public int Ties
        {
            get { return iTies; }
            set { iTies = value; }
        }

        /// <summary>
        /// Property for the winning move
        /// </summary>
        public WinningMove CurrentWinningMove
        {
            get { return eWinningMove; }
        }


        /// <summary>
        /// constructor to initialize saBoard
        /// </summary>
        public clsTicTacToe()
        {
            // Initialize the game board at the start of a new game
            saBoard = new string[3, 3];
            ResetGame();

        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void ResetGame()
        {
            // Clear the game board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    saBoard[i, j] = "";
                }
            }

            // Reset game variables
            eWinningMove = WinningMove.Row1;
            bPlayer1Turn = true;
        }

        /// <summary>
        ///  It checks if the selected space is empty, places the player's symbol on the board, switches turns.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool PlayerMove(int row, int col)
        {
            // Check if the selected space is empty
            if (saBoard[row, col] == "")
            {
                // Set X or O based on the current player's turn
                if (bPlayer1Turn)
                {
                    saBoard[row, col] = "X";
                }
                else
                {
                    saBoard[row, col] = "O";
                }
                bPlayer1Turn = !bPlayer1Turn; // Switch turns
                return true; // Move successful
            }

            return false; // Space already occupied
        }

        /// <summary>
        /// Checks if the current move results in a winning state
        /// </summary>
        /// <returns></returns>
        public bool IsWinningMove()
        {
            return IsHorizontalWin() || IsVerticalWin() || IsDiagonalWin();
        }

        /// <summary>
        /// Checks for a winning move in horizontal rows
        /// </summary>
        /// <returns></returns>
        private bool IsHorizontalWin()
        {
            for (int row = 0; row < 3; row++)
            {
                if (saBoard[row, 0] != "" && saBoard[row, 0] == saBoard[row, 1] && saBoard[row, 1] == saBoard[row, 2])
                {
                    switch (row)
                    {
                        case 0:
                            eWinningMove = WinningMove.Row1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Row2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Row3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks for a winning move in vertical columns
        /// </summary>
        /// <returns></returns>
        private bool IsVerticalWin()
        {
            for (int col = 0; col < 3; col++)
            {
                if (saBoard[0, col] != "" && saBoard[0, col] == saBoard[1, col] && saBoard[1, col] == saBoard[2, col])
                {
                    switch (col)
                    {
                        case 0:
                            eWinningMove = WinningMove.Col1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Col2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Col3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks for a diagonal win
        /// </summary>
        /// <returns></returns>
        private bool IsDiagonalWin()
        {
            if (saBoard[0, 0] != "" && saBoard[0, 0] == saBoard[1, 1] && saBoard[1, 1] == saBoard[2, 2])
            {
                eWinningMove = WinningMove.Diag1;
                return true;
            }

            if (saBoard[0, 2] != "" && saBoard[0, 2] == saBoard[1, 1] && saBoard[1, 1] == saBoard[2, 0])
            {
                eWinningMove = WinningMove.Diag2;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the game is a tie
        /// </summary>
        /// <returns></returns>
        public bool IsTie()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (saBoard[row, col] == "")
                    {
                        // If any empty space is found, the game is not a tie
                        return false;
                    }
                }
            }

            // All spaces are filled, and no winner is found so it's a tie
            return true;
        }
    }
}
