using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DungeonCrawl.Actors.Items
{
    internal class Crown : Item
    {
        public override int DefaultSpriteId => 138;
        public override string DefaultName => "Crown";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Player)
            {
                ActorManager.Singleton.DestroyAllActors();
                SceneManager.LoadScene("Victory");
                return true;
            }

            return false;
        }

    }
}