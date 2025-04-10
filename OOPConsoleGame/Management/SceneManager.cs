using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Management
{
    public abstract class SceneManager
    {
        protected ConsoleKey input;
        public string sceneName;

        //1. 화면 그리기 함수
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Result();

        public virtual void Enter(){}
    }
}
