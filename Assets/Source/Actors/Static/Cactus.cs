using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Cactus : Actor
    {
        public override int DefaultSpriteId => 53;
        public override string DefaultName => "Cactus";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}
