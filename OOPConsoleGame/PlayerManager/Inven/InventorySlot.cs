using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.PlayerManager.Inven
{
    public class InventorySlot
    {
        public ItemBase Item { get; set; }
        public int Count { get; set; }

        public InventorySlot(ItemBase item,int count) 
        { 
            Item = item;
            Count = count;
        }
    }
}
