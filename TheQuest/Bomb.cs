using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {
    class Bomb : Weapon, IBomb {
        public Bomb(Game game, Point location) : base(game, location) {
            _used = false;
        }
        private bool _used;
        public bool Used { get { return _used; } }

        public override string Name {
            get {
                return "Bomb";
            }
        }

        public override void Attack(Direction direction, Random random) {
            if (PickedUp) {
                bool damageEnemy = DamageEnemy(direction, 40, 5, random);
                _used = true;
            }
        }
    }
}
