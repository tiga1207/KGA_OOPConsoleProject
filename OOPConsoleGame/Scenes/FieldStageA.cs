using OOPConsoleGame.Management;
using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class FieldStageA : FieldSceneBase
    {
        public FieldStageA()
        {
            sceneName = "Stage1";

            mapData = new string[]
            {
                "########",
                "#   #  #",
                "#   #  #",
                "### #  #",
                "#      #",
                "########"
            };

            map = new bool[6, 8];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }

            gameObjects = new List<ObjectManager>();
            gameObjects.Add(new Place("Main", 'M', new Vector2(1, 1)));
            gameObjects.Add(new Place("StageB", 'B', new Vector2(6, 1)));
            gameObjects.Add(new UsingItem("HP 포션",20,"필드에 존재하는 Hp회복 물약",true,EffectTarget.Hp,20,new Vector2(1, 2)));
        }

        public override void Enter()
        {
            string currentMap = GameManager.Player1.mapStack.Pop();
            string prevSceneName = GameManager.Player1.mapStack.Peek();
            GameManager.Player1.mapStack.Push(currentMap);
            if (prevSceneName == "Main")
            {
                GameManager.Player1.PlayerPos = new Vector2(1, 1);
            }
            else if (prevSceneName == "Stage2")
            {
                GameManager.Player1.PlayerPos = new Vector2(6, 1);
            }
            GameManager.Player1.map = map;
        }
    }    
}
