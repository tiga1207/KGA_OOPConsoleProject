using OOPConsoleGame.Management;
using OOPConsoleGame.Monster;
using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class FieldStage2 : FieldSceneBase
    {
        public FieldStage2()
        {
            sceneName = "Stage2";

            mapData = new string[]
            {
                "########",
                "#      #",
                "#      #",
                "#   ## #",
                "#   #  #",
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
            gameObjects.Add(new Place("FieldStageA", 'A', new Vector2(6, 1)));
            gameObjects.Add(new UsingItem("MP 포션",20,"필드에 존재하는 Mp회복 물약",true,EffectTarget.Mp,10,new Vector2(1, 4)));
            gameObjects.Add(
            new MonsterBuilder()
                .SetName("슬라임")
                .SetHp(15, 15)
                .SetDmg(5)
                .SetReward(10)
                .SetPosition(new Vector2(3, 3))
                .SetSymbol('S')
                .SetColor(ConsoleColor.Red)
                .Build()
        );
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
            else if (prevSceneName == "ForestField")
            {
                GameManager.Player1.PlayerPos = new Vector2(6, 1);
            }
            GameManager.Player1.map = map;
        }
    }    
}
