using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {

    abstract class Enemy : Mover {
        private const int NearPlayerDistance = 25; // 25 pixels considered near player distance
        public int HitPoints { get; private set; }

        public bool Dead { get
            { if (HitPoints <= 0)
                    return true;
                else return false;
            }
        }

        public Enemy(Game game, Point location, int hitPoints) : base(game, location){
            HitPoints = hitPoints;
        }

        public abstract void Move(Random random); // each subclass of Enemy implements this

        public void Hit(int maxDamage, Random random){
            HitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer()
        {
            return (Nearby(game.PlayerLocation, NearPlayerDistance));
        }

        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10)
                directionToMove = Direction.Right;
            else if (playerLocation.X < location.X - 10)
                directionToMove = Direction.Left;
            else if (playerLocation.Y < location.Y - 10)
                directionToMove = Direction.Up;
            else
                directionToMove = Direction.Down;

            return directionToMove;
        }

    }
}
