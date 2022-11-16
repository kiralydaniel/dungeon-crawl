using Assets.Source.Core;
using UnityEngine;
using DungeonCrawl.Core;
using System;
using Unity.Burst.Intrinsics;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {

        public Player() : base(100, 5)
        {
            
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.PrintInterface(Inventory, MaxHealth, Health, Damage, Armor);
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

        public void Attack(Character enemyCharacter)
        {
            if (enemyCharacter.Health>0)
            {
                enemyCharacter.ApplyDamage(Damage, enemyCharacter.Armor);
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Character)
            {
                Character otherCharacter = (Character)anotherActor;
                //TODO (add 3rd enemy too!)
                if (otherCharacter is Skeleton || otherCharacter is Ghost || otherCharacter is Devil)
                {
                    Attack(otherCharacter);
                    Debug.Log($"You hurt an enemy: {otherCharacter.GetType().Name}");
                }
            }

            return false;
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
        public override void AddToStat(Stats stat, int toAdd)
        {
            switch (stat)
            {
                case Stats.Health:
                    Health += toAdd;
                    break;
                case Stats.Strength:
                    Damage += toAdd;
                    break;
                case Stats.Armor:
                    Armor += toAdd;
                    break;
            }
        }
    }
}
