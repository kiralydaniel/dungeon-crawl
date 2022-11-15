using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        public override int DefaultSpriteId => 434;
        public override string DefaultName => "Door";

        public override bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            ActorManager.Singleton.DestroyAllActors();
            MapLoader.LoadMap(2);
            return true;
        }
    }
}
