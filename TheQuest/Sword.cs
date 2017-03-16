using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {
    class Sword : Weapon {
        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override string Name {
            get {
                return "Sword";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            int radius = 20;
            int damage = 3;

            switch (direction)
            {
                case Direction.Up:
                    if (!DamageEnemy(Direction.Up, radius, damage, random))
                        if (!DamageEnemy(Direction.Right, radius, damage, random))
                            DamageEnemy(Direction.Left, radius, damage, random);
                    break;
                case Direction.Down:
                    if (!DamageEnemy(Direction.Down, radius, damage, random))
                        if (!DamageEnemy(Direction.Left, radius, damage, random))
                            DamageEnemy(Direction.Right, radius, damage, random);
                    break;
                case Direction.Left:
                    if (!DamageEnemy(Direction.Left, radius, damage, random))
                        if (!DamageEnemy(Direction.Up, radius, damage, random))
                            DamageEnemy(Direction.Down, radius, damage, random);
                    break;
                case Direction.Right:
                    if (!DamageEnemy(Direction.Right, radius, damage, random))
                        if (!DamageEnemy(Direction.Down, radius, damage, random))
                            DamageEnemy(Direction.Up, radius, damage, random);
                    break;
                default:
                    break;
            }
        }
    }
}
