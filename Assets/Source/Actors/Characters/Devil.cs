using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using DungeonCrawl.Core;
using TMPro;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Devil : Character
    {
        private float _distance;
        public Devil() : base(15, 8)
        {

        }

        protected override void OnUpdate(float deltaTime)
        {

            //TODO devil moves towards player
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.D))
            {
                (int x, int y) playerPosition = ActorManager.Singleton.GetPlayerPosition();
                (int, int) targetPosition;
                if (Position.x < playerPosition.x)
                {
                    targetPosition = (Position.x + 1, Position.y);
                }
                else if (Position.x < playerPosition.x)
                {
                    targetPosition = Position;
                }
                else
                {
                    targetPosition = (Position.x - 1, Position.y);
                }

                FinalPosition(targetPosition);

                if (Position.y < playerPosition.y)
                {
                    targetPosition = (Position.x, Position.y + 1);
                }
                    
                else if (Position.y == playerPosition.y)
                {
                    targetPosition = Position;
                }

                else
                {
                    targetPosition = (Position.x, Position.y - 1);
                }
                    
                FinalPosition(targetPosition);

            }

        }

        private void FinalPosition((int, int) targetPosition)
        {
            Actor targetActor = ActorManager.Singleton.GetActorAt(targetPosition);
            if (targetActor != null)
            {
                Position = Position;
            }
            else
            {
                Position = targetPosition;
            }
        }


        protected override void OnDeath()
        {
            Debug.Log("You've defeated a devil!");
        }


        public override int DefaultSpriteId => 122;
        public override string DefaultName => "Devil";
    }
}
