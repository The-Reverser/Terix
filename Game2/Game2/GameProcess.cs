using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Game2
{
    public delegate void KeyDownEventHander(ConsoleKey key);
    class GameProcess
    {
        public int Com_time=0;
        public BaseSqure bs;
        public BaseSqure bswait;
        public BaseGround one;
        public event KeyDownEventHander KeyDown;
        Thread keyDownThread;//键盘监听线程
        System.Timers.Timer timer;
        public bool replay = false;
        public int i=0;
        public bool autodown = false;
        public void StartGame() {

            bs = GetSqureRandom();
            bs.InitSqure();

            bswait =GetSqureRandom();
            bswait.InitSqure();

            one = new BaseGround(25, 30);
            one.bswait = bswait;
            one.InitBackground();
            one.Sum(bs);

            keyDownThread = new Thread(KeyDownThread);
            KeyDown += new KeyDownEventHander(KeyDownEnvent);
            keyDownThread.Start();


            timer= new System.Timers.Timer(1000);//定时器
            timer.Elapsed += Timer_Elapsed;
            timer.Start();//1s一次
          }
        //键盘接收线程
        private void KeyDownThread() {
            while (true) {
                KeyDown(Console.ReadKey(true).Key);//触KeyDown事件
            }
        }
        //事件处理函数
        private void KeyDownEnvent(ConsoleKey key) {
            int x = 0;
            if (autodown == true)
            {
                x = 1;
                autodown = false;
            }

            switch (key)
            {
                case ConsoleKey.A:
                    //bs.ToLeft(one,one.X,one.Y);
                    one.Change(bs,x,-1);
                    break;
          
                case ConsoleKey.D:
                  //  bs.ToRight(one, one.X, one.Y);
                    one.Change(bs,x,1);
                    break;
             
                case ConsoleKey.S:
                    //  bs.ToDown(one, one.X, one.Y);
                    bs.AutoDown();//自动下落
                    one.Change(bs,1);
                    break;
          
                case ConsoleKey.W:
                    bs.Revolve(one, one.X, one.Y);
                    one.Change(bs,x);
                    break;
                case ConsoleKey.R:
                    replay = true;
                    break;
                default:
                    break;
            }
        }
        private void ControlSqure() { 
        
        }
        public void Timer_Elapsed(object source,System.Timers.ElapsedEventArgs e) {
            if (replay == true)
            {
                bs = GetSqureRandom();
                bs.InitSqure();

                bswait = GetSqureRandom();
                bswait.InitSqure();

                one = new BaseGround(25, 30);
                one.bswait = bswait;
                one.InitBackground();
                one.Sum(bs);
                replay = false;
            }
            if (one.AutoChange(bs, 1)) {
                autodown = true;
            }
                
            if (one.changebool == true)
            {
               // Console.WriteLine("切换");
                 bs = bswait;
                bswait = GetSqureRandom();//下一个图形
                bswait.InitSqure();
                one.bswait = bswait;
                one.RemenberGround();//记住背景坐标
                one.Sum(bs);
                one.changebool = false;//判断置假   
            }
           
         }
        public BaseSqure GetSqureRandom() {
            Random rd = new Random();
            int x;
            x = rd.Next(0, 6);
     
            switch (3)
            {
                case 0:return new Squre1();
                case 1:return new Squre2();
                case 2:return new Squre3();
                case 3:return new Squre4();
                case 4:return new Squer5();
                case 5:return new Squre6();
                default:
                    break;
            }
            return new Squre1();
        }
    }
    
}
