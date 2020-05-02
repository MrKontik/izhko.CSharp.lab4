using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7exp2
{
    public partial class Form1 : Form
    {
        ToolTip toolTip1;
        public Form1()
        {
            InitializeComponent();
            toolTip1 = new ToolTip();
            trackBar1.Value = 5;
            trackBar2.Value = 5;
            trackBar3.Value = 5;
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(trackBar1.Value , trackBar2.Value, trackBar3.Value);
            panel1.BackColor = myRgbColor;
            Clipboard.SetText("#" + Convert.ToString(trackBar1.Value, 16).PadLeft(2,'0') + Convert.ToString(trackBar2.Value, 16).PadLeft(2, '0') + Convert.ToString(trackBar3.Value, 16).PadLeft(2, '0'));
            toolTip1.SetToolTip(panel1, Clipboard.GetText());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(trackBar1.Value , trackBar2.Value , trackBar3.Value );
            panel1.BackColor = myRgbColor;

            string str1 = Convert.ToString(trackBar1.Value * 25, 16).PadLeft(2);
            Clipboard.SetText("#"+ Convert.ToString(trackBar1.Value , 16).PadLeft(2, '0') + Convert.ToString(trackBar2.Value, 16).PadLeft(2, '0') + Convert.ToString(trackBar3.Value, 16).PadLeft(2, '0'));
            toolTip1.SetToolTip(panel1, Clipboard.GetText());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
