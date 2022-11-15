using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Door : Actor
    {
        public override int Z => -1;
        private bool _isOpen = false;
        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        public override int DefaultSpriteId => 485;
        public override string DefaultName => "Door";

        public override bool OnCollision(Actor actor)
        {
            if (actor is Skeleton)
            {
                return false;
            }

            if (!_isOpen)
            {
                Player player = (Player)actor;
                return CheckKeys(player);
            }

            return true;
        }

        public virtual bool CheckKeys(Player player)
        {
            if (player.HasKey("key"))
            {
                UseKey(player);
                return true;
            }

            return false;
        }

        public virtual void UseKey(Player player)
        {
            _isOpen = true;
            player.Inventory["key"] -= 1;
            SetSprite(487);
        }
    }
}