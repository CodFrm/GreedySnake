using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace GreedySnake
{
    public partial class GreedySnakeGameMainWindow : Form
    {
        public GreedySnakeGameMainWindow()
        {
            InitializeComponent();
            //提前画出子格,放入内存
            //格子数 10*10 宽高 30*30 边框 1 画布宽度 320*320
            //因为要10个格子,所以得画11条线,这个....一直没注意= =
            Graphics gdiLattice = Graphics.FromImage(bmpCanvas);
            gdiLattice.Clear(BackColor);
            for (int i = 0; i <= 10; i++)//画横线
            {
                gdiLattice.DrawLine(new Pen(Color.Red, 1), 0, i * 30, 300, i * 30);
            }
            for (int i = 0; i <= 10; i++)//画竖线
            {
                gdiLattice.DrawLine(new Pen(Color.Red, 1), i * 30, 0, i * 30, 300);
            }
        }
        Graphics gdiWindow;
        Bitmap bmpCanvas = new Bitmap(301, 301);//因为笔宽的原因所以画布宽为301
        private void GreedySnakeGameMainWindow_Paint(object sender, PaintEventArgs e)
        {
            //格子已经画出保存在内存中,所以可以直接画出
            gdiWindow.DrawImage(bmpCanvas, 30, 30);

        }
        public struct ObjectPos
        {
            public int x;
            public int y;
        };
        public ObjectPos posSnakeHead = new ObjectPos();
        public ArrayList posSnakeBody=new ArrayList();
        private void MoveSnake_Tick(object sender, EventArgs e)
        {
            DrawSnake();
        }
        //画出蛇
        private void DrawSnake()
        {
            Bitmap bmpSnake = new Bitmap(300, 300);
            //蛇头
            //posSnakeBody.Add(new ObjectPos());
            switch (nMoveDirection)
            {
                case 1:
                    {
                        posSnakeHead.x--;
                        break;
                    }
                case 2:
                    {
                        posSnakeHead.y--;
                        break;
                    }
                case 3:
                    {
                        posSnakeHead.x++;
                        break;
                    }
                case 4:
                    {
                        posSnakeHead.y++;
                        break;
                    }
            }
            Graphics gdiSnake = Graphics.FromImage(bmpSnake);
            gdiSnake.FillRectangle(new SolidBrush(Color.Blue), posSnakeHead.x * 30 + 1, posSnakeHead.y * 30 + 1, 29, 29);
            //蛇身
            gdiWindow.DrawImage(bmpCanvas, 30, 30);
            gdiWindow.DrawImage(bmpSnake, 30, 30);
        }
        private void GreedySnakeGameMainWindow_Load(object sender, EventArgs e)
        {
            gdiWindow = this.CreateGraphics();
            posSnakeHead.x = 0;
            posSnakeHead.y = 0;
            MoveSnake.Start();
        }
        int nMoveDirection=39;
        private void GreedySnakeGameMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 37:
                    {
                        nMoveDirection = 1;
                        break;
                    }
                case 38:
                    {
                        nMoveDirection = 2;
                        break;
                    }
                case 39:
                    {
                        nMoveDirection = 3;
                        break;
                    }
                case 40:
                    {
                        nMoveDirection = 4;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            //MessageBox.Show(e.KeyValue.ToString());
            //up 38
            //down 40
            //left 37
            //right 39
        }
    }
}
