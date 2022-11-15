using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; }
        public int Damage { get; private set; }

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
                    anotherActor.OnCollision(this);

            }

            return false;
        }


        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
    }
}
