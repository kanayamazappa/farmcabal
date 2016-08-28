using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Interceptor;

namespace FarmCabal
{
    public partial class Form1 : Form
    {
        private bool start;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
        }

        public static void MySleep(int milesegundos)
        {
            DateTime dt = DateTime.Now + TimeSpan.FromMilliseconds(milesegundos);

            do { } while (DateTime.Now < dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //Input input = new Input();
                this.start = true;
                int countIndex = dataGridView1.RowCount - 1;
                int index = 0;
                dataGridView1.Rows[0].Selected = true;

                while (this.start)
                {
                    string _tecla;
                    int _milesegundos;

                    _tecla = "{" + dataGridView1.Rows[index].Cells[0].Value.ToString() + "}";
                    _milesegundos = Convert.ToInt32(dataGridView1.Rows[index].Cells[1].Value);

                    MySleep(_milesegundos);

                    SendKeys.SendWait(_tecla);
                        //.Send(_tecla);

                    //var hWnd = SendKeySample.FindWindow("Untitled - Notepad");
                    //var editBox = SendKeySample.FindWindow(hWnd, "edit");

                    //SendKeySample.SendKey(editBox, Keys.A);

                    //input.Load();
                    //input.SendKeys(Interceptor.Keys.Four);
                    //input.Unload();

                    if (index >= countIndex)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira a tecla e os milesegundos para execução!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string[] row = { textBox1.Text, textBox2.Text };
                dataGridView1.Rows.Add(row);
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.start = false;
        }
    }
}
