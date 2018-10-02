using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox2.Parent = pictureBox10;
            pictureBox3.Parent = pictureBox10;
            pictureBox4.Parent = pictureBox10;
            pictureBox5.Parent = pictureBox10;
            pictureBox6.Parent = pictureBox10;
            pictureBox7.Parent = pictureBox10;
            pictureBox8.Parent = pictureBox10;
            pictureBox9.Parent = pictureBox10;

            Sputnic sp = new Sputnic(pictureBox4);
            sp.DrawCircle();

            timer1.Enabled = true;

            Planet nept = new Planet(pictureBox9,455 ,300);
            nept.v(430, 285, 6, 1.5);
            Planet urun = new Planet(pictureBox8, 455, 300);
            urun.v(395, 255, 7, 1.0);
            Planet sat = new Planet(pictureBox7, 455, 300);
            sat.v(360, 225, 10, 0.5);
            Planet yup = new Planet(pictureBox6, 455, 300);
            yup.v(325, 195, 13, 0.0);
            Planet mars = new Planet(pictureBox5, 455, 300);
            mars.v(295, 170, 24, 1.5);
            Planet zem = new Planet(pictureBox4, 455, 300);
            zem.v(265, 145, 30, 1.0);
            Planet ven = new Planet(pictureBox3, 455, 300);
            ven.v(230, 120, 35, 0.5);
            Planet merk = new Planet(pictureBox2, 455, 300);
            merk.v(180, 90, 48, 0.0);


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int x=50, y=50, w=860, h=550;
            
            Pen myPen = new Pen(Color.White, 1); 
            Graphics g = Graphics.FromHwnd(pictureBox10.Handle);
            pictureBox1.Left = x + 380;
            pictureBox1.Top = y + 225;
            for (int i=0; i<8; i++)
            {
                g.DrawEllipse(myPen, x, y, w, h);
                x += 35;
                y += 25;
                w -= 70;
                h -= 50;
                
            }

        }

        public Form1()
        {
            InitializeComponent();
            
        }


    }
    public class Planet : PictureBox
    {
        PictureBox name;
        double w, h;
        public Planet(PictureBox name, double w, double h)
        {
            this.name = name;
            this.w = w;
            this.h = h;
        }

        public void  v(double a, double b , int i, double an)
        {
            var time=0;
            var timer = new Timer();
            timer.Interval = i;
            timer.Tick += (sender, args) =>
             {

                 name.Left = (int)(a * Math.Cos(an)+w);
                 name.Top = (int)(b * Math.Sin(an)+h);
                 an += 0.1;
                 if (an > 2 * Math.PI)
                     an = 0;
                 this.Invalidate();
                 time++; 
             };
            timer.Start();


        }
    }


    public class Sputnic : PictureBox
    {
        PictureBox name;

        public Sputnic(PictureBox name)
        {
            this.name = name;
        }
        public void DrawCircle()
        {
            Graphics gr = name.CreateGraphics();
            
            Pen myPen = new Pen(Color.Gray, 1); 
            Bitmap bmp = new Bitmap(name.Width, name.Height);
            bmp = (Bitmap)name.Image;

            float x, y, a=35, b=20;
            double an = 0;
            var time = 0;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) =>
            {
                x = (int)(a * Math.Cos(an) + 25);
                y = (int)(b * Math.Sin(an) + 12);
                gr.FillEllipse(Brushes.Gray, x, y, 10,10);
                gr.DrawEllipse(myPen, x, y, 10, 10);                
                an += 0.1;
                if (an > 1 * Math.PI)
                    an = 0;
                this.Invalidate();
                time++;
            };
            timer.Start();

        }

    }

}
