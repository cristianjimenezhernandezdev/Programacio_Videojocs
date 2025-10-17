using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Side_Scrolling_Platform_Game
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            foreach (Control x in this.Controls)
            {
                System.Reflection.PropertyInfo prop =
                typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                prop.SetValue(x, true, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            MoureVertical();
            MoureHoritzontal();
            MoureBackground();
            Colisions();
            mort();
        } 
        //---------------Metodes-----------------------------------------------------------
        private void MoureVertical()
        {
            player.Top += Settings.jumpSpeed;
            // refresh the player picture box consistently 
            player.Refresh();
            // if jumping is true and force is less than 0 // then change jumping to false 
            if (Settings.jumping && Settings.force < 0)
            {
                Settings.jumping = false;
            }

            // if jumping is true // then change jump speed to -12 // reduce force by 1
            if (Settings.jumping)
            {
                Settings.jumpSpeed = -12;
                Settings.force -= 1;
            }
            else
            { // else change the jump speed to 12 
                Settings.jumpSpeed = 12;
            }
        }
        private void MoureHoritzontal()
        {
            // if go left is true and players left is greater than 100 pixels
            // only then move player towards left of the
            if (Settings.goleft && player.Left > Settings.margePantalla)
            {
                player.Left -= Settings.playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms left
            // if go right Boolean is true
            // player left plus players width plus 100 is less than the forms width
            // then we move the player towards the right by adding to the players left
            if (Settings.goright && player.Left + (player.Width + Settings.margePantalla) < this.ClientSize.Width)
            {
                player.Left += Settings.playSpeed;
            }
        }
        private void MoureBackground()
        {
            // by doing the if statement above, the player picture will stop on the forms right 
            // if go right is true and the background picture left is greater 1352 
            // then we move the background picture towards the left 
            if (Settings.goright && background.Left > Settings.backgroundLimitEsquerra)
            {
                background.Left -= Settings.backLeft;
                sky.Left -= Settings.skyLeft;
                // the for loop below is checking to see the platforms and coins in the level 
                // when they are found it will move them towards the left
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left -= Settings.backLeft;
                    }
                }
            }
            // if go left is true and the background pictures left is less than 2 
            // then we move the background picture towards the right 
            if (Settings.goleft && background.Left < Settings.backgroundLimitDreta)
            {
                background.Left += Settings.backLeft;
                sky.Left += Settings.skyLeft;
                // below the is the for loop thats checking to see the platforms and coins in the level
                // when they are found in the level it will move them all towards the right with the background
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is PictureBox && x.Tag == "key")
                    {
                        x.Left += Settings.backLeft;
                    }
                }
            }
        }

        private void Colisions()
        {
            // below if the for loop thats checking for all of the controls in this form 
            foreach (Control x in this.Controls)
            {
                // is X is a picture box and it has a tag of platform 
                if (x is PictureBox && x.Tag == "platform")
                {
                    // then we are checking if the player is colliding with the platform
                    // and jumping is set to false
                    if (player.Bounds.IntersectsWith(x.Bounds) && !Settings.jumping)
                    {
                        // then we do the following
                        Settings.force = 8; // set the force to 8 
                        player.Top = x.Top - player.Height + 1; // also we place the player on top of the picture box 
                        Settings.jumpSpeed = 0; // set the jump speed to 0
                    }
                }
                // if the picture box found has a tag of coin 
                if (x is PictureBox && x.Tag == "coin")
                {
                    // now if the player collides with the coin picture box 
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x); // then we are going to remove the coin image 
                        Settings.score++; // add 1 to the score 
                    }
                }
            } // if the player collides with the door and has key boolean is true 
            if (player.Bounds.IntersectsWith(door.Bounds) && Settings.hasKey)
            { // then we change the image of the door to open 
                door.Image = Properties.Resources.door_open;
                // and we stop the timer 
                gameTimer.Stop();
                MessageBox.Show("You Completed the level!!"); // show the message box 
                //this.Hide();
                Nivell2 nivell = new Nivell2(this);                
                nivell.ShowDialog();
                
                

                
            }
            

            // if the player collides with the key picture box 
            if (player.Bounds.IntersectsWith(key.Bounds))
            {
                // then we remove the key from the game 
                this.Controls.Remove(key);
                // change the has key boolean to true 
                Settings.hasKey = true;
            }
        }
        private void mort()
        {
            // this is where the player dies 
            // if the player goes below the forms height then we will end the game 
            if (player.Top + player.Height > this.ClientSize.Height + Settings.deathMarge)
            {
                gameTimer.Stop(); // stop the timer 
                MessageBox.Show("You Died!!!"); // show the message box

            }
        }


        // linking the jumpspeed i
        private void keyisdown(object sender, KeyEventArgs e)
        {
            // then we set the car left boolean to true 
            if (e.KeyCode == Keys.Left)
            {
                Settings.goleft = true;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width 
            if (e.KeyCode == Keys.Right)
            { // then we set the player right to true 
                Settings.goright = true; 
            }
            //if the player pressed the space key and jumping boolean is false 
            if (e.KeyCode == Keys.Space && !Settings.jumping)
            { // then we set jumping to true
                Settings.jumping = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            // then we set the car left boolean to true 
            if (e.KeyCode == Keys.Left)
            {
                Settings.goleft = false;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width 
            if (e.KeyCode == Keys.Right)
            { // then we set the player right to true 
                Settings.goright = false;
            }

            if (Settings.jumping)
            {
                Settings.jumping = false;
            }
        }
    }
}
