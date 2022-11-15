using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;


namespace DungeonCrawl.Actors.Items
{
    internal class Key : Item
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "Key";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Player)
            {
                actor.Inventory["key"] += 1;
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