using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.PlayerManager;

namespace OOPConsoleGame.Management
{
    public abstract class ObjectManager
    {
            public ConsoleColor color;
            public char symbol;
            public Vector2 position;

            public void GameObject(ConsoleColor color, char symbol, Vector2 position)
            {
                this.color = color;
                this.symbol = symbol;
                this.position = position;
            }

            public void Print()
            {
                Console.SetCursorPosition(position.x, position.y);
                Console.ForegroundColor = color;
                Console.Write(symbol);
                Console.ResetColor();
            }

            public abstract void Interact(Player player);
    }
}