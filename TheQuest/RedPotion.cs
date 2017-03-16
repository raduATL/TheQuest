using System;
using System.Drawing;

namespace TheQuest {

    class RedPotion : Weapon, IPotion {
        public RedPotion(Game game, Point location) 
                     : base(game, location) {
            _used = false;
        }
        private bool _used;
        public override string Name{
            get {
                return "Red Potion";
            }
        }

        public bool Used {
            get {
                return _used;
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            _used = true;
        }
    }
}
