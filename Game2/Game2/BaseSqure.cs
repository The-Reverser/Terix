using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
  public abstract class BaseSqure  
    {
        public int y = 0;
        public int x = 0;
        public int saveX= 0;
        public int saveY = 0;
        public int[,] str = new int[4, 4];
        public abstract void Show();
        public abstract void InitSqure();//初始化
        public abstract void Revolve(BaseGround bg, int x, int y);//旋转
        public abstract void ToLeft(BaseGround bg, int x, int y);//左移
        public abstract void ToRight(BaseGround bg, int x, int y);//右移
        public abstract void ToDown(BaseGround bg, int x, int y);//加速
        public abstract void AutoDown();//自动下落
        public abstract bool JudgeCreate(BaseGround bg, int x, int y);//判断是否继续下落
        public abstract bool JudgeLeft(BaseGround bg, int x, int y);
        public abstract bool JudgeRight(BaseGround bg, int x, int y);
        public abstract bool JudgeTodown(BaseGround bg, int x, int y);
        public abstract void Refresh();


    }
}
