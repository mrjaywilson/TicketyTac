// Namespace inclusion
using System;
using System.Drawing;
using System.Windows.Forms;

/*
 *      Program:        Project 4
 *      File:           frmTicketyTac.cs
 *      Description:    Handles everything related for the game.
 *      Author:         Jay Wilson
 *      Class:          CST-117
 *      Date:           July 1, 2018
 */

/// <summary>
/// Declare namespace
/// </summary>
namespace TicketyTac
{
    /// <summary>
    /// Class declaration
    /// </summary>
    public partial class frmTicketyTac : Form
    {
        /// <summary>
        /// Declare and initialize variables
        /// </summary>
        private char currentMove = 'X';         // X is player and goes first
        private char[,] cell = new char[3, 3];  // Setup the array for hanlding the game data

        /// <summary>
        /// Initialization method
        /// </summary>
        public frmTicketyTac()
        {
            // Initialize form components
            InitializeComponent();

            // Setup click events
            pbOne.Click += Player_Click;
            pbTwo.Click += Player_Click;
            pbThree.Click += Player_Click;
            pbFour.Click += Player_Click;
            pbFive.Click += Player_Click;
            pbSix.Click += Player_Click;
            pbSeven.Click += Player_Click;
            pbEight.Click += Player_Click;
            pbNine.Click += Player_Click;

            // Initial reset of the game to ensure everything
            // is set to be ready for a new game.
            ResetGame();

        }

        /// <summary>
        /// Event to handle all the player clicks
        /// </summary>
        private void Player_Click(object sender, EventArgs e)
        {
            // Get the control name and store it
            string name = ((PictureBox)sender).Name;

            // choose action depending on control name
            // and call setMove()
            switch (name)
            {
                case "pbOne":
                    SetMove(0, 0, pbOne);
                    break;
                case "pbTwo":
                    SetMove(0, 1, pbTwo);
                    break;
                case "pbThree":
                    SetMove(0, 2, pbThree);
                    break;
                case "pbFour":
                    SetMove(1, 0, pbFour);
                    break;
                case "pbFive":
                    SetMove(1, 1, pbFive);
                    break;
                case "pbSix":
                    SetMove(1, 2, pbSix);
                    break;
                case "pbSeven":
                    SetMove(2, 0, pbSeven);
                    break;
                case "pbEight":
                    SetMove(2, 1, pbEight);
                    break;
                case "pbNine":
                    SetMove(2, 2, pbNine);
                    break;
            }
        }

        /// <summary>
        /// Method to set the player peice in the correct location
        /// and handle all standard game logic
        /// </summary>
        /// <param name="x">X location of click.</param>
        /// <param name="y">Y location of click.</param>
        /// <param name="pb">Which picturebox to effect.</param>
        private void SetMove(int x, int y, PictureBox pb)
        {
            // Check if the cell is blank.
            if (cell[x, y] == ' ')
            {
                // If so and the current player is X
                if (currentMove.Equals('X'))
                {
                    // Set the image.
                    pb.Image = Properties.Resources.x;

                    // Set the cell value in the data array
                    cell[x, y] = 'X';

                    // Set the move to player 2 and notify
                    // the players
                    currentMove = 'Y';
                    lblNotice.ForeColor = Color.CornflowerBlue;
                    lblNotice.Text = "PLAYER O\nGO!";

                    // Check for winner
                    if (CheckWinner('X'))
                    {
                        // Let players know who won
                        lblNotice.ForeColor = Color.IndianRed;
                        lblNotice.Text = "Player X wins!";
                        GameStatus(false);
                    }
                    else
                    {
                        // If the gameboard is full and no winner
                        if (IsFull())
                        {
                            // Notify Players of draw
                            lblNotice.ForeColor = Color.Yellow;
                            lblNotice.Text = "Draw!";
                            GameStatus(false);
                        }
                    }
                }
                else
                {
                    // Set the image.
                    pb.Image = Properties.Resources.o;

                    // Set the  cell value in the data array
                    cell[x, y] = 'O';

                    // Set the move to player 1
                    currentMove = 'X';
                    lblNotice.ForeColor = Color.IndianRed;
                    lblNotice.Text = "PLAYER X\nGO";

                    // Check for winner
                    if (CheckWinner('O'))
                    {
                        // Let players know who won
                        lblNotice.ForeColor = Color.CornflowerBlue;
                        lblNotice.Text = "Player O wins!";
                        GameStatus(false);
                    }
                    else
                    {
                        // If the gameboard is full and no winner
                        if (IsFull())
                        {
                            // Notify Players of draw
                            lblNotice.ForeColor = Color.Yellow;
                            lblNotice.Text = "Draw!";
                            GameStatus(false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to handle the enable / disable the picture boxes
        /// </summary>
        /// <param name="status">Boolean value for enabling / disabling gameboard.</param>
        private void GameStatus(bool status)
        {
            // Sets the status of the gameboard
            pbOne.Enabled = status;
            pbTwo.Enabled = status;
            pbThree.Enabled = status;
            pbFour.Enabled = status;
            pbFive.Enabled = status;
            pbSix.Enabled = status;
            pbSeven.Enabled = status;
            pbEight.Enabled = status;
            pbNine.Enabled = status;
        }

        /// <summary>
        /// Check if the gameboard is full
        /// </summary>
        private bool IsFull()
        {
            // Iterate through the data for ' '
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If any cell is empty ' '...
                    if (cell[i,j] == ' ')
                    {
                        return false;
                    }
                }
            }
            // Otherwise the gameboard is full
            return true;
        }

        /// <summary>
        /// Method to check for winner
        /// </summary>
        /// <param name="player">set the tokn for the player, either 'X' or 'O'</param>
        private bool CheckWinner(char player)
        {
            // Interate through to find triple tokens
            for (int i = 0; i < 3; i++)
            {
                // Check the three cell values
                if (cell[i, 0] == player &&
                    cell[i, 1] == player &&
                    cell[i, 2] == player)
                {
                    // If they all equal the same token value
                    return true;
                }
            }

            // Interate through to find triple tokens
            for (int j = 0; j < 3; j++)
            {
                // Check the three cell values
                if (cell[0, j] == player &&
                    cell[1, j] == player &&
                    cell[2, j] == player)
                {
                    // If they all equal the same token value
                    return true;
                }
            }

            // Check cell locations that represent the diagonal locations
            if (cell[0, 0] == player &&
                cell[1, 1] == player &&
                cell[2, 2] == player)
            {
                return true;
            }

            // Check cell locations that represent the other diagonal locations
            if (cell[0, 2] == player &&
                cell[1, 1] == player &&
                cell[2, 0] == player)
            {
                return true;
            }

            // If all fail, no winner
            return false;
        }

        /// <summary>
        /// Reset the game
        /// </summary>
        public void ResetGame()
        {
            /// Iterate through all cell locations and clear them
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // in the given location, clear it
                    cell[i, j] = ' ';
                }
            }

            // Enable the gameboard
            GameStatus(true);

            // Clear all 'X' and 'O' images
            pbOne.Image = null;
            pbTwo.Image = null;
            pbThree.Image = null;
            pbFour.Image = null;
            pbFive.Image = null;
            pbSix.Image = null;
            pbSeven.Image = null;
            pbEight.Image = null;
            pbNine.Image = null;

            // Reset all background on the gameboard
            pbOne.BackColor = Color.Black;
            pbTwo.BackColor = Color.Black;
            pbThree.BackColor = Color.Black;
            pbFour.BackColor = Color.Black;
            pbFive.BackColor = Color.Black;
            pbSix.BackColor = Color.Black;
            pbSeven.BackColor = Color.Black;
            pbEight.BackColor = Color.Black;
            pbNine.BackColor = Color.Black;

            // Set the notice
            currentMove = 'X';
            lblNotice.ForeColor = Color.IndianRed;
            lblNotice.Text = "PLAYER X\nGO";
        }

        /// <summary>
        /// Button to exit the program
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        /// <summary>
        /// Butto nto start a new game.
        /// </summary>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Reset the game
            ResetGame();
        }
    }
}
