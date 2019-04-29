using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisitorPattern
{
    public partial class Form1 : Form
    {
        private bool IronKnightChoose = false;
        private bool GoldenKnightChoose = false;
        private bool HammerOrkChoose = false;
        private bool AxeOrkChoose = false;
        private Human ironKnight = new IronKnight();
        private Human goldenKnight = new GoldenKnight();
        private Monster hammerOrk = new HammerOrk();
        private Monster axeOrk = new AxeOrk();
        private List<Image> IronKnightList = new List<Image>()
        {
            Properties.Resources.iron0,
            Properties.Resources.iron1,
            Properties.Resources.iron2,
            Properties.Resources.iron3,
            Properties.Resources.iron4,
            Properties.Resources.iron5,
            Properties.Resources.iron6,
            Properties.Resources.iron0
        };
        private List<Image> GoldenKnightList = new List<Image>()
        {
            Properties.Resources.golden0,
            Properties.Resources.golden1,
            Properties.Resources.golden2,
            Properties.Resources.golden3,
            Properties.Resources.golden4,
            Properties.Resources.golden5,
            Properties.Resources.golden6,
            Properties.Resources.golden0
        };
        private List<Image> HammerOrkDieList = new List<Image>()
        {
            Properties.Resources.ork_die__1_,
            Properties.Resources.ork_die__2_,
            Properties.Resources.ork_die__3_,
            Properties.Resources.ork_die__4_,
            Properties.Resources.ork_die__5_,
            Properties.Resources.ork_die__6_,
            Properties.Resources.ork_die__7_
        };
        private List<Image> AxeOrkDieList = new List<Image>()
        {
            Properties.Resources.axe_ork_die__1_,
            Properties.Resources.axe_ork_die__2_,
            Properties.Resources.axe_ork_die__3_,
            Properties.Resources.axe_ork_die__4_,
            Properties.Resources.axe_ork_die__5_,
            Properties.Resources.axe_ork_die__6_,
            Properties.Resources.axe_ork_die__7_
        };

        public Form1()
        {
            InitializeComponent();
            lblHammerOrkHp.Text = hammerOrk.getHp().ToString();
            lblAxeOrkHp.Text = axeOrk.getHp().ToString();
        }


        private void pbIronKnight_Click(object sender, EventArgs e)
        {
            IronKnightChoose = !IronKnightChoose;
            if (IronKnightChoose)
            {
                pbIronKnight.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pbIronKnight.BorderStyle = BorderStyle.None;
            }
        }

        private void pbGoldenKnight_Click(object sender, EventArgs e)
        {
            GoldenKnightChoose = !GoldenKnightChoose;
            if (GoldenKnightChoose)
            {
                pbGoldenKnight.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pbGoldenKnight.BorderStyle = BorderStyle.None;
            }
        }

        private void pbHammerOrk_Click(object sender, EventArgs e)
        {
            HammerOrkChoose = !HammerOrkChoose;
            if (HammerOrkChoose)
            {
                pbHammerOrk.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pbHammerOrk.BorderStyle = BorderStyle.None;
            }

            if (IronKnightChoose)
            {
                ironKnight.hit(hammerOrk);
            }
            else if (GoldenKnightChoose)
            {
                goldenKnight.hit(hammerOrk);
            }
            updateUI(sender);
            if (hammerOrk.getHp() == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    pbHammerOrk.Image = HammerOrkDieList[i];
                    wait(100);
                }
            }
            lblHammerOrkHp.Text = hammerOrk.getHp().ToString();
            wait(500);
            newTurn();

            
        }
        private void pbAxeOrk_Click(object sender, EventArgs e)
        {
            AxeOrkChoose = !AxeOrkChoose;
            if (AxeOrkChoose)
            {
                pbAxeOrk.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                pbAxeOrk.BorderStyle = BorderStyle.None;
            }

            if (IronKnightChoose)
            {
                ironKnight.hit(axeOrk);

            }
            else if (GoldenKnightChoose)
            {
                goldenKnight.hit(axeOrk);
            }
            updateUI(sender);
            if (axeOrk.getHp() == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    pbAxeOrk.Image = AxeOrkDieList[i];
                    wait(100);
                }
            }
            lblAxeOrkHp.Text = axeOrk.getHp().ToString();
            wait(500);
            newTurn();
            
        }

        private void updateUI(object sender)
        {
            if (IronKnightChoose)
            {
                Point CurrentPoint = pbIronKnight.Location;
                int x, y;
                PictureBox temp = (PictureBox)sender;
                x = temp.Location.X - 180;
                y = temp.Location.Y;
                pbIronKnight.Location = new Point(x, y);

                for (int i = 0; i < 8; i++)
                {
                    pbIronKnight.Image = IronKnightList[i];
                    wait(150);
                }

                pbIronKnight.Location = CurrentPoint;
            }
            else if (GoldenKnightChoose)
            {
                Point CurrentPoint = pbGoldenKnight.Location;
                int x, y;
                PictureBox temp = (PictureBox)sender;
                x = temp.Location.X - 180;
                y = temp.Location.Y;
                pbGoldenKnight.Location = new Point(x, y);

                for (int i = 0; i < 8; i++)
                {
                    pbGoldenKnight.Image = GoldenKnightList[i];
                    wait(150);
                }

                pbGoldenKnight.Location = CurrentPoint;
            }
        }

        private void newTurn()
        {
            IronKnightChoose = false;
            GoldenKnightChoose = false;
            HammerOrkChoose = false;
            AxeOrkChoose = false;
            pbAxeOrk.BorderStyle = BorderStyle.None;
            pbHammerOrk.BorderStyle = BorderStyle.None;
            pbIronKnight.BorderStyle = BorderStyle.None;
            pbGoldenKnight.BorderStyle = BorderStyle.None;
        }
        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0)
            {
                return;
            }
            //Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            IronKnightChoose = false;
            GoldenKnightChoose = false;
            HammerOrkChoose = false;
            AxeOrkChoose = false;
            pbAxeOrk.BorderStyle = BorderStyle.None;
            pbHammerOrk.BorderStyle = BorderStyle.None;
            pbIronKnight.BorderStyle = BorderStyle.None;
            pbGoldenKnight.BorderStyle = BorderStyle.None;

            hammerOrk = new HammerOrk();
            axeOrk = new AxeOrk();

            lblHammerOrkHp.Text = hammerOrk.getHp().ToString();
            lblAxeOrkHp.Text = axeOrk.getHp().ToString();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public interface Human
    {
        void hit(Monster monster);
    }
    public interface Monster
    {
        int getHp();
        void hitBy(IronKnight ironKnight);
        void hitBy(GoldenKnight goldenKnight);
    }
    public class IronKnight : Human
    {
        public void hit(Monster monster)
        {
            monster.hitBy(this);
        }
    }
    public class GoldenKnight : Human
    {
        public void hit(Monster monster)
        {
            monster.hitBy(this);
        }
    }
    public class HammerOrk : Monster
    {
        private int hp = 30;

        public void damaged(int hp)
        {
            this.hp -= hp;
            if (this.hp < 0)
            {
                this.hp = 0;
            }
        }

        public int getHp()
        {
            return hp;
        }

        public void hitBy(IronKnight ironKnight)
        {
            damaged(10);
        }

        public void hitBy(GoldenKnight goldenKnight)
        {
            damaged(20);
        }
    }
    public class AxeOrk : Monster
    {
        private int hp = 50;

        public void damaged(int hp)
        {
            this.hp -= hp;
            if (this.hp < 0)
            {
                this.hp = 0;
            }
        }

        public int getHp()
        {
            return hp;
        }

        public void hitBy(IronKnight ironKnight)
        {
            damaged(7);
        }

        public void hitBy(GoldenKnight goldenKnight)
        {
            damaged(15);
        }
    }

}
