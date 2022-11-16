using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Static
{
    public class Bush : Actor
    {
        public override int DefaultSpriteId => 96;
        public override string DefaultName => "Bush";

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }
    }
}
