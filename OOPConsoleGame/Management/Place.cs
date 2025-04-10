using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.PlayerManager;

namespace OOPConsoleGame.Management
{
    public class Place : ObjectManager
    {
        private string sceneName;

        public Place(string scene, char symbol, Vector2 position)
            : base(ConsoleColor.Blue, symbol, position,false)
        {
            this.sceneName = scene;
        }

        public override void Interact(Player player)
        {
            GameManager.ChangeScene(sceneName);
        }
    }
}