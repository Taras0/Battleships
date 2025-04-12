using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class Form1 : Form
    {

        public Field[,] playerBoard;
        public Field[,] enemyBoard;

        public Form1()
        {
            InitializeComponent();
            playerBoard = new Field[10, 10];
            enemyBoard = new Field[10, 10];
            CreateBoard(playerBoard, 30, 30);
            CreateBoard(enemyBoard, 390, 30);
            //test

        }

        public void CreateBoard(Field[,] board, int startX = 0, int startY = 0)
        {
            char[] charTab = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            for (int i = 0; i < 10; ++i)
            {
                Label tempLabel = new Label();
                tempLabel.Text = charTab[i].ToString();
                tempLabel.Width = 30;
                tempLabel.Height = 30;
                tempLabel.TextAlign = ContentAlignment.MiddleCenter;
                tempLabel.Location = new Point(startX + tempLabel.Width * i, startY - 30);
                this.Controls.Add(tempLabel);

                tempLabel = new Label();
                tempLabel.Text = (i+1).ToString();
                tempLabel.Width = 30;
                tempLabel.Height = 30;
                tempLabel.TextAlign = ContentAlignment.MiddleCenter;
                tempLabel.Location = new Point(startX - 30, startY + tempLabel.Height * i);
                this.Controls.Add(tempLabel);

                for (int j = 0; j < 10; ++j)
                {
                    board[i, j] = new Field();
                    board[i, j].Location = new Point(startX + board[i, j].Width * j, startY + board[i, j].Height * i);
                    this.Controls.Add(board[i, j]);
                }
            }
        }
    }
}
