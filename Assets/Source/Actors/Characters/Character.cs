using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; } = 100;
        public int Damage { get; set; }
        public int Armor { get; set; } = 0;

        public Character(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }

        public void ApplyDamage(int damage, int armor)
        {
            Health -= damage - armor;

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
                    var damage = Damage - character.Armor;
                    Attack(character);
                    Debug.Log($"A(n) {name} hurt you  -{damage}. Your health is {character.Health}/100");
                    anotherActor.OnCollision(this);
                }


            }

            return false;
        }

        public void Attack(Character playerCharacter)
        {
            if (playerCharacter.Health > 0)
            {
                playerCharacter.ApplyDamage(Damage, playerCharacter.Armor);
            }
        }
        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
        
    }

}
