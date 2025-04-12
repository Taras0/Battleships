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
        public char[] charTab = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public int[] shipsSizes = { 5, 4, 4, 3, 3, 2, 2, 2 };
        public Ship[] ships;
        public Field[,] playerBoard;
        public Field[,] enemyBoard;

        public Form1()
        {
            InitializeComponent();
            playerBoard = new Field[10, 10];
            enemyBoard = new Field[10, 10];
            CreateBoard(playerBoard, OnPlayerBoardClick, 30, 60);
            CreateBoard(enemyBoard, OnEnemyBoardClick, 390, 60);
            SetBoardEnabled(enemyBoard, false);
            ships = new Ship[shipsSizes.Length];
            SetShips(OnShipClicked);
        }

        public void CreateBoard(Field[,] board, EventHandler function, int startX = 0, int startY = 0)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    board[i, j] = new Field();
                    board[i, j].Location = new Point(startX + board[i, j].Width * j, startY + board[i, j].Height * i);
                    board[i, j].Click += function;
                    board[i, j].x = i;
                    board[i, j].y = j;
                    //board[i, j].MouseHover += OnFieldHover;
                    board[i, j].BackColor = Color.White;
                    this.Controls.Add(board[i, j]);
                }

                AddBoardLabel(charTab[i].ToString(), new Point(startX - 30, startY + board[i, 0].Height * i));
                AddBoardLabel((i + 1).ToString(), new Point(startX + board[i, 0].Width * i, startY - 30));

            }
        }

        public void SetBoardEnabled(Field[,] board, bool enabled)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    board[i, j].Enabled = enabled;
                }
            }
        }

        public void SetShips(EventHandler function)
        {
            for(int i = 0; i < ships.Length; ++i)
            {
                int x = i > 0 ? ships[i-1].Location.X + ships[i-1].Width + 20 : 30;
                int y = 390;
                ships[i] = new Ship(shipsSizes[i]);
                ships[i].Location = new Point(x, y);
                ships[i].Click += function;
                this.Controls.Add(ships[i]);
            }
        }

        public void AddBoardLabel(string text, Point point)
        {
            Label tempLabel = new Label();
            tempLabel.Text = text;
            tempLabel.Width = 30;
            tempLabel.Height = 30;
            tempLabel.TextAlign = ContentAlignment.MiddleCenter;
            tempLabel.Location = point;
            this.Controls.Add(tempLabel);
        }

        public void OnPlayerBoardClick(object sender, EventArgs e)
        {
            Field field = sender as Field;
            field.Text = charTab[field.x].ToString() + (field.y +1).ToString();
        }

        public void OnEnemyBoardClick(object sender, EventArgs e)
        {
            Field field = sender as Field;
            field.Text = "O";
        }

        public void OnShipClicked(object sender, EventArgs e)
        {
            Ship ship = sender as Ship;
            
        }

        public void OnFieldHover(object sender, EventArgs e)
        {
            Field field = sender as Field;
            //field.BackColor = Color.Blue;
        }

        private void nowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetBoard(playerBoard);
            ResetBoard(enemyBoard);
            SetBoardEnabled(enemyBoard, false);
        }

        public void ResetBoard(Field[,] board)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    board[i, j].BackColor = Color.White;
                    board[i, j].Text = "";
                    board[i, j].value = 0;
                }
            }
        }
    }
}
