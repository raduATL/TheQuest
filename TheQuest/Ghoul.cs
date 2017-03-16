using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {

    class Ghoul : Enemy {
        public Ghoul(Game game, Point location ) : base(game, location, 10)
        {
        }

        public override void Move(Random random)
        {
            Direction dir = Direction.Up;
            if (!Dead)
            {
                // 2 in 3 chances it will move towards the Player
                if (random.Next(3) == 1 || random.Next(3) == 2)
                {
                    dir = FindPlayerDirection(game.PlayerLocation);
                    this.location = Move(dir, game.Boundaries);
                }
                if (NearPlayer())
                    game.HitPlayer(4, random);
            }
        }
    }
}
