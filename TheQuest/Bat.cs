using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuest {

    class Bat : Enemy {

        public Bat(Game game, Point location) : base(game, location, 5)
        {  
        }
     

        public override void Move(Random random)
        {
            Direction dir = Direction.Up;
            if (!Dead)
            {
                if (random.Next(2) == 1)
                    dir = FindPlayerDirection(game.PlayerLocation);
                else
                {
                    int rnd = random.Next(4); // 0....3
                    switch (rnd)
                    {
                        case 0: dir = Direction.Up; break;
                        case 1: dir = Direction.Down; break;
                        case 2: dir = Direction.Left; break;
                        case 3: dir = Direction.Right; break;
                        default: break;
                    }

                }
                this.location = Move(dir, game.Boundaries);

                if (NearPlayer())
                    game.HitPlayer(2, random);
            }
          
        }
    }
}
