﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        List<Student> Passed = new List<Student>();
        List<Student> Failed = new List<Student>();
        Stack<Student> stack1 = new Stack<Student>();
        Queue<Student> Q1 = new Queue<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "TextFile|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    StreamReader Reader = new StreamReader(dlg.FileName);
                    string line = Reader.ReadLine();
                    while (!Reader.EndOfStream)
                    {
                        line = Reader.ReadLine();
                        string[] Parts = line.Split(new char[]{' ','\t'},
                            StringSplitOptions.RemoveEmptyEntries);
                        Student S = new Student();
                        S.Id = Parts[0];
                        S.Fname = Parts[1];
                        S.Lname = Parts[2];
                        S.Mid =double.Parse( Parts[3]);
                        S.Final = double.Parse(Parts[4]);
                        S.Quizes = double.Parse(Parts[5]);
                        if (S.Total >= 50)
                        {
                            Passed.Add(S);
                            stack1.Push(S);
                        }
                        else
                        {
                            Failed.Add(S);
                            Q1.Enqueue(S);
                        }


                     


                    }
                    Reader.Close();
                    Program.MyList.AddRange(Passed);
                    Program.MyList.AddRange(Failed);
                  

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(stack1.Pop().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Q1.Peek().ToString());
        } 
    }
}
