using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace lab7exp1
{
    public partial class Form1 : Form
    {
        public const double dis = 40;
        int changes = 2;
        int d1;
        int d2;
        public Form1()
        {
            InitializeComponent();
            button1.Location = new Point((Width / 2) - (button1.Width / 2), Height / 2 - button1.Height / 2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!");
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Text = Height + " " + (button1.Location.Y + button1.Height);
            double lenth = Math.Sqrt(Math.Pow(e.X - button1.Location.X, 2) + Math.Pow(e.Y - button1.Location.Y, 2));
            double lenth2 = Math.Sqrt(Math.Pow(e.X - button1.Location.X-button1.Width, 2) + Math.Pow(e.Y - button1.Location.Y-button1.Height, 2));
            double lenth3 = Math.Sqrt(Math.Pow(e.X - button1.Location.X , 2) + Math.Pow(e.Y - button1.Location.Y - button1.Height, 2));
            double lenth4 = Math.Sqrt(Math.Pow(e.X - button1.Location.X - button1.Width, 2) + Math.Pow(e.Y - button1.Location.Y , 2));
            if ((lenth < dis || lenth2 < dis || lenth3 < dis || lenth4 < dis) &&
                Math.Abs(button1.Location.X ) > 10 &&
                Math.Abs(button1.Location.Y ) > 10 &&
                Math.Abs(button1.Location.X+button1.Width) < Width -30 &&
                Math.Abs(button1.Location.Y + button1.Height) < Height -30)
            {
                double sinus = (button1.Location.Y + (button1.Height/2) - e.Y) / lenth;
                double cosinus = (button1.Location.X+ (button1.Width/2) - e.X) / lenth;
                if (sinus >= 0.5)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + changes);
                if (sinus <= -0.5)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y - changes);
                if (cosinus >= 0.5)
                    button1.Location = new Point(button1.Location.X + changes, button1.Location.Y);
                if (cosinus <= -0.5)
                    button1.Location = new Point(button1.Location.X - changes, button1.Location.Y);
               
            }

        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            //button1.Location = new Point(Width*(d2/100), Height*(d2/100));
            button1.Location = new Point(Width * d2 / 100, Height * d1 / 100);
        }
        private void Form1_Resize_Begin(object sender, System.EventArgs e)
        {
            d1 = 100* button1.Location.Y / Height;
            d2 = 100* button1.Location.X / Width; 
        }
    }
}
