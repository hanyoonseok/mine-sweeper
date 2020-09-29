using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid
{
    public partial class Form4 : Form
    {
        Button[,] button = new Button[16, 30];
        FlowLayoutPanel flp = new FlowLayoutPanel();
        Random r = new Random(DateTime.Now.Millisecond);
        int MineNum = 0;
        int FlagNum = 0;
        int FlatTileNum = 0; // 눌려있는 타일 개수
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MakeButton();
            setMine();
            SetNumber();
        }
        private void MakeButton()
        {
            flp.Size = new Size(780, 440);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Size = new Size(20, 20);
                    button[i, j].Tag = 0;
                    button[i, j].Name = i.ToString() + "," + j.ToString();
                    button[i, j].MouseDown += new MouseEventHandler(PressLeft);
                    button[i, j].MouseDown += new MouseEventHandler(PressRight);
                    flp.Controls.Add(button[i, j]);
                }
            }
            this.Controls.Add(flp);
        }

        private void setMine()
        {
            int[] rand1 = new int[99];
            int[] rand2 = new int[99];
            for (int i = 0; i < 99; i++)
            {
                rand1[i] = (int)r.Next(0, 15); 
                rand2[i] = (int)r.Next(0, 29);
                for (int j = 0; j < i; j++)
                {
                    if (rand1[j] == rand1[i] && rand2[j] == rand2[i])
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < 99; i++)
            {
                button[rand1[i], rand2[i]].Tag = 999; // 해당 버튼의 태그 999로 변경
            }
        }
        private void SetNumber()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if ((int)button[i, j].Tag == 999)
                    {
                        if (i == 0) //
                        {
                            if (j == 0) //[0,0]
                            {
                                int[] a = { Convert.ToInt32(button[1, 0].Tag), Convert.ToInt32(button[1, 1].Tag), Convert.ToInt32(button[0, 1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[1, 0].Tag = ++a[0];
                                button[1, 1].Tag = ++a[1];
                                button[0, 1].Tag = ++a[2];
                            }
                            else if (j == 29) //[0,8]
                            {
                                int[] a = { Convert.ToInt32(button[1, 29].Tag), Convert.ToInt32(button[1, 28].Tag), Convert.ToInt32(button[0, 28].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[1, 29].Tag = ++a[0];
                                button[1, 29].Tag = ++a[1];
                                button[0, 28].Tag = ++a[2];
                            }
                            else if (j > 0 && j < 29)// 
                            {
                                int[] a = { Convert.ToInt32(button[i, j - 1].Tag), Convert.ToInt32(button[i + 1, j - 1].Tag), Convert.ToInt32(button[i + 1, j].Tag), Convert.ToInt32(button[i + 1, j + 1].Tag), Convert.ToInt32(button[i, j + 1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[i, j - 1].Tag = ++a[0];
                                button[i + 1, j - 1].Tag = ++a[1];
                                button[i + 1, j].Tag = ++a[2];
                                button[i + 1, j + 1].Tag = ++a[3];
                                button[i, j + 1].Tag = ++a[4];
                            }

                        }
                        else if (i == 15) // 맨 오른쪽 줄
                        {
                            if (j == 0) //
                            {
                                int[] a = { Convert.ToInt32(button[14, 0].Tag), Convert.ToInt32(button[15, 1].Tag), Convert.ToInt32(button[14, 1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[14, 0].Tag = ++a[0];
                                button[15, 1].Tag = ++a[1];
                                button[14, 1].Tag = ++a[2];
                            }
                            else if (j == 29) //
                            {
                                int[] a = { Convert.ToInt32(button[14, 29].Tag), Convert.ToInt32(button[14, 28].Tag), Convert.ToInt32(button[15, 28].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[14, 29].Tag = ++a[0];
                                button[14, 28].Tag = ++a[1];
                                button[15, 28].Tag = ++a[2];
                            }
                        }
                        else if (i > 0 && i < 15)// [i, j]
                        {
                            if (j == 0) // [i , 0]
                            {
                                int[] a = { Convert.ToInt32(button[i - 1, j].Tag), Convert.ToInt32(button[i - 1, j + 1].Tag), Convert.ToInt32(button[i, j + 1].Tag), Convert.ToInt32(button[i + 1, j + 1].Tag), Convert.ToInt32(button[i + 1, j].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[i - 1, j].Tag = ++a[0];
                                button[i - 1, j + 1].Tag = ++a[1];
                                button[i, j + 1].Tag = ++a[2];
                                button[i + 1, j + 1].Tag = ++a[3];
                                button[i + 1, j].Tag = ++a[4];
                            }
                            else if (j == 29) //
                            {

                                int[] a = { Convert.ToInt32(button[i - 1, j].Tag), Convert.ToInt32(button[i - 1, j - 1].Tag), Convert.ToInt32(button[i, j - 1].Tag), Convert.ToInt32(button[i + 1, j - 1].Tag), Convert.ToInt32(button[i + 1, j].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[i - 1, j].Tag = ++a[0];
                                button[i - 1, j - 1].Tag = ++a[1];
                                button[i, j - 1].Tag = ++a[2];
                                button[i + 1, j - 1].Tag = ++a[3];
                                button[i + 1, j].Tag = ++a[4];
                            }
                            else if (j > 0 && j < 29)// [i , j]
                            {
                                int[] a = { Convert.ToInt32(button[i - 1, j].Tag), Convert.ToInt32(button[i - 1, j - 1].Tag), Convert.ToInt32(button[i, j - 1].Tag), Convert.ToInt32(button[i + 1, j - 1].Tag), Convert.ToInt32(button[i + 1, j].Tag), Convert.ToInt32(button[i + 1, j + 1].Tag), Convert.ToInt32(button[i, j + 1].Tag), Convert.ToInt32(button[i - 1, j + 1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[i - 1, j].Tag = ++a[0];
                                button[i - 1, j - 1].Tag = ++a[1];
                                button[i, j - 1].Tag = ++a[2];
                                button[i + 1, j - 1].Tag = ++a[3];
                                button[i + 1, j].Tag = ++a[4];
                                button[i + 1, j + 1].Tag = ++a[5];
                                button[i, j + 1].Tag = ++a[6];
                                button[i - 1, j + 1].Tag = ++a[7];
                            }
                        }
                    }
                }
            }
        }
        private void PressLeft(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            string[] arr = btn.Name.Split(',');
            int idx1 = Convert.ToInt32(arr[0]);
            int idx2 = Convert.ToInt32(arr[1]);

            if (e.Button == MouseButtons.Left)
            {
                if (btn.FlatStyle != FlatStyle.Flat && btn.Text != "▶")
                {
                    if ((int)btn.Tag == 999) // 클릭한 버튼이 지뢰이면
                    {
                        Replay rp = new Replay("Lose !");
                        btn.Text = "●";
                        rp.ShowDialog();
                    }

                    else if ((int)btn.Tag >= 1 && (int)btn.Tag <999)// 클릭한 버튼이 일반 버튼이면
                    {
                        button[idx1, idx2].Text = button[idx1, idx2].Tag.ToString();
                        button[idx1, idx2].FlatStyle = FlatStyle.Flat;
                        button[idx1, idx2].BackColor = Color.Gray;
                        button[idx1, idx2].FlatAppearance.BorderColor = Color.Gray;
                        FlatTileNum++;
                        if (MineNum == 10 && FlatTileNum == 71)
                        {
                            Replay rp = new Replay("Win !");
                            rp.ShowDialog();
                        }
                    }
                    else if ((int)btn.Tag == 0)
                    {
                        Spread(idx1, idx2);
                        if (MineNum == 10 && FlatTileNum == 71)
                        {
                            Replay rp = new Replay("Win !");
                            rp.ShowDialog();
                        }
                    }
                }
            }
        }
        void PressRight(object sender, MouseEventArgs e) // 클릭한 버튼이 오른쪽이면
        {
            Button btn = sender as Button;

            if (e.Button == MouseButtons.Right)
            {
                if (btn.FlatStyle != FlatStyle.Flat)
                {
                    if (btn.Text != "▶")
                    {
                        if (FlagNum < 99)
                        {
                            btn.Text = "▶";
                            FlagNum++;
                            if ((int)btn.Tag == 999)
                            {
                                MineNum++;
                                if (MineNum == 99 && FlatTileNum==381)
                                {
                                    Replay rp = new Replay("Win !");
                                    rp.ShowDialog();
                                }
                            }
                        }
                    }
                    else if (btn.Text == "▶")
                    {
                        btn.Text = "";
                        FlagNum--;
                        if ((int)btn.Tag == 999)
                            MineNum--;
                    }
                }
            }
        }
        private void Spread(int x, int y) // 영역 넓히기. Tag 0짜리 눌렀을 때만 활성화
        {
            for (int i = x - 1; i < x + 2; i++) // 
            {
                for (int j = y - 1; j < y + 2; j++) // 
                {
                    if (i >= 0 && i <= 15 && j >= 0 && j <= 29)
                    {
                        if (button[i, j].FlatStyle != FlatStyle.Flat)
                        {
                            if ((int)button[i, j].Tag == 0)
                            {
                                button[i, j].Text = button[i, j].Tag.ToString();
                                button[i, j].FlatStyle = FlatStyle.Flat;
                                button[i, j].BackColor = Color.Gray;
                                button[i, j].FlatAppearance.BorderColor = Color.Gray;
                                FlatTileNum++;
                                Spread(i, j);
                            }
                            else if ((int)button[i, j].Tag > 0 && (int)button[i, j].Tag < 999)
                            {
                                button[i, j].Text = button[i, j].Tag.ToString();
                                button[i, j].FlatStyle = FlatStyle.Flat;
                                button[i, j].BackColor = Color.Gray;
                                button[i, j].FlatAppearance.BorderColor = Color.Gray;
                                FlatTileNum++;
                            }
                        }
                    }
                }
            }
        }
    }
}
