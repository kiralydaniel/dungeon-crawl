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
                actor.Inventory["sword"] += 1;
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