﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student S = new Student();
                S.Id = textBox1.Text;
                S.Fname = textBox2.Text;
                S.Lname = textBox3.Text;
                S.Mid = double.Parse(textBox4.Text);
                S.Final = double.Parse(textBox5.Text);
                S.Quizes = double.Parse(textBox6.Text);
                Program.MyList.Insert(0,S);
                this.Close();
            }
            catch (Exception EX)
            { MessageBox.Show(EX.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
