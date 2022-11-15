using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
 
        public Skeleton() : base(5, 2)
        {
        }
        protected override void OnDeath()
        {
            Debug.Log("You've defeated a skeleton!");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
