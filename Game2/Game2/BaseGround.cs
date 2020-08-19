using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Game2
{
   public class BaseGround
    {
        public int x=0;
        public int y=0;
        public int X { get; set; }
        public int Y { get; set; }
        public bool changebool = false;
        public BaseSqure bswait=null;
        public int Yleft=0;
        private int[,] str;
        public int score = 0;
        public int flag = 0;
        private bool win = true;
        public int this[int Xindex,int Yindex] {
            get { return str[Xindex, Yindex]; }
            set { str[Xindex, Yindex] = value; }
        }
        public BaseGround(int x, int y) {
            this.X = x;
            this.Y = y;
            str = new int[X, Y];
        }
        /*   public static void show()
           {
               string[,] str = new string[x, y];
               for (int i = 0; i < x; i++)
               {
                   for (int j = 0; j < y; j++)
                   {
                       if (i == 0 || i == x - 1 || j == 0 || j == y - 1)
                       {
                           str[i, j] = "▓";
                       }
                       else
                           // str[i, j] = "  ";
                           str[i, j] = "█";
                   }
               }
               for (int i = 0; i < x; i++)
               {
                   for (int j = 0; j < y; j++)
                   {
                       Console.Write(str[i, j]);
                   }
                   Console.WriteLine();
               }

           }*/

        public void InitBackground() {

             Yleft = Y / 2 +2;
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (i == 0 || i == X - 1 || j == 0 || j == Yleft - 1||j==Y-1)
                    {
                        str[i, j] = 2;
                    }
                    else str[i, j] = 0;
                }

            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    str[i + 4, j + Y / 2 + 6] = bswait.str[i, j];
                }
            }
           
        }
        private void Print() {
            if (win == false)
            {
                Console.WriteLine("失败");
            }
            //Console.Clear();
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (i == 14 && j == Y / 2 + 6)
                    { 
                        Console.Write("分数:");
                        j=j+3;
                    
                    }
                    else if (i == 14 && j == Y / 2 + 11)
                        Console.Write("{0,-5}", score);
                    else if (str[i, j] == 2)
                        Console.Write("▓");
                    else if (str[i, j] == 1)
                        Console.Write("█");
                    else if (str[i, j] == 3)
                        Console.Write("█");
                    else
                        Console.Write("  ");


                }
                Console.WriteLine();
            }
        
        }
        public void Sum(BaseSqure bs) {
            x = 0;
            y = 0;
            for (int i = 0; i < 4; i++)//移动图形坐标
            {
                for (int j = 0; j < 4; j++)
                {
                    if (bs.str[i, j] == 1)
                        str[i + 1 , 7 + j] = bs.str[i, j];
                }
            }
            Print();//填充图形
            flag = 0;
        }
        public void Change(BaseSqure bs,int a=0,int b=0) {
            if (flag == 1)
                return;
            else
            {
                flag = 2;
                HistryGround();//背景坐标
                /*  bs.y += bs.saveY;
                  bs.x += bs.saveX;*/

                for (int i = 0; i < 4; i++)//移动图形坐标
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (bs.str[i, j] == 1)
                            str[i + 1 + this.x, 7 + j + this.y] = bs.str[i, j];
                    }
                }
                if (b < 0)
                {
                    for (int i = 1; i < X - 1; i++)
                    {
                        for (int j = 1; j < Y / 2 + 1; j++)
                        {
                            if (str[i, j] == 1 && str[i, j - 1] != 0)
                            {
                                flag = 0;
                                return;
                            }
                            else if (str[i, j] == 1 && str[i, j - 1] == 0)
                                break;
                        }
                    }
                }
                if (b > 0)
                {
                    for (int i = 1; i < X; i++)
                    {
                        for (int j = Y / 2; j > 0; j--)
                        {
                            if (str[i, j] == 1 && str[i, j + 1] != 0)
                            {
                                flag = 0;
                                return;
                            }
                            else if (str[i, j] == 1 && str[i, j + 1] == 0)
                                break;
                        }
                    }
                }
                if (a > 0)
                {
                    for (int j = 1; j < Y / 2 + 1; j++)
                    {
                        for (int i = X - 2; i > 0; i--)
                        {
                            if (str[i, j] == 1 && str[i + 1, j] != 0)
                            {
                               
                                changebool = true;
                                flag = 0;
                                return;         
                            }
                            else if (str[i, j] == 1 && str[i + 1, j] == 0)
                                break;
                        }
                    }

                }
                this.x += a;
                this.y += b;
                HistryGround();//背景坐标
                for (int i = 0; i < 4; i++)//移动图形坐标
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (bs.str[i, j] == 1)
                            str[i + 1 + this.x, 7 + j + this.y] = bs.str[i, j];
                    }
                }
                /*    bs.saveY = 0;
                    bs.saveX = 0;*/
                Print();//填充图形
                flag = 0;
            }
        }
        public bool AutoChange(BaseSqure bs, int a = 0) {
            if (flag==2)
                return true;
            else
            {
                flag = 1;
                HistryGround();//背景坐标
                /*  bs.y += bs.saveY;
                  bs.x += bs.saveX;*/
                for (int i = 0; i < 4; i++)//移动图形坐标
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (bs.str[i, j] == 1)
                            str[i + 1 + this.x, 7 + j + this.y] = bs.str[i, j];
                    }
                }
                if (a > 0)
                {
                    for (int j = 1; j < Y / 2 + 1; j++)
                    {
                        for (int i = X - 2; i > 0; i--)
                        {
                            if (str[i, j] == 1 && str[i + 1, j] != 0)
                            {
                                this.x = 0;
                                this.y = 0;
                                changebool = true;
                               // flag = 0;
                                return false;

                            }
                            else if (str[i, j] == 1 && str[i + 1, j] == 0)
                                break;
                        }
                    }

                }
                this.x += a;
                HistryGround();//背景坐标
                for (int i = 0; i < 4; i++)//移动图形坐标
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (bs.str[i, j] == 1)
                            str[i + 1 + this.x, 7 + j + this.y] = bs.str[i, j];
                    }
                }
                /*    bs.saveY = 0;
                    bs.saveX = 0;*/
                Print();//填充图形
                flag = 0;
                return false;
            }
        }
        public void HistryGround() {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y/2+2; j++)
                {
                    if (str[i, j] == 1)
                        str[i, j] = 0;
                }
            }
        }
        public void RemenberGround() {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y/2+2; j++)
                {
                    if (str[i, j] == 1)
                        str[i, j] = 3;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    str[i + 4, j + Y / 2 + 6] = bswait.str[i, j];
                }
            }

            bool boo = true;
            for (int i = X-2; i >0; i--)
            {
                for (int j = 1; j < Yleft; j++)
                {
                    if (str[i, j] == 0)
                    {
                        boo = false;
                        break;
                    }
                }
                if (boo)
                {  
                    DownOne(i);
                    i++;
                }
                    
                boo = true;
                }
            for (int j = 1; j < Y/2+1; j++)
            {
                if (str[1, j] == 3)
                {
                    win = false;//失败
                }
            }

        }
        public void DownOne(int x) {
            score++;
            for (int i = x; i > 1; i--)
            {
                for (int j = 1; j < Yleft; j++)
                {
                    str[i, j] = str[i - 1, j];
                }
            }
            
        }
        
          

    }
}
