using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheQuest {
    
    abstract class Mover {
        private const int MoveInterval = 10;
        protected Point location; // since proteccted prop are available to subclasses the form
                                 // object can't set the location, only read it through public get method
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.location = location;
            this.game = game;
        }

        // checks a Point against this objects' current location.
        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                Math.Abs(location.Y - locationToCheck.Y) < distance)
                return true;
            else
                return false;
        }

        public bool Nearby(Point locationn, Point locationToCheck, int distance)
        {
            if (Math.Abs(locationn.X - locationToCheck.X) < distance &&
               (Math.Abs(locationn.Y - locationToCheck.Y) < distance))
                return true;
            else
                return false;
        }

        public Point Move(Direction direction , Rectangle boundaries)
        {
           return Move(direction, location, boundaries);
        }

        // tries to move one step in a direction. if it can, it returns the new Point. If
        // it hits a boundary, it returns the original Point.
        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target; // start from current location.
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval; // move 10 pixels Up
                    break;
                case Direction.Down:
                    if(newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default: break;
            }
            return newLocation; // finally this new location is returned (which might still be the same
                                // as the original location
        }
    }
}
