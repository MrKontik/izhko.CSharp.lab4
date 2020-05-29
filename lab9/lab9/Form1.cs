using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    { 
        Random rand = new Random();
        int countPoint;
        int countPointCircle;
        bool stop;
        int areaSquare;
        public Form1()
        {
            InitializeComponent(); 
            countPoint = 0;
            countPointCircle = 0;
            timer1.Enabled = true;
            timer1.Interval = 100;
            stop = false;
            areaSquare = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            areaSquare = Int32.Parse(textBox1.Text)* Int32.Parse(textBox1.Text)*4;
            stop = false;
            Graphics formGraphics = this.CreateGraphics();
            Pen myPen = new Pen(Color.Red); 
            formGraphics.DrawRectangle(myPen, 300, 0, Int32.Parse(textBox1.Text), Int32.Parse(textBox1.Text));
            myPen.Color = Color.Blue;
            formGraphics.DrawEllipse(myPen, new Rectangle(300, 0, Int32.Parse( textBox1.Text), Int32.Parse(textBox1.Text)));
            myPen.Dispose();
            formGraphics.Dispose();
            for (int i=0;i< Int32.Parse(textBox2.Text);i++)
            {
                Task.Factory.StartNew(DrawRandomPoint);
            }
            
        }
        public void DrawRandomPoint()
        {
            Color color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            int size= Int32.Parse(textBox1.Text);
            int wait = Int32.Parse(textBox3.Text);
            Graphics formGraphics1= this.CreateGraphics();
            
            while (!stop)
            {
                int x = rand.Next(0, size);
                int y = rand.Next(0, size);
                formGraphics1.FillRectangle(new SolidBrush(color), 300 +x  , 0 +y , 1, 1);
                countPoint++;
                if (Math.Sqrt(Math.Pow(x-size/2,2)+ Math.Pow(y - size / 2, 2))  <size/2)
                {
                    countPointCircle++;
                }
                Thread.Sleep(wait);
            }
            formGraphics1.Dispose();
            //ассинхроность, параллельность, многопоточность
            //потоки безопасно как сделать
        } 

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = ""+countPoint + "\n"+countPointCircle; 
            try
            {
                label7.Text = "" + areaSquare * countPointCircle / countPoint;
            }
            catch(Exception)
            {
                label7.Text = ""+0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
