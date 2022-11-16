using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    internal class HealthPotion : Item
    {
        public override int DefaultSpriteId => 518;
        public override string DefaultName => "HealthPotion";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Player player)
            {
                if (player.Health >= 75)
                {
                    player.Health = player.MaxHealth;
                }
                else
                {
                    actor.AddToStat(Stats.Health, 25);
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