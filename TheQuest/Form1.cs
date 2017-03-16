using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace TheQuest {

    enum Direction { Up, Down, Left, Right };

    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
            this.KeyPress +=
                new KeyPressEventHandler(Form1_KeyDown);
        }
        //WMPLib.WindowsMediaPlayer songPlayer;
        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(122, 57, 800, 265));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            player.Location = game.PlayerLocation;
            lblPlayerHitPoints.Text = game.PlayerHitPoints.ToString();

            int enemiesShown = 0;
            bat.Visible = false;
            ghost.Visible = false;
            ghoul.Visible = false;

            lblBatHitPoints.Text = "0";
            lblGhostHitPoints.Text = "0";
            lblGhoulHitPoints.Text = "0";

            foreach(Enemy enemy in game.Enemies)
            {
                if(enemy is Bat)
                {
                    if (!enemy.Dead)
                    {
                        bat.Visible = true;
                        bat.Location = enemy.Location;
                        lblBatHitPoints.Text = enemy.HitPoints.ToString();
                        enemiesShown++;
                    } else
                    {
                        bat.Visible = false;
                        lblBatHitPoints.Text = "0";
                    }
                }
                if (enemy is Ghost)
                {
                    if (!enemy.Dead)
                    {
                        ghost.Location = enemy.Location;
                        ghost.Visible = true;
                        lblGhostHitPoints.Text = enemy.HitPoints.ToString();
                        enemiesShown++;
                    } else
                    {
                        ghost.Visible = false;
                        lblGhostHitPoints.Text = "0";
                    }
                }
                if (enemy is Ghoul)
                {
                    if (!enemy.Dead)
                    {
                        ghoul.Location = enemy.Location;
                        ghoul.Visible = true;
                        lblGhoulHitPoints.Text = enemy.HitPoints.ToString();
                        enemiesShown++;
                    } else
                    {
                        ghoul.Visible = false;
                        lblGhoulHitPoints.Text = "0";
                    }
                }
            }

            sword.Visible = false;
            bow.Visible = false;
            mace.Visible = false;
            bomb.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;

            Control weaponControl = new Control();

            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword;
                    break;
                case "Bow":
                    weaponControl = bow;
                    break;
                case "Mace":
                    weaponControl = mace;
                    break;
                case "Bomb":
                    weaponControl = bomb;
                    break;
                case "Blue Potion":
                    weaponControl = bluePotion;
                    break;
                case "Red Potion":
                    weaponControl = redPotion;
                    break;
                default:
                    break;
            }
            weaponControl.Visible = true;

            if (game.CheckPlayerInventory("Sword"))
                inventorySwordPictureBox.Visible = true;
            else
                inventorySwordPictureBox.Visible = false;

            if (game.CheckPlayerInventory("Bow"))
                inventoryBowPictureBox.Visible = true;
            else
                inventoryBowPictureBox.Visible = false;

            if (game.CheckPlayerInventory("Mace"))
                inventoryMacePictureBox.Visible = true;
            else
                inventoryMacePictureBox.Visible = false;

            if (game.CheckPlayerInventory("Bomb"))
                inventoryBombPictureBox.Visible = true;
            else
                inventoryBombPictureBox.Visible = false;

            if (game.CheckPlayerInventory("Blue Potion"))
                inventoryBluePotionPictureBox.Visible = true;
            else
                inventoryBluePotionPictureBox.Visible = false;

            if (game.CheckPlayerInventory("Red Potion"))
                inventoryRedPotionPictureBox.Visible = true;
            else
                inventoryRedPotionPictureBox.Visible = false;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemy on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void drawAttackButton() {
            btnUpAttack.Text = "↑";
            btnLeftAttack.Visible = true;
            btnDownAttack.Visible = true;
            btnRightAttack.Visible = true;
        }

        private void drawPotionButton() {
            btnUpAttack.Text = "Drink";
            btnLeftAttack.Visible = false;
            btnRightAttack.Visible = false;
            btnDownAttack.Visible = false;
        }

        private void inventorySwordPictureBox_Click(object sender, EventArgs e)
        {
            string weaponName = "Sword";
            if (game.CheckPlayerInventory(weaponName))
            {
                game.Equip(weaponName);
                inventorySwordPictureBox.BorderStyle = BorderStyle.FixedSingle;
                inventoryBowPictureBox.BorderStyle = BorderStyle.None;
                inventoryMacePictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryBombPictureBox.BorderStyle = BorderStyle.None;
                drawAttackButton();
            }
        }

        private void inventoryBombPictureBox_Click(object sender, EventArgs e) {
            string weaponName = "Bomb";
            if (game.CheckPlayerInventory(weaponName)) {
                game.Equip(weaponName);
                inventorySwordPictureBox.BorderStyle = BorderStyle.None;
                inventoryBowPictureBox.BorderStyle = BorderStyle.None;
                inventoryMacePictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryBombPictureBox.BorderStyle = BorderStyle.FixedSingle;
                drawAttackButton();
            }
        }

        private void inventoryBowPictureBox_Click(object sender, EventArgs e)
        {
            string weaponName = "Bow";
            if (game.CheckPlayerInventory(weaponName))
            {
                game.Equip(weaponName);
                inventoryBowPictureBox.BorderStyle = BorderStyle.FixedSingle;
                inventorySwordPictureBox.BorderStyle = BorderStyle.None;
                inventoryMacePictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryBombPictureBox.BorderStyle = BorderStyle.None;
                drawAttackButton();
            }
        }

        private void inventoryMacePictureBox_Click(object sender, EventArgs e)
        {
            string weaponName = "Mace";
            if (game.CheckPlayerInventory(weaponName))
            {
                game.Equip(weaponName);
                inventoryMacePictureBox.BorderStyle = BorderStyle.FixedSingle;
                inventorySwordPictureBox.BorderStyle = BorderStyle.None;
                inventoryBowPictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryBombPictureBox.BorderStyle = BorderStyle.None;
                drawAttackButton();
            }
        }

        private void inventoryBluePotionPictureBox_Click(object sender, EventArgs e)
        {
            string weaponName = "Blue Potion";
            if (game.CheckPlayerInventory(weaponName)) {
                game.Equip(weaponName);
                inventoryMacePictureBox.BorderStyle = BorderStyle.None;
                inventorySwordPictureBox.BorderStyle = BorderStyle.None;
                inventoryBowPictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.FixedSingle;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryBombPictureBox.BorderStyle = BorderStyle.None;
                drawPotionButton();
            }
        }

        private void inventoryRedPotionPictureBox_Click(object sender, EventArgs e)
        {
            string weaponName = "Red Potion";
            if (game.CheckPlayerInventory(weaponName)) {
                game.Equip(weaponName);
                inventoryMacePictureBox.BorderStyle = BorderStyle.None;
                inventorySwordPictureBox.BorderStyle = BorderStyle.None;
                inventoryBowPictureBox.BorderStyle = BorderStyle.None;
                inventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                inventoryRedPotionPictureBox.BorderStyle = BorderStyle.FixedSingle;
                inventoryBombPictureBox.BorderStyle = BorderStyle.None;
                drawPotionButton();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void btnUpAttack_Click(object sender, EventArgs e)
        {
            if(btnUpAttack.Text == "Drink")
            {
                btnUpAttack.Text = "↑";
                btnLeftAttack.Visible = true;
                btnDownAttack.Visible = true;
                btnRightAttack.Visible = true;
            }
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void btnDownAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void btnLeftAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void btnRightAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void Form1_KeyDown(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 100) {
                game.Move(Direction.Left, random);
                UpdateCharacters();
            }
            if (e.KeyChar == 102) {
                game.Move(Direction.Right, random);
                UpdateCharacters();
            }
            if (e.KeyChar == 104) {
                game.Move(Direction.Up, random);
                UpdateCharacters();
            }
            if (e.KeyChar == 98) {
                game.Move(Direction.Down, random);
                UpdateCharacters();
            }
        }
    }
}
