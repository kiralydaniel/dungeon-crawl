using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
 
        public Skeleton() : base(5, 4)
        {
        }
        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.D))
            {
                (int x, int y) playerPosition = ActorManager.Singleton.GetPlayerPosition();
                if (Position == playerPosition)
                {
                    Position = Position;
                }
                else
                {
                    var direction = Random.Range(0, 4);
                    switch (direction)
                    {
                        case 0:
                            TryMove(Direction.Up);
                            break;
                        case 1:
                            TryMove(Direction.Down);
                            break;
                        case 2:
                            TryMove(Direction.Left);
                            break;
                        case 3:
                            TryMove(Direction.Right);
                            break;
                    
                    }
                }

            }

        }
        protected override void OnDeath()
        {
            Debug.Log("You've defeated a skeleton!");
            int loot = Utilities.NewRandomNumber();
            if (loot >= 75)
            {
                ActorManager.Singleton.Spawn<HealthPotion>(Position);
            }
            
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
