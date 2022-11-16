using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonCrawl.Actors.Characters;
namespace DungeonCrawl.Actors.Static
{
    public class Gate : Actor
    {
        public override int DefaultSpriteId => 434;
        public override string DefaultName => "Gate";

        public override bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            ActorManager.Singleton.DestroyAllActors();
            MapLoader.LoadMap(2);
            return true;
        }
    }
}