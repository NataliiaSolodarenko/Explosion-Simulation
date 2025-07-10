using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace course_work
{
    public partial class Form1 : Form
    {
        public int place_x;
        public int place_y;
        public int place_x_p = -30; 
        public int place_y_p =  -30;
        public bool mouse_p = false;
        public bool detector_p = false;

        private int[] place_l_x1;
        private int[] place_l_y1;
        private int[] place_l_x2;
        private int[] place_l_y2;
        public int count;
        public int ind;
        public bool mouse_l_1 = false; 
        public bool detector_l_1 = false;
        public bool mouse_l_2 = false; 
        public bool detector_l_2 = false;
        public bool okey_l = false;
        public int[] useless_lines;
        public int count_u_l;
        public bool question = false;

        public bool detector_play = false;
        public bool work = false;
        public int radius, r_;
        public int interval;


        public Form1()
        {
            InitializeComponent();
            radius = 25;
            this.count = 1;
            this.ind = 0;
            this.place_l_x1 = new int[count];
            this.place_l_y1 = new int[count];
            this.place_l_x2 = new int[count];
            this.place_l_y2 = new int[count];

            this.count_u_l = 0;
            this.useless_lines = new int[count_u_l];
            interval = 300;
        }

        //PREPARATION//
        private void line_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 4);

            g.DrawLine(p, 7, 7, 33, 33);
        }


        //CURSOR CHANGE VIA BUTTONS//
        private void arrow_Click(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Arrow;
        }

        private void point_Click(object sender, EventArgs e)
        {
            if (work == true)
            {
                timer1.Enabled = false;
                DialogResult result;
                result = MessageBox.Show("Sorry, but you cannot change the explosion origin while the explosion spread simulation is running.", "Unable to Move Explosion Origin", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (result == DialogResult.OK)
                    timer1.Enabled = true;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Cross;
                detector_p = true;
            }
        }

        private void line_Click(object sender, EventArgs e)
        {
            if (work == true)
            {
                timer1.Enabled = false;
                DialogResult result;
                result = MessageBox.Show("Sorry, but you cannot add obstacles while the explosion spread simulation is running.", "Unable to Add Obstacle", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (result == DialogResult.OK)
                    timer1.Enabled = true;
            }
            else
            {
                if (detector_l_2 == true)
                    detector_l_2 = false;
                if (detector_p == true)
                    detector_p = false;
                pictureBox1.Cursor = Cursors.Cross;
                detector_l_1 = true;
                question = true;
                if (okey_l == true)
                {
                    ind++;
                    count++;
                    Array.Resize(ref place_l_x1, count);
                    Array.Resize(ref place_l_y1, count);
                    Array.Resize(ref place_l_x2, count);
                    Array.Resize(ref place_l_y2, count);
                    okey_l = false;
                    mouse_l_1 = false;
                }
            }
        }
        

        //START AND UPDATE//
        private void play_pause_Click(object sender, EventArgs e)
        {
            if (work == false)
            {
                detector_play = true;
                timer1.Enabled = true;
                speed.Visible = true;
                interval = 300;
                speed.BackgroundImage = course_work.Properties.Resources.Speed_1;
                play_pause.BackgroundImage = course_work.Properties.Resources.Pause;
            }
            if (work == true)
            {
                timer1.Enabled = false;
                speed.Visible = false;
                play_pause.BackgroundImage = course_work.Properties.Resources.Play;
                work = false;
            }
        }

        private void speed_Click(object sender, EventArgs e)
        {
            if (timer1.Interval == 300)
            {
                interval = 150;
                speed.BackgroundImage = course_work.Properties.Resources.Speed_2;
            }
            if (timer1.Interval == 150)
            {
                interval = 100;
                speed.BackgroundImage = course_work.Properties.Resources.Speed_3;
            }
            if (timer1.Interval == 100)
            {
                interval = 300;
                speed.BackgroundImage = course_work.Properties.Resources.Speed_1;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            mouse_p = false;
            detector_p = false;
            mouse_l_1 = false;
            detector_l_1 = false;
            mouse_l_2 = false;
            okey_l = false;
            detector_play = false;
            speed.Visible = false;
            radius = 25;
            if (work == true)
            {
                timer1.Enabled = false;
                play_pause.BackgroundImage = course_work.Properties.Resources.Play;
                work = false;
            }
            ind = 0;
            count = 1;
            Array.Resize(ref place_l_x1, count);
            Array.Resize(ref place_l_y1, count);
            Array.Resize(ref place_l_x2, count);
            Array.Resize(ref place_l_y2, count);
            place_l_x1[0] = 0;
            place_l_y1[0] = 0;
            count_u_l = 0;
            Array.Resize(ref useless_lines, count_u_l);
            pictureBox1.Refresh();
        }


        //CURSOR POSITION//
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Cursor == Cursors.Cross)
            {
                place_x = e.X;
                place_y = e.Y;
                cord_x.Text = "x: " + Convert.ToString(place_x);
                cord_y.Text = "y: " + Convert.ToString(place_y);
            }
        }
        

        //PLACING A POINT AND OBSTACLES//
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Cursor == Cursors.Cross && detector_p == true)
            {
                place_x_p = place_x;
                place_y_p = place_y;
                mouse_p = true;
                pictureBox1.Refresh();
                pictureBox1.Cursor = Cursors.Arrow;
                detector_p = false;
            }
            if (pictureBox1.Cursor == Cursors.Cross && detector_l_2 == true)
            {
                place_l_x2[ind] = place_x;
                place_l_y2[ind] = place_y;
                mouse_l_2 = true; 
                pictureBox1.Refresh(); 
                pictureBox1.Cursor = Cursors.Arrow;
                detector_l_2 = false;
                okey_l = true;

            }
            if (pictureBox1.Cursor == Cursors.Cross && detector_l_1 == true)
            {
                place_l_x1[ind] = place_x;
                place_l_y1[ind] = place_y;
                place_l_x2[ind] = place_x + 3;
                place_l_y2[ind] = place_y + 3;
                mouse_l_1 = true;
                pictureBox1.Refresh();
                detector_l_1 = false;
            }
        }


        //PAINTING//
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Interval = 10;
            if (mouse_p == true)
            {
                Graphics g = e.Graphics;
                Pen p = new Pen(Color.Black, 1);

                g.FillEllipse(Brushes.Red, place_x_p - 6, place_y_p - 6, 11, 11);
                g.DrawEllipse(p, place_x_p - 6, place_y_p - 6, 11, 11);
            }

            if (detector_play == true)
            {
                work = true;
                timer1.Interval = interval;
                int a = place_x_p;
                int b = place_y_p;
                Graphics g = e.Graphics;
                Pen p = new Pen(Color.Red, 2);

                if (mouse_p == true)
                {
                    for (r_ = 25; r_ <= radius; r_ = r_ + 20)
                    {
                        for (int x = a - r_; x < a + r_; x++)
                        {
                            double y_ = Math.Sqrt(Math.Pow(r_, 2) - Math.Pow(x - a, 2)) + b;
                            int y = (int)y_;
                            int x2 = x + 1;
                            double y2_ = Math.Sqrt(Math.Pow(r_, 2) - Math.Pow(x2 - a, 2)) + b;
                            int y2 = (int)y2_;
                            Point[] curve = { new Point(x, y), new Point(x2, y2) };
                            Point[] curve2 = { new Point(x, b - (y - b)), new Point(x2, b - (y2 - b)) };
                            g.DrawCurve(p, curve);
                            g.DrawCurve(p, curve2);
                        }
                    }
                }
            }
            for (int index = 0; index < count; index++)
            {
                if (detector_play == true && mouse_l_2 == true)
                {
                    Graphics g = e.Graphics;

                    if (place_l_y1[index] > place_l_y2[index])
                    {
                        int y = place_l_y1[index];
                        place_l_y1[index] = place_l_y2[index];
                        place_l_y2[index] = y;
                        int x = place_l_x1[index];
                        place_l_x1[index] = place_l_x2[index];
                        place_l_x2[index] = x;
                    }

                    bool useless_boll = false;
                    if (place_l_x1[index] != 0 && place_l_y1[index] != 0 && place_l_x2[index] != 0 && place_l_y2[index] != 0)
                        for (int point_y = place_y_p - 6; point_y <= place_y_p + 5; point_y++)
                        {
                            for (int point_x = place_x_p - 6; point_x <= place_x_p + 5; point_x++)
                            {
                                if (point_y == (((place_l_y2[index] - place_l_y1[index]) * (point_x - place_l_x1[index])) / (place_l_x2[index] - place_l_x1[index])) + place_l_y1[index])
                                {
                                    count_u_l++;
                                    Array.Resize(ref useless_lines, count_u_l);
                                    useless_lines[count_u_l - 1] = index;
                                    useless_boll = true;
                                    point_x = place_x_p + 6;
                                    point_y = place_y_p + 6;
                                }
                            }
                        }

                    int gran_x = 60;
                    int gran_y = 60;
                    double y_mej = 70;
                    double y2_mej = 70;
                    double x_mej = 80;
                    double x2_mej = 80;

                    if (useless_boll != true)
                    {
                        if (place_l_y1[index] == place_l_y2[index])
                        {
                            if (place_l_y1[index] < place_y_p)
                            {
                                gran_y = 0;
                                x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                g.FillPolygon(Brushes.White, pol);
                            }
                            if (place_l_y1[index] > place_y_p)
                            {
                                gran_y = pictureBox1.Height;
                                x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                g.FillPolygon(Brushes.White, pol);
                            }
                        }
                        else if (place_l_x1[index] == place_l_x2[index])
                        {
                            if (place_l_x1[index] < place_x_p)
                            {
                                gran_x = 0;
                                y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                g.FillPolygon(Brushes.White, pol);
                            }
                            if (place_l_x1[index] > place_x_p)
                            {
                                gran_x = pictureBox1.Width;
                                y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                g.FillPolygon(Brushes.White, pol);
                            }
                        }
                        else
                        {
                            double y_p = (((place_l_y2[index] - place_l_y1[index]) * (place_x_p - place_l_x1[index])) / (place_l_x2[index] - place_l_x1[index])) + place_l_y1[index];
                            double x_p = (((place_l_x2[index] - place_l_x1[index]) * (place_y_p - place_l_y1[index])) / (place_l_y2[index] - place_l_y1[index])) + place_l_x1[index];

                            //x_з < x - 4 (boundary), х_р > x - 2 (boundary), y_p < y - 1 (boundary), y_p > y - 3 (boundary)
                            if (x_p > place_x_p && y_p < place_y_p) //1st quadrant
                            {
                                if ((place_x_p > place_l_x2[index] && place_x_p > place_l_x1[index]) || (place_y_p < place_l_y2[index] && place_y_p < place_l_y1[index]))
                                {//2nd or 4th quadrant
                                    if (place_x_p > place_l_x2[index] && place_x_p > place_l_x1[index]) //2nd quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x2[index] - place_l_x1[index])// кут меньше 45
                                        {
                                            gran_y = 0;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x2[index] - place_l_x1[index])// кут більше 45
                                        {
                                            gran_x = 0;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                    if (place_y_p < place_l_y2[index] && place_y_p < place_l_y1[index]) //4th quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x2[index] - place_l_x1[index])// кут меньше 45 - 4 чверть
                                        {
                                            gran_y = pictureBox1.Height;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x2[index] - place_l_x1[index])// кут більше 45 - 4 чверть
                                        {
                                            gran_x = pictureBox1.Width;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                }
                                else
                                {
                                    gran_x = pictureBox1.Width;
                                    gran_y = 0;
                                    x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                    y_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                    Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y_mej), new Point(gran_x, gran_y), new Point((int)x_mej, gran_y) };
                                    g.FillPolygon(Brushes.White, pol);
                                }
                            }
                            if (x_p < place_x_p && y_p < place_y_p) //2nd quadrant
                            {
                                if ((place_x_p < place_l_x2[index] && place_x_p < place_l_x1[index]) || (place_y_p < place_l_y2[index] && place_y_p < place_l_y1[index]))
                                {//1st quadrant or 3rd
                                    if (place_x_p < place_l_x2[index] && place_x_p < place_l_x1[index]) //1st quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x1[index] - place_l_x2[index])// кут меньше 45
                                        {
                                            gran_y = 0;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x1[index] - place_l_x2[index])// кут більше 45
                                        {
                                            gran_x = pictureBox1.Width;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                    if (place_y_p < place_l_y2[index] && place_y_p < place_l_y1[index])//3rd quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x1[index] - place_l_x2[index])// кут меньше 45
                                        {
                                            gran_y = pictureBox1.Height;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x1[index] - place_l_x2[index])// кут більше 45
                                        {
                                            gran_x = 0;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                }
                                else
                                {
                                    gran_x = 0;
                                    gran_y = 0;
                                    x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                    y_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                    Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y_mej), new Point(gran_x, gran_y), new Point((int)x_mej, gran_y) };
                                    g.FillPolygon(Brushes.White, pol);
                                }
                            }

                            if (x_p < place_x_p && y_p > place_y_p) //3rd quadrant
                            {
                                if ((place_x_p < place_l_x2[index] && place_x_p < place_l_x1[index]) || (place_y_p > place_l_y2[index] && place_y_p > place_l_y1[index]))
                                {//2nd quadrant or 4th
                                    if (place_x_p < place_l_x2[index] && place_x_p < place_l_x1[index]) // 4th quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x2[index] - place_l_x1[index])// кут меньше 45 
                                        {
                                            gran_y = pictureBox1.Height;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x2[index] - place_l_x1[index])// кут більше 45 
                                        {
                                            gran_x = pictureBox1.Width;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                    if (place_y_p > place_l_y2[index] && place_y_p > place_l_y1[index]) //2nd quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x2[index] - place_l_x1[index])// кут меньше 45
                                        {
                                            gran_y = 0;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x2[index] - place_l_x1[index])// кут більше 45
                                        {
                                            gran_x = 0;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                }
                                else
                                {
                                    gran_x = 0;
                                    gran_y = pictureBox1.Height;
                                    x_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                    y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                    Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x_mej, gran_y), new Point(gran_x, gran_y), new Point(gran_x, (int)y_mej) };
                                    g.FillPolygon(Brushes.White, pol);
                                }

                            }

                            if (x_p > place_x_p && y_p > place_y_p) //4th quadrant
                            {
                                if ((place_x_p > place_l_x2[index] && place_x_p > place_l_x1[index]) || (place_y_p > place_l_y2[index] && place_y_p > place_l_y1[index]))
                                {//1st quadrant or 3rd
                                    if (place_y_p > place_l_y2[index] && place_y_p > place_l_y1[index]) //1st quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x1[index] - place_l_x2[index])// кут меньше 45
                                        {
                                            gran_y = 0;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x1[index] - place_l_x2[index])// кут більше 45
                                        {
                                            gran_x = pictureBox1.Width;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                    if (place_x_p > place_l_x2[index] && place_x_p > place_l_x1[index])//3rd quadrant
                                    {
                                        if (place_l_y2[index] - place_l_y1[index] < place_l_x1[index] - place_l_x2[index])// кут меньше 45
                                        {
                                            gran_y = pictureBox1.Height;
                                            x_mej = (((place_x_p - place_l_x1[index]) * (gran_y - place_l_y1[index])) / (place_y_p - place_l_y1[index])) + place_l_x1[index];
                                            x2_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x2_mej, gran_y), new Point((int)x_mej, gran_y) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                        if (place_l_y2[index] - place_l_y1[index] > place_l_x1[index] - place_l_x2[index])// кут більше 45
                                        {
                                            gran_x = 0;
                                            y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                            y2_mej = (((place_y_p - place_l_y2[index]) * (gran_x - place_l_x2[index])) / (place_x_p - place_l_x2[index])) + place_l_y2[index];
                                            Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point(gran_x, (int)y2_mej), new Point(gran_x, (int)y_mej) };
                                            g.FillPolygon(Brushes.White, pol);
                                        }
                                    }
                                }
                                else
                                {
                                    gran_x = pictureBox1.Width;
                                    gran_y = pictureBox1.Height;
                                    y_mej = (((place_y_p - place_l_y1[index]) * (gran_x - place_l_x1[index])) / (place_x_p - place_l_x1[index])) + place_l_y1[index];
                                    x_mej = (((place_x_p - place_l_x2[index]) * (gran_y - place_l_y2[index])) / (place_y_p - place_l_y2[index])) + place_l_x2[index];
                                    Point[] pol = { new Point(place_l_x1[index], place_l_y1[index]), new Point(place_l_x2[index], place_l_y2[index]), new Point((int)x_mej, gran_y), new Point(gran_x, gran_y), new Point(gran_x, (int)y_mej) };
                                    g.FillPolygon(Brushes.White, pol);
                                }
                            }
                        }
                    }

                }
          
            }
            
            for (int index = 0; index < count; index++)
            {
                if (mouse_l_1 == true)
                {
                    Graphics g = e.Graphics;

                    g.FillEllipse(Brushes.Black, place_l_x1[index] - 2, place_l_y1[index] - 2, 5, 5);
                    mouse_l_1 = false;
                    detector_l_1 = false;
                    detector_l_2 = true;
                }
                if (mouse_l_2 == true)
                {
                    Graphics g = e.Graphics;
                    Pen p = new Pen(Color.Black, 4);

                    g.DrawLine(p, place_l_x1[index], place_l_y1[index], place_l_x2[index], place_l_y2[index]);
                }

            }

            if (count_u_l > 0 && question == true)
            {
                timer1.Enabled = false;
                DialogResult result;
                result = MessageBox.Show("There are obstacles in your simulation that either do not significantly affect the explosion spread or intersect with the explosion origin." + "\r\n" + "Would you like to remove these obstacles?" + "\r\n" + "\r\n" + "Number of such obstacles: " + count_u_l, "Obstructing Obstacles", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < count_u_l; i++)
                    {
                        place_l_y1[useless_lines[i]] = 0;
                        place_l_y2[useless_lines[i]] = 0;
                        place_l_x1[useless_lines[i]] = 0;
                        place_l_x2[useless_lines[i]] = 0;
                    }
                    timer1.Enabled = true;
                    question = false;
                }
                else if (result == DialogResult.No)
                {
                    timer1.Enabled = true;
                    question = false;
                }
            }
        }

        private void arrow_MouseMove(object sender, MouseEventArgs e)
        {
            place_x = e.X + arrow.Location.X;
            place_y = e.Y + arrow.Location.Y;
        }

        private void arrow_MouseHover(object sender, EventArgs e)
        {
            Label name_arrow = new Label();
            name_arrow.Name = "name_arrow";
            name_arrow.Text = "Cursor";
            name_arrow.Size = new Size(45, 15);
            name_arrow.Location = new Point(place_x + 20, place_y);
            name_arrow.BackColor = Color.WhiteSmoke;
            name_arrow.ForeColor = Color.FromArgb(237, 113, 23);
            this.Controls.Add(name_arrow);
            name_arrow.BringToFront();
            name_arrow.BringToFront();
        }

        private void arrow_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "name_arrow")
                {
                    ctrl.Visible = false;
                }
            }
        }

        private void point_MouseMove(object sender, MouseEventArgs e)
        {
            place_x = e.X + point.Location.X;
            place_y = e.Y + point.Location.Y;
        }

        private void point_MouseHover(object sender, EventArgs e)
        {
            Label name_point = new Label();
            name_point.Name = "name_point";
            name_point.Text = "Explosion start point";
            name_point.Size = new Size(75, 15);
            name_point.Location = new Point(place_x + 20, place_y);
            name_point.BackColor = Color.WhiteSmoke;
            name_point.ForeColor = Color.FromArgb(237, 113, 23);
            this.Controls.Add(name_point);
            name_point.BringToFront();
            name_point.BringToFront();
        }

        private void point_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "name_point")
                {
                    ctrl.Visible = false;
                }
            }
        }
        private void line_MouseMove(object sender, MouseEventArgs e)
        {
            place_x = e.X + line.Location.X;
            place_y = e.Y + line.Location.Y;
        }

        private void line_MouseHover(object sender, EventArgs e)
        {
            Label name_line = new Label();
            name_line.Name = "name_line";
            name_line.Text = "Obstacle";
            name_line.Size = new Size(65, 15);
            name_line.Location = new Point(place_x + 20, place_y);
            name_line.BackColor = Color.WhiteSmoke;
            name_line.ForeColor = Color.FromArgb(237, 113, 23);
            this.Controls.Add(name_line);
            name_line.BringToFront();
            name_line.BringToFront();
        }

        private void line_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "name_line")
                {
                    ctrl.Visible = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            radius = radius + 10;
            pictureBox1.Invalidate();
        }
    }
}
