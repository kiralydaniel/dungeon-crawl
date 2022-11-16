using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Character
    {

        public Ghost() :base(15,5)
        {

        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.D))
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
                        TryMove(Direction.Left);
                        break;
                }
            }


        }


        protected override void OnDeath()
        {
            Debug.Log("You've defeated a ghost!");
        }


        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Ghost";
    }
}