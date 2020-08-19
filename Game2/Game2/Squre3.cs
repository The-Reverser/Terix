using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    class Squre3:BaseSqure
    {
        //██
        //██
        //
        private int count = 0;
        public string this[int x, int y]
        {
            get { return this[x, y]; }
            set { this[x, y] = value; }
        }
        public override void InitSqure()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    str[i, j] = 0;
                }
            }
            str[0, 0] = 1;
            str[0, 1] = 1;
            str[1, 0] = 1;
            str[1, 1] = 1;
        }
        public override void Revolve(BaseGround bg, int a, int b)
        {
          
        }
        public override void Show()
        {
            throw new NotImplementedException();
        }
        public override void ToLeft(BaseGround bg, int a, int b)
        {
            saveY--;
            if (!JudgeLeft(bg, a, b))
                saveY++;

        }
        public override void ToDown(BaseGround bg, int a, int b)
        {
            saveX++;
            if (JudgeTodown(bg, a, b))
                saveX--;
        }
        public override void AutoDown()
        {

            x++;

        }
        public override void ToRight(BaseGround bg, int a, int b)
        {
            saveY++;
            if (!JudgeRight(bg, a, b))
                saveY--;
        }
        public override bool JudgeCreate(BaseGround bg, int x, int y)
        {
            for (int j = 1; j < y; j++)
            {
                for (int i = x - 2; i > 0; i--)
                {
                    if (bg[i, j] == 1 && bg[i + 1, j] != 0)
                    {

                        return true;
                    }
                    else if (bg[i, j] == 1 && bg[i + 1, j] == 0)
                        break;


                }
            }
            return false;

        }
        public override bool JudgeLeft(BaseGround bg, int x, int y)
        {
            for (int i = 1; i < x - 1; i++)
            {
                for (int j = 1; j < y / 2 + 1; j++)
                {
                    if (bg[i, j] == 1 && bg[i, j + saveY] == 0)
                        break;
                    else if (bg[i, j] == 1 && bg[i, j + saveY] != 0)
                        return false;
                }
            }
            return true;
        }
        public override bool JudgeRight(BaseGround bg, int x, int y)
        {
            for (int i = 1; i < x - 1; i++)
            {
                for (int j = y / 2; j > 0; j--)
                {
                    if (bg[i, j] == 1 && bg[i, j + saveY] == 0)
                        break;
                    else if (bg[i, j] == 1 && bg[i, j + saveY] != 0)
                        return false;
                }
            }
            return true;
        }
        public override bool JudgeTodown(BaseGround bg, int x, int y)
        {

            for (int j = 1; j < y / 2 + 1; j++)
            {
                for (int i = x - 3; i > 0; i--)
                {
                    if (bg[i, j + saveY] == 1 && bg[i + saveX + 1, j + saveY] != 0)
                    {

                        return true;
                    }
                    else if (bg[i, j + saveY] == 1 && bg[i + saveX + 1, j + saveY] == 0)
                        break;


                }
            }
            return false;

        }
        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
