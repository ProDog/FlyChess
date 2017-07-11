using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyingChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //数组中, 0：普通 ○  
            //        1：幸运轮盘 ●
            //        2：地雷 ■
            //        3：暂停 □
            //        4：时空隧道 ▼
            Console.WriteLine("○ ● ■ □ ▼");
            int[] Maps = new int[99];
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
            Console.WriteLine("玩家 {0} 的士兵用 A 表示；\n\n玩家 {1} 的士兵用 B 表示；\n", Names[0],Names[1]);
            Console.WriteLine("如果玩家 {0} 和玩家 {1} 在同一位置，用 <> 表示...",Names[0], Names[1]);
            Console.WriteLine("");
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
 
        }
    }
}
