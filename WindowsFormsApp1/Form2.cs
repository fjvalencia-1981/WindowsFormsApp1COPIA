﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("procesando.gif");
            pictureBox1.Location = new System.Drawing.Point(this.Width / 2 - pictureBox1.Width / 2, 
                                                            this.Height / 2 - pictureBox1.Width / 2);
        }
    }
}
