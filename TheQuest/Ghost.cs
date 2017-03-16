using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {

    class Ghost : Enemy {
        public Ghost(Game game, Point location ) : base(game, location, 8)
        {
        }

        public override void Move(Random random)
        {
            Direction dir = Direction.Up;
            if (!Dead)
            {
                if(random.Next(3) == 1)
                {
                    dir = FindPlayerDirection(game.PlayerLocation);
                    this.location = Move(dir, game.Boundaries);
                }
                if (NearPlayer())
                    game.HitPlayer(3, random);
            }
        }
    }
}
