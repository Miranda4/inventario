using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace inventario
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";
            numericUpDown4.Text = "";
            numericUpDown5.Text = "";
            numericUpDown6.Text = "";
            numericUpDown7.Text = "";
            numericUpDown8.Text = "";
        }

        private string fecha()
        {
            var date = dateTimePicker1.Value.ToShortDateString();
            return date;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();


            string date = fecha();



            string[] campo = new string[6];
            

            if (!File.Exists("camara9.txt"))
            {
                StreamWriter archivo = new StreamWriter("camara9.txt");
                archivo.Close();
            }
            else
            {
                //camara9
                StreamReader archivo = new StreamReader("camara9.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo = aux.Split(",");

                    string tipo = campo[0];
                    string premezcla = campo[1];
                    string material = campo[2];
                    string lote = campo[3];
                    string kg = campo[4];
                    string fecha = campo[5];
                    string id = campo[6];



                    if (date == fecha && tipo == "ALFA")
                    {
                        dataGridView2.Rows.Add(tipo,premezcla, material, lote, kg, fecha,id);
                    }


                }
                archivo.Close();

                //templado
                StreamReader archivo2 = new StreamReader("templado.txt");
                while (!archivo2.EndOfStream)
                {
                    var aux = archivo2.ReadLine();
                    campo = aux.Split(",");

                    string tipo = campo[0];
                    string premezcla = campo[1];
                    string material = campo[2];
                    string lote = campo[3];
                    string kg = campo[4];
                    string fecha = campo[5];
                    string id = campo[6];



                    if (date == fecha && tipo == "ALFA")
                    {
                        dataGridView2.Rows.Add(tipo, premezcla, material, lote, kg, fecha, id);
                    }


                }
                archivo2.Close();
            }

            //prePavo

            string[] campo2 = new string[6];

            if (!File.Exists("templado.txt"))
            {
                StreamWriter archivo = new StreamWriter("templado.txt");
                archivo.Close();
            }
            else
            {
                //camara9
                StreamReader archivo = new StreamReader("camara9.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo = aux.Split(",");

                    string tipo = campo[0];
                    string premezcla = campo[1];
                    string material = campo[2];
                    string lote = campo[3];
                    string kg = campo[4];
                    string fecha = campo[5];
                    string id = campo[6];



                    if (date == fecha && tipo == "PAVO")
                    {
                        dataGridView3.Rows.Add(tipo, premezcla, material, lote, kg, fecha, id);
                    }


                }
                archivo.Close();

                //templado
                StreamReader archivo2 = new StreamReader("templado.txt");
                while (!archivo2.EndOfStream)
                {
                    var aux = archivo2.ReadLine();
                    campo = aux.Split(",");

                    string tipo = campo[0];
                    string premezcla = campo[1];
                    string material = campo[2];
                    string lote = campo[3];
                    string kg = campo[4];
                    string fecha = campo[5];
                    string id = campo[6];



                    if (date == fecha && tipo == "PAVO")
                    {
                        dataGridView3.Rows.Add(tipo, premezcla, material, lote, kg, fecha, id);
                    }


                }
                archivo2.Close();
            }

            //extra1

            string[] campo3 = new string[7];

            if (!File.Exists("salesAlfa.txt"))
            {
                StreamWriter archivo = new StreamWriter("salesAlfa.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("salesAlfa.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo3 = aux.Split(",");
                    string tipo = campo3[0];
                    string humedad = campo3[1];
                    string grasa = campo3[2];
                    string sal = campo3[3];
                    string nitrito = campo3[4];
                    string fecha = campo3[5];

                    if (date == fecha)
                    {
                        dataGridView4.Rows.Add(tipo, humedad, grasa, sal, nitrito, fecha);
                    }
                }
                archivo.Close();
            }

            //extra2

            string[] campo4 = new string[7];

            if (!File.Exists("salesPavo.txt"))
            {
                StreamWriter archivo = new StreamWriter("salesPavo.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("salesPavo.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo4 = aux.Split(",");
                    string tipo = campo4[0];
                    string humedad = campo4[1];
                    string grasa = campo4[2];
                    string sal = campo4[3];
                    string nitrito = campo4[4];
                    string fecha = campo4[5];
                    if (date == fecha)
                    {
                        dataGridView5.Rows.Add(tipo, humedad, grasa, sal, nitrito, fecha);
                    }
                }
                archivo.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //sales

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text.Length == 0 && numericUpDown2.Text.Length == 0 && numericUpDown3.Text.Length == 0 && numericUpDown4.Text.Length == 0)
            {
                MessageBox.Show("NO pueden quedar todos los campos vacios, favor de validar");
            }
            else
            {
                StreamWriter archivo = new StreamWriter("salesAlfa.txt", true);
                var fecha2 = fecha();
                archivo.WriteLine("ALFA" + "," + numericUpDown1.Text + "," + numericUpDown2.Text + "," + numericUpDown3.Text + "," + numericUpDown4.Text + "," + fecha2);
                archivo.Close();
                numericUpDown1.Text = "";
                numericUpDown2.Text = "";
                numericUpDown3.Text = "";
                numericUpDown4.Text = "";
                MessageBox.Show("Se agrego correctamente, favor de consultar la fecha de nuevo para visualizar lo registrado");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Text.Length == 0 && numericUpDown6.Text.Length == 0 && numericUpDown7.Text.Length == 0 && numericUpDown8.Text.Length == 0)
            {
                MessageBox.Show("NO pueden quedar todos los campos vacios, favor de validar");
            }
            else
            {
                StreamWriter archivo = new StreamWriter("salesPavo.txt", true);
                var fecha2 = fecha();
                archivo.WriteLine("PAVO" + "," + numericUpDown5.Text + "," + numericUpDown6.Text + "," + numericUpDown7.Text + "," + numericUpDown8.Text + "," + fecha2);
                archivo.Close();
                numericUpDown5.Text = "";
                numericUpDown6.Text = "";
                numericUpDown7.Text = "";
                numericUpDown8.Text = "";
                MessageBox.Show("Se agrego correctamente, favor de consultar la fecha de nuevo para visualizar lo registrado");
            }
        }


        private void GrabarSalesAlfa()
        {

        }
        //boton de cerrado
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
