using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    internal class Sword : Item
    {
        public override int DefaultSpriteId => 464;
        public override string DefaultName => "Sword";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Player)
            {
                if (actor.Inventory.ContainsKey("sword"))
                {
                    actor.Inventory["sword"]++;
                    actor.AddToStat(Stats.Strength, 10);
                }
                else
                {
                    actor.Inventory.Add("sword", 1);
                    actor.AddToStat(Stats.Strength, 10);
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