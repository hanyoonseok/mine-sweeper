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
    public partial class Form2 : Form
    {
        Button[,] button = new Button[9, 9]; //버튼
        Random r = new Random(DateTime.Now.Millisecond);
        int MineNum = 0; // 깃발꽂힌 지뢰 수
        int FlagNum = 0; //꽂은 깃발 수
        int FlatTileNum = 0; //눌린 상태의 버튼 수
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MakeButton();
            setMine();
            SetNumber();
        }
        private void MakeButton()
        {
            FlowLayoutPanel flp = new FlowLayoutPanel(); //버튼 배치할 패널
            flp.Size = new Size(250, 250);
            for (int i = 0; i < 9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    button[i,j] = new Button();
                    button[i,j].Size = new Size(20, 20);
                    button[i,j].Tag = 0;
                    button[i, j].Name = i.ToString() +","+ j.ToString();
                    button[i,j].MouseDown += new MouseEventHandler(PressLeft);
                    button[i,j].MouseDown += new MouseEventHandler(PressRight);
                    flp.Controls.Add(button[i,j]);
                }
            }
            this.Controls.Add(flp);
        }

        private void setMine() // 무작위 버튼에 마인 설치
        {
            int[] rand1 = new int[10];
            int[] rand2 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                rand1[i] = (int)r.Next(0, 8); //0~8까지의 버튼 중에서 난수 생성
                rand2[i] = (int)r.Next(0, 8);
                for (int j = 0; j < i; j++)
                {
                    if (rand1[j] == rand1[i] && rand2[j] == rand2[i])
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                button[rand1[i], rand2[i]].Tag = 999; // 해당 버튼의 태그 999로 변경
            }
        }

        private void SetNumber() //모든 버튼 검사하면서 있으면 주변8칸의 카운트 +1
        {
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    if ((int)button[i, j].Tag == 999)
                    {
                        if(i==0) //
                        {
                            if (j == 0) //[0,0]
                            {
                                int[] a = { Convert.ToInt32(button[1, 0].Tag), Convert.ToInt32(button[1, 1].Tag), Convert.ToInt32(button[0, 1].Tag) };
                                for(int k=0; k<a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[1, 0].Tag = ++a[0];
                                button[1, 1].Tag = ++a[1];
                                button[0, 1].Tag = ++a[2];
                            }
                            else if (j == 8) //[0,8]
                            {
                                int[] a = { Convert.ToInt32(button[1, 8].Tag), Convert.ToInt32(button[1, 7].Tag), Convert.ToInt32(button[0, 7].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[1, 8].Tag = ++a[0];
                                button[1, 7].Tag = ++a[1];
                                button[0, 7].Tag = ++a[2];
                            }
                            else if(j>0 && j<8)// 맨 윗 줄
                            {
                                int[] a = { Convert.ToInt32(button[i, j-1].Tag), Convert.ToInt32(button[i+1, j-1].Tag), Convert.ToInt32(button[i+1, j].Tag), Convert.ToInt32(button[i + 1, j+1].Tag), Convert.ToInt32(button[i, j+1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[i, j-1].Tag = ++a[0];
                                button[i+1, j-1].Tag = ++a[1];
                                button[i+1, j].Tag = ++a[2];
                                button[i + 1, j+1].Tag = ++a[3];
                                button[i, j+1].Tag = ++a[4];
                            }
                        }
                        else if (i == 8) //맨 아래줄
                        {
                            if (j == 0)
                            {
                                int[] a = { Convert.ToInt32(button[7, 0].Tag), Convert.ToInt32(button[8, 1].Tag), Convert.ToInt32(button[7, 1].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[7, 0].Tag = ++a[0];
                                button[8, 1].Tag = ++a[1];
                                button[7, 1].Tag = ++a[2];
                            }
                            else if (j == 8) // [8, 8]
                            {
                                int[] a = { Convert.ToInt32(button[7, 8].Tag), Convert.ToInt32(button[7, 7].Tag), Convert.ToInt32(button[8, 7].Tag) };
                                for (int k = 0; k < a.Length; k++)
                                {
                                    if (a[k] == 999)
                                        a[k]--;
                                }
                                button[7, 8].Tag = ++a[0];
                                button[7, 7].Tag = ++a[1];
                                button[8, 7].Tag = ++a[2];
                            }
                        }
                        else if(i>0 && i<8)//
                        {
                            if (j == 0) // 맨 왼쪽 줄
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
                            else if (j == 8) // [i , 8]
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
                            else if(j>0 && j<8)// [i , j]
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
                if(btn.FlatStyle!=FlatStyle.Flat && btn.Text != "▶")
                {
                    if ((int)btn.Tag == 999) // 클릭한 버튼이 지뢰이면
                    {
                        Replay rp = new Replay("Lose !");
                        btn.Text = "●";
                        rp.ShowDialog();
                    }

                    else if ((int)btn.Tag >= 1 && (int)btn.Tag < 999)// 클릭한 버튼이 일반 버튼이면
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
                    else if((int)btn.Tag == 0)
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
                        if(FlagNum<10)
                        {
                            btn.Text = "▶";
                            FlagNum++;
                            if ((int)btn.Tag == 999)
                            {
                                MineNum++;
                                if (MineNum == 10 && FlatTileNum == 71)
                                {
                                    Replay rp = new Replay("Win !");
                                    rp.ShowDialog();
                                }
                            }
                        }
                    }
                    else if(btn.Text == "▶")
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
            for (int i = x - 1; i < x + 2; i++) // 버튼 주변 8칸 검색
            {
                for (int j = y - 1; j < y + 2; j++) // 버튼 주변 8칸 검색
                {
                    if (i >= 0 && i <= 8 && j >= 0 && j <= 8)
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
                                Spread(i, j); // 퍼진 버튼의 태그가 0이면 그 버튼에 대해서 다시 실행
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