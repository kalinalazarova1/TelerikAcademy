using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.TicTacToe
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        static char[] field = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static TicTacToeAI ai = new TicTacToeAI();
        static bool isFinished = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cell0.Text = field[0].ToString();
            this.cell1.Text = field[1].ToString();
            this.cell2.Text = field[2].ToString();
            this.cell3.Text = field[3].ToString();
            this.cell4.Text = field[4].ToString();
            this.cell5.Text = field[5].ToString();
            this.cell6.Text = field[6].ToString();
            this.cell7.Text = field[7].ToString();
            this.cell8.Text = field[8].ToString();
        }

        protected void Play_Command(object sender, CommandEventArgs e)
        {
            var index = int.Parse(e.CommandArgument.ToString());
            if(field[index] == ' ' && !isFinished)
            {
                field[index] = 'O';
                var board = ConvertFromField(field);
                if (ai.IsWon(board))
                {
                    this.Message.Text = "Congratulations, you won the game.";
                    this.ExplicitDataBind();
                    isFinished = true;
                }
                else
                {
                    ai.PlayComputer(board);
                    field = ConvertToField(board);
                    this.ExplicitDataBind();
                    if (ai.IsLost(board))
                    {
                        this.Message.Text = "Sorry, you lose the game.";
                        isFinished = true;
                    }
                }
            }
        }

        private int[,] ConvertFromField(char[] field)
        {
            var result = new int[3, 3];
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (field[r * 3 + c] != ' ')
                    {
                        result[r, c] = field[r * 3 + c] == 'X' ? -1 : 1;
                    }
                }
            }

            return result;
        }

        private char[] ConvertToField(int[,] board)
        {
            var result = new StringBuilder(9);
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] != 0)
                    {
                        result.Append(board[r, c] == -1 ? 'X' : 'O');
                    }
                    else
                    {
                        result.Append(' ');
                    }
                }
            }

            return result.ToString().ToCharArray();
        }

        protected void Restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                field[i] = ' ';
            }

            this.Message.Text = string.Empty;
            isFinished = false;
            this.ExplicitDataBind();
        }

        private void ExplicitDataBind()
        {
            this.cell0.Text = field[0].ToString();
            this.cell1.Text = field[1].ToString();
            this.cell2.Text = field[2].ToString();
            this.cell3.Text = field[3].ToString();
            this.cell4.Text = field[4].ToString();
            this.cell5.Text = field[5].ToString();
            this.cell6.Text = field[6].ToString();
            this.cell7.Text = field[7].ToString();
            this.cell8.Text = field[8].ToString();
        }
    }
}