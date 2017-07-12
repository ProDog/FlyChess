using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyingChess
{
    class Program
    {
        static int[] Maps = new int[100];
        static int[] PlayerPos = { 5, 7 };

        static void Main(string[] args)
        {
            //数组中, 0：普通 ○  
            //        1：幸运轮盘 ●
            //        2：地雷 ■
            //        3：暂停 □
            //        4：时空隧道 ▼
            //Console.WriteLine("○ ● ■ □ ▼");

            # region 初始游戏
            string[] Names = new string[2];
            ShowUI();

            Console.WriteLine("请输入玩家 A 的姓名：");
            Names[0] = Console.ReadLine();
            while (Names[0] == "")
            {
                Console.WriteLine("玩家 A 的姓名不能为空，请重新输入：");
                Names[0] = Console.ReadLine();
            }

            Console.WriteLine("请输入玩家 B 的姓名：");
            Names[1] = Console.ReadLine();
            while (Names[1] == "" || Names[1] == Names[0])
            {
                if (Names[1] == "")
                {
                    Console.WriteLine("玩家 B 的姓名不能为空，请重新输入：");
                }
                else
                {
                    Console.WriteLine("姓名 {0} 已被玩家 A 占用，请重新输入：", Names[0]);
                }
                Names[1] = Console.ReadLine();
            }
            Console.Clear();

            ShowUI();
            Console.WriteLine("对战开始······\n");
            Console.WriteLine("玩家 {0} 的士兵用 A 表示；\n\n玩家 {1} 的士兵用 B 表示；\n", Names[0], Names[1]);
            Console.WriteLine("如果玩家 {0} 和玩家 {1} 在同一位置，用 <> 表示...", Names[0], Names[1]);
            Console.WriteLine("");
            # endregion

            InitialMap();
            DrawMap();

            Console.ReadKey();
        }

        static void ShowUI()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*               骑  士  飞  行  棋               *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*************************************************");
        }

        static void InitialMap()
        {
            for (int i = 0; i < Maps.Length; i++)
            {
                Maps[i] = 0;
            }
            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            int[] pause = { 9, 27, 60, 93 };
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };

            for (int i = 0; i < luckyTurn.Length; i++)
            {
                int pos = luckyTurn[i];
                Maps[pos] = 1;
            }
            for (int i = 0; i < landMine.Length; i++)
            {
                Maps[landMine[i]] = 2;
            }
            for (int i = 0; i < pause.Length; i++)
            {
                Maps[pause[i]] = 3;
            }
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                Maps[timeTunnel[i]] = 4;
            }

            //for (int i = 0; i < Maps.Length; i++)
            //{
            //    Console.WriteLine(Maps[i]);
            //}
        }

        static void DrawMap()
        {
            # region 1行
            for (int i = 0; i <= 29; i++)
            {
                if (PlayerPos[0] == i && PlayerPos[1] == i)
                {
                    Console.Write("<>");
                }
                else if (PlayerPos[0] == i)
                {
                    Console.Write("A");
                }
                else if (PlayerPos[1] == i)
                {
                    Console.Write("B");
                }
                else
                {
                    switch (Maps[i])
                    {
                        case 0:
                            Console.Write("○");
                            break;
                        case 1:
                            Console.Write("●");
                            break;
                        case 2:
                            Console.Write("■");
                            break;
                        case 3:
                            Console.Write("□");
                            break;
                        case 4:
                            Console.Write("▼");
                            break;
                    }
                }
            }
            # endregion

            Console.WriteLine();

            #region 1列
            for (int i = 30; i <= 34; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                if (PlayerPos[0] == i && PlayerPos[1] == i)
                {
                    Console.WriteLine("<>");
                }
                else if (PlayerPos[0] == i)
                {
                    Console.WriteLine("A");
                }
                else if (PlayerPos[1] == i)
                {
                    Console.WriteLine("B");
                }
                else
                {
                    switch (Maps[i])
                    {
                        case 0:
                            Console.WriteLine("○");
                            break;
                        case 1:
                            Console.WriteLine("●");
                            break;
                        case 2:
                            Console.WriteLine("■");
                            break;
                        case 3:
                            Console.WriteLine("□");
                            break;
                        case 4:
                            Console.WriteLine("▼");
                            break;
                    }
                }
            }
            #endregion
        }
    }
}
