using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TheQuest {

    abstract class Weapon : Mover {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location) : base(game, location) {
            PickedUp = false;
        }

        public void PickUpWeapon() { PickedUp = true; }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point playerLocation = game.PlayerLocation; // distance of attack is relative to Player location
            for(int distance = 0; distance < radius / 2; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                    if (Nearby(playerLocation, enemy.Location, distance))
                    {
                        enemy.Hit(damage, random); // damage is passed through by the weapon
                        MessageBox.Show("Enemy " + enemy.ToString() + " was hit");
                        return true;
                    }

                playerLocation = Move(direction, playerLocation, game.Boundaries);
            }
            return false;
        }

      
    }
}
