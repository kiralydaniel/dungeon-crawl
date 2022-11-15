using Assets.Source.Core;
using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Player()
        {
            Health = 100;
            Shield = 5;
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.PrintInterface(Inventory, MaxHealth, Health);
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Move right
                TryMove(Direction.Right);
            }
            CameraController.Singleton.Position = Position;
        }


        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public bool HasKey(string key)
        {
            if (Inventory[key] > 0)
            {
                return true;
            }

            return false;
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
