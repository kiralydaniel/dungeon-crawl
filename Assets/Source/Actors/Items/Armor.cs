using System.Collections.Generic;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    internal class Armor : Item
    {
        public override int DefaultSpriteId => 80;
        public override string DefaultName => "Armor";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Player)
            {
                if (actor.Inventory.ContainsKey("armor"))
                {
                    actor.Inventory["armor"]++;
                    actor.AddToStat(Stats.Armor, 2);
                }
                else
                {
                    actor.Inventory.Add("armor", 1);
                    actor.AddToStat(Stats.Armor, 2);
                }
                
            }
            else
            {
                return false;
            }
            ActorManager.Singleton.DestroyActor(this);
            return true;
        }

    }
}