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
                UserInterface.Singleton.EndScreen("CONGRATS, YOU WON THE GAME!");
                ActorManager.Singleton.DestroyAllActors();
                //System.Threading.Thread.Sleep(3000);
                //SceneManager.LoadScene("Menu");
                return true;
            }

            return false;
        }

    }
}