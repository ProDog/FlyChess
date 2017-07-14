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

            Random ran = new Random(); //掷骰子产生随机数
            int step = 0;

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
            Console.WriteLine("\n对战开始······");
            Console.WriteLine("\n玩家 {0} 的士兵用 A 表示；\n\n玩家 {1} 的士兵用 B 表示；", Names[0], Names[1]);
            Console.WriteLine("\n如果玩家 {0} 和玩家 {1} 在同一位置，用 <> 表示...", Names[0], Names[1]);
            Console.WriteLine("\n按任意键开始游戏......");
            Console.ReadKey();
            Console.Clear();
            # endregion

            InitialMap();
            DrawMap();

            //让玩家 A B循环掷骰子，当坐标大于 99 时结束
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                //玩家 A 掷骰子
                Console.WriteLine("\n玩家 {0} 按任意键开始掷骰子...",Names[0]);
                Console.ReadKey(true);
                step = ran.Next(1, 7);
                Console.WriteLine("\n玩家 {0} 掷出了: {1}.", Names[0], step);
                Console.WriteLine("\n玩家 {0} 按任意键开始移动...", Names[0]);
                Console.ReadKey(true);
                PlayerPos[0] = PlayerPos[0] + step;
                if (PlayerPos[0] > 99)
                {
                    PlayerPos[0] = 99;
                }
                Console.Clear();
                DrawMap();

            }

            Console.ReadKey();
        }

        /// <summary>
        /// 显示地图
        /// </summary>
        static void ShowUI()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*               骑  士  飞  行  棋               *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*************************************************");
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
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

        /// <summary>
        /// 坐标 pos 上应该绘制的图形
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        static string GetMapString(int pos)
        {
            string result = "";
            if (PlayerPos[0] == pos && PlayerPos[1] == pos)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                result = "<>";
            }
            else if (PlayerPos[0] == pos)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                result = "A";
            }
            else if (PlayerPos[1] == pos)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                result = "B";
            }
            else
            {
                switch (Maps[pos])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        result = "○";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        result = "●";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        result = "■";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        result = "□";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        result = "▼";
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// 绘制地图图案
        /// </summary>
        static void DrawMap()
        {
            Console.WriteLine("\n地图说明：普通：○,幸运轮盘：●,地雷：■,暂停：□,时空隧道：▼\n");

            for (int i = 0; i <= 29; i++)
            {
               Console.Write(GetMapString(i));
            }
            Console.WriteLine();

            for (int i = 30; i <= 34; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(GetMapString(i));
            }

            for (int i = 64; i >= 35; i--)
            {
                Console.Write(GetMapString(i));
            }
            Console.WriteLine();

            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(GetMapString(i));
            }

            for (int i = 70; i <= 99; i++)
            {
                Console.Write(GetMapString(i));
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
