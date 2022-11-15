﻿using UnityEngine;
using DungeonCrawl.Core;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {

        public Player() : base(25, 5)
        {

        }
        protected override void OnUpdate(float deltaTime)
        {
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
                enemyCharacter.ApplyDamage(Damage);
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            Debug.Log("Collision!");
            if (anotherActor is Character)
            {
                Debug.Log("Character is caharcter");
                Character otherCharacter = (Character)anotherActor;
                if (otherCharacter is Skeleton || otherCharacter is Ghost)
                {
                    Attack(otherCharacter);
                    Debug.Log($"You hurt an enemy.");
                }
            }

            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
