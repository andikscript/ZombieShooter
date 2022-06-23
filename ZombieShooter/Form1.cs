namespace ZombieShooter
{
    public partial class Form1 : Form
    {
        bool goRight, goLeft, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombiSpeed = 3;
        int score;
        Random rand = new Random();

        List<PictureBox> zombieList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimer(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
            }

            labelAmmo.Text = "Ammo : " + ammo;
            labelKills.Text = "Kills : " + score;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }

            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }

            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.D)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.S)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }

            if (e.KeyCode == Keys.W)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
        }

        private void MouseIsClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShootBullet(facing);
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.S)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.W)
            {
                goUp = false;
            }
        }

        private void ShootBullet(string direction)
        {
            Bullet bullet = new Bullet();
            bullet.direction = direction;
            bullet.bulletLeft = player.Left + (player.Width / 2);
            bullet.bulletTop = player.Top + (player.Height / 2);
            bullet.MakeBullet(this);
        }

        private void MakeZombies()
        {

        }

        private void RestartGame()
        {

        }
    }
}