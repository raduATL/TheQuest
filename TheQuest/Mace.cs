using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {
    class Mace : Weapon {
        public Mace(Game game, Point location) : base(game, location)
        {
        }

        public override string Name {
            get {
                return "Mace";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
           if(PickedUp)
            {
                foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                {
                    bool damageEnemy = DamageEnemy(dir, 20, 6, random); // swing the mace in all 4 directions
                }
            }
        }
    }
}
