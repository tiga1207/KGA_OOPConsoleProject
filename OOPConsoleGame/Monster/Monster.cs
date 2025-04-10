using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Monster
{
    public class Monster
    {
        public string name;
        //최대 체력, 현재 체력
        public int hp;
        public int maxHp;
        public int damage;
        //보상(Reward): 확률적으로 아이템 주며, 아이템 줄 때는 콘솔로 알려줌
        public ItemBase item;


        
        //몬스터 공격 로직
        public void AttackPlayer()
        {

        }
        //몬스터 피격 로직
        public void TakeDamage()
        {

        }
        //몬스터 사망 로직
        public void MonsterDie()
        {
            //플레이어 현재 Position의 몬스터 심볼 파괴(제거)

        }
        //보상 부여
        public void RewardToPlayer()
        {

        }



    }
}
