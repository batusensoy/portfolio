using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsTicTacToe TicTacToe;
        bool bHasGameStarted;

        public MainWindow()
        {
            InitializeComponent();
            TicTacToe = new clsTicTacToe();
            bHasGameStarted = false;
            UpdateStats();
            ResetBoard();
        }

        /// <summary>
        /// Start a new game or restart the current game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            bHasGameStarted = true;
            TicTacToe.ResetGame(); // Reset the game state without losing progress
            UpdateStats();
            ResetBoard(); // Reset the UI board
        }

        /// <summary>
        /// Handles player clicks on the TicTacToe board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, MouseButtonEventArgs e)
        {
            if (bHasGameStarted)
            {
                Label lbl = (Label)sender;
                int row = Grid.GetRow(lbl);
                int col = Grid.GetColumn(lbl);

                if (TicTacToe.PlayerMove(row, col))
                {
                    // Check for a winning move
                    if (TicTacToe.IsWinningMove())
                    {
                        HighlightWinningMove();
                        bHasGameStarted = false;
                    }
                    else if (TicTacToe.IsTie())
                    {
                        bHasGameStarted = false;
                    }

                    UpdateStats();

                    // Set the content of lbl based on the current player's turn in TicTacToe
                    if (TicTacToe.bPlayer1Turn)
                    {
                        lbl.Content = "X";
                    }
                    else
                    {
                        lbl.Content = "O";
                    }
                }
            }

        }

        /// <summary>
        /// Finds the winning move and calls HighlightCells() to indicate the winning move
        /// </summary>
        private void HighlightWinningMove()
        {
            switch (TicTacToe.CurrentWinningMove)
            {
                case clsTicTacToe.WinningMove.Row1:
                    HighlightCells(lbl00, lbl01, lbl02);
                    break;
                case clsTicTacToe.WinningMove.Row2:
                    HighlightCells(lbl10, lbl11, lbl12);
                    break;
                case clsTicTacToe.WinningMove.Row3:
                    HighlightCells(lbl20, lbl21, lbl22);
                    break;
                case clsTicTacToe.WinningMove.Col1:
                    HighlightCells(lbl00, lbl10, lbl20);
                    break;
                case clsTicTacToe.WinningMove.Col2:
                    HighlightCells(lbl01, lbl11, lbl21);
                    break;
                case clsTicTacToe.WinningMove.Col3:
                    HighlightCells(lbl02, lbl12, lbl22);
                    break;
                case clsTicTacToe.WinningMove.Diag1:
                    HighlightCells(lbl00, lbl11, lbl22);
                    break;
                case clsTicTacToe.WinningMove.Diag2:
                    HighlightCells(lbl02, lbl11, lbl20);
                    break;
            }
        }

        /// <summary>
        /// Changes the color of the cells. It is used by HighlightWinningMove()
        /// </summary>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <param name="cell3"></param>
        private void HighlightCells(Label cell1, Label cell2, Label cell3)
        {
            cell1.Background = cell2.Background = cell3.Background = Brushes.Cyan;

        }

        /// <summary>
        /// Changes cells to default color
        /// </summary>
        private void ResetColors()
        {
            lbl00.Background = lbl01.Background = lbl02.Background = Brushes.Blue;
            lbl10.Background = lbl11.Background = lbl12.Background = Brushes.Blue;
            lbl20.Background = lbl21.Background = lbl22.Background = Brushes.Blue;
        }

        /// <summary>
        /// Updates and displays the stats of the players and keeps track of the wins and ties
        /// </summary>
        private void UpdateStats()
        {
            // Update statistics in the UI based on TicTacToe class variables
            if (bHasGameStarted)
            {
                if (TicTacToe.bPlayer1Turn)
                {
                    lblStatus.Content = "Player 1's turn";
                }
                else
                {
                    lblStatus.Content = "Player 2's turn";
                }
            }
            else
            {
                lblStatus.Content = "";
            }

            if (TicTacToe.IsWinningMove())
            {
                if (!TicTacToe.bPlayer1Turn)
                {
                    TicTacToe.Player1Wins++;
                    lblStatus.Content = "Player 1 Wins!";
                }
                else
                {
                    TicTacToe.Player2Wins++;
                    lblStatus.Content = "Player 2 Wins!";
                }
            }
            else if (TicTacToe.IsTie())
            {
                TicTacToe.Ties++;
                lblStatus.Content = "It's a Tie";
            }

            // Update UI with statistics
            lblPlayer1Wins.Content = "Player 1 Wins: " + TicTacToe.Player1Wins;
            lblPlayer2Wins.Content = "Player 2 Wins: " + TicTacToe.Player2Wins;
            lblTies.Content = "Ties: " + TicTacToe.Ties;
        }

        /// <summary>
        /// Resets the board to it's initial state
        /// </summary>
        private void ResetBoard()
        {
            lbl00.Content = lbl01.Content = lbl02.Content = "";
            lbl10.Content = lbl11.Content = lbl12.Content = "";
            lbl20.Content = lbl21.Content = lbl22.Content = "";
            ResetColors();
        }

    }
}