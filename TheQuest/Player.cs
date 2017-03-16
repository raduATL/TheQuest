using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest {

    // Player is a concrete class, Mover is abstract
    class Player : Mover {
        private Weapon equippedWeapon;
        public int HitPoints { get; private set; } // Player's LIFE in points units
        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons {
            get {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location) : base(game, location){
            HitPoints = 10;
        }

        public void Hit(int maxDamage, Random random){
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random){
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
        }

        public void Move(Direction direction)
        {
            base.location = base.Move(direction, game.Boundaries);
            if(!game.WeaponInRoom.PickedUp)
            {
                if(this.Nearby(game.WeaponInRoom.Location, 1))
                {
                    game.WeaponInRoom.PickUpWeapon();
                    inventory.Add(game.WeaponInRoom);

                    if (inventory.Count == 1)
                        Equip(game.WeaponInRoom.Name);
                }
            }
        }

       public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon == null)
                return;

            // equipped weapon can be a sword or a potion
            equippedWeapon.Attack(direction, random);

            // in case it is a potion, it does not damage the enemy, 
            // but it will increase Player's health, and needs to be removed from inventory
            // as it is used only once
            if (equippedWeapon is IPotion)
            {
                inventory.Remove(equippedWeapon);
                if (inventory.Count > 0)
                {
                    equippedWeapon = inventory[0];
                    MessageBox.Show("You have been equipped with a " + equippedWeapon.Name);
                }
                else {
                    MessageBox.Show("You drank your potion but have no weapons in inventory ");
                    equippedWeapon = null;
                }
            }
            if (equippedWeapon is IBomb) {
                inventory.Remove(equippedWeapon);
                if (inventory.Count > 0) {
                    equippedWeapon = inventory[0];
                    MessageBox.Show("You have been quipped with a " + equippedWeapon.Name);
                }
                else {
                    MessageBox.Show("You have used the bomb and have no weapons left in inventory");
                    equippedWeapon = null;
                }
            }

        }
    }
}
