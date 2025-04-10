﻿using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class MainScene : SceneManager
    {
        private ConsoleKey input;
        //메인 맵
        public MainScene()
        {
            sceneName = "Main";
        }


        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        //상점, 필드, 인벤토리, 장착

        public override void Render()
        {
            Console.WriteLine("메인 마을에 드디어 도착했다 . . .");
            Console.WriteLine("다음 중 어떤 행동을 취할까? . . .");
            UtilManager.DelayedPrint("1. 필드로 나간다",ConsoleColor.Green);
            UtilManager.DelayedPrint("2. 상점로 나간다",ConsoleColor.Green);
            UtilManager.DelayedPrint("3. 인벤토리를 구경한다",ConsoleColor.Green);
            UtilManager.DelayedPrint("4. 장착 아이템을 확인하러 간다",ConsoleColor.Green);
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    UtilManager.ReadAnyKey("마을 밖으로 나갑니다.");
                    break;
            }
        }

        public override void Update()
        {
        }
    }
}
