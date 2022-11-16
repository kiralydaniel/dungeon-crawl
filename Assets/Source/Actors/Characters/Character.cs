using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; } = 100;
        public int Damage { get; private set; }
        public int Armor { get; set; } = 0;

        public Character(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Character)
            {
                Character character = (Character)anotherActor;
                if (character is Player)
                {
                    Attack(character);
                    Debug.Log($"A(n) {name} hurt you  -{Damage}. Your health is {character.Health}/25");
                    anotherActor.OnCollision(this);
                }


            }

            return false;
        }

        public void Attack(Character playerCharacter)
        {
            if (playerCharacter.Health > 0)
            {
                playerCharacter.ApplyDamage(Damage);
            }
        }
        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
        
    }

}
