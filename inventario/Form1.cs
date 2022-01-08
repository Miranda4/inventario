using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace inventario
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dataGridView1.MultiSelect = false;

            //this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dataGridView2.MultiSelect = false;


            textBox15.Text = "";
            numericUpDown1.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                GrabarDatos();
                bool exist = dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["LOTE"].Value) == textBox11.Text);

                if (exist == true || textBox10.Text.Length == 0 || textBox11.Text.Length == 0 || textBox12.Text.Length == 0 || textBox13.Text.Length == 0 || textBox14.Text.Length == 0 || textBox15.Text.Length == 0)
                {
                }
                else
                {
                    dataGridView1.Rows.Add(textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, dateTimePicker1.Value.ToShortDateString());
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    Form form1 = new Form1();
                    this.Hide();
                    form1.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void GrabarDatos()
        {
            try
            {
                if (textBox10.Text.Length == 0 || textBox11.Text.Length == 0 || textBox12.Text.Length == 0 || textBox13.Text.Length == 0 || textBox14.Text.Length == 0 || textBox15.Text.Length == 0)
                {
                    MessageBox.Show("No pueden quedar campos vacios, favor de verificar");
                }
                else
                {
                    bool exist = dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["LOTE"].Value) == textBox11.Text);

                    if (exist == true)
                    {
                        MessageBox.Show("LOTE ya registrado, favor de validar");
                    }
                    else
                    {
                        string datetime = DateTime.Now.ToString("dd/MM/yyyy");
                        string fechaIngreso = datetime;
                        StreamWriter archivo = new StreamWriter("almacen.txt", true);
                        var fecha = dateTimePicker1.Value.ToShortDateString();
                        archivo.WriteLine(textBox10.Text + "," + textBox11.Text + "," + textBox12.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox15.Text + "," + fecha + "," + fechaIngreso);
                        archivo.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al grabar datos");
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void colorearFilas()
        {
            dataGridView1.Rows.Cast<DataGridViewRow>().
                          ToList().
                          ForEach(fila =>
                          {

                              string fecha = fila.Cells["fechaIngreso"].Value.ToString();

                              DateTime fechaUno = Convert.ToDateTime(fecha);
                              var fechaCorta = fechaUno.ToString("dd/MM/yyyy");
                              var datetime = DateTime.Now;
                              DateTime fecha2 = Convert.ToDateTime(fechaCorta);

                              int diferencia = (datetime - fecha2).Days;
                              if (diferencia > 4)
                              {
                                  fila.DefaultCellStyle.BackColor = Color.Tomato;
                              }
                              else
                              {
                                  fila.DefaultCellStyle.BackColor = Color.LightGreen;
                              }
                          });
        }

    private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                string[] campo = new string[9];

                if (!File.Exists("almacen.txt"))
                {
                    StreamWriter archivo = new StreamWriter("almacen.txt");
                    archivo.Close();
                }
                else
                {
                    StreamReader archivo = new StreamReader("almacen.txt");
                    while (!archivo.EndOfStream)
                    {
                        var aux = archivo.ReadLine();
                        campo = aux.Split(",");
                        string clavesap = campo[0];
                        string lote = campo[1];
                        string material = campo[2];
                        string descripcion = campo[3];
                        string proveedor = campo[4];
                        string kgllegados = campo[5];
                        string fechacaducidad = campo[6];
                        string fechaingreso = campo[7];

                        dataGridView1.Rows.Add(clavesap, lote, material, descripcion, proveedor, kgllegados, fechacaducidad, fechaingreso);

                    }
                    archivo.Close();
                }
                //alfas

                string[] campo2 = new string[7];

                if (!File.Exists("alfas.txt"))
                {
                    StreamWriter archivo = new StreamWriter("alfas.txt");
                    archivo.Close();
                }
                else
                {
                    StreamReader archivo = new StreamReader("alfas.txt");
                    while (!archivo.EndOfStream)
                    {
                        var aux = archivo.ReadLine();
                        campo2 = aux.Split(",");
                        string tipo = campo2[0];
                        string premezclas = campo2[1];
                        string material = campo2[2];
                        string lote = campo2[3];
                        string kg = campo2[4];
                        string fecha = campo2[5];
                        string id = campo2[6];

                        dataGridView2.Rows.Add(tipo, premezclas, material, lote, kg, fecha, id);

                    }
                    archivo.Close();
                }

                colorearFilas();
            }
            catch
            {
                MessageBox.Show("Error form1 load");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Length == 0 || numericUpDown1.Text.Length == 0 || comboBox2.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
                {
                    MessageBox.Show("No pueden quedar campos vacios, favor de verificar");
                }
                else
                {

                    bool validar = false;
                    try
                    {

                        var number = int.Parse(numericUpDown1.Text);

                        for (int i = 1; i <= number; i++)
                        {
                            bool exist = dataGridView2.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["ID"].Value) == comboBox1.Text + comboBox2.Text + i + dateTimePicker1.Value.ToShortDateString());

                            if (exist == true)
                            {
                                MessageBox.Show("premezcla " + comboBox1.Text + " " + comboBox2.Text + i + " con fecha: " + dateTimePicker1.Value.ToShortDateString() + " ya registrada, favor de validar");
                                validar = true;
                            }
                        }
                        if (validar == false)
                        {
                            StreamWriter alfas = new StreamWriter("alfas.txt", true);

                            string kg = "0";

                            for (int i = 1; i <= number; i++)
                            {
                                alfas.WriteLine(comboBox1.Text + "," + comboBox2.Text + i + "," + textBox2.Text + "," + textBox3.Text + "," + kg + "," + dateTimePicker1.Value.ToShortDateString() + "," + comboBox1.Text + comboBox2.Text + i + dateTimePicker1.Value.ToShortDateString());
                            }

                            alfas.Close();
                            comboBox1.Text = "";
                            numericUpDown1.Text = "";
                            comboBox2.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";

                            Form form1 = new Form1();
                            this.Hide();
                            form1.ShowDialog();
                            this.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }


                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        
    }
}


