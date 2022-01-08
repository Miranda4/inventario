using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace inventario
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.MultiSelect = false;
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.MultiSelect = false;
            numericUpDown3.Text = "";

        }

        private bool GrabarDatos()
        {
            StreamWriter archivo = new StreamWriter("templado.txt", true);
            try
            {
                
                var tipo = Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
                var premezcla = Convert.ToString(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
                var material = Convert.ToString(dataGridView1[2, dataGridView1.CurrentRow.Index].Value);
                var lote = Convert.ToString(dataGridView1[3, dataGridView1.CurrentRow.Index].Value);
                var kg = Convert.ToString(dataGridView1[4, dataGridView1.CurrentRow.Index].Value);
                var fecha = Convert.ToString(dataGridView1[5, dataGridView1.CurrentRow.Index].Value);
                var id = Convert.ToString(dataGridView1[6, dataGridView1.CurrentRow.Index].Value);
                archivo.WriteLine(tipo + "," + premezcla + "," + material + "," + lote + "," + kg + "," + fecha + "," + id);
                archivo.Close();

                StreamReader alfas;
                StreamWriter temp;

                alfas = File.OpenText("alfas.txt");
                temp = File.CreateText("temp.txt");


                string[] campo = new string[7];
                while (!alfas.EndOfStream)
                {
                    string cadena = alfas.ReadLine();
                    campo = cadena.Split(",");

                    string id1 = campo[6];

                    if (id1 == id)
                    {

                    }
                    else
                    {
                        temp.WriteLine(cadena);
                    }
                }

                alfas.Close();
                temp.Close();

                File.Delete("alfas.txt");
                File.Move("temp.txt", "alfas.txt");

                return true;
            }
            catch
            {
                archivo.Close();
                return false;
            }

        }

        private bool GrabarDatos2()
        {
            StreamWriter archivo = new StreamWriter("camara9.txt", true);
            try
            {
                
                var tipo = Convert.ToString(dataGridView3[0, dataGridView3.CurrentRow.Index].Value);
                var premezcla = Convert.ToString(dataGridView3[1, dataGridView3.CurrentRow.Index].Value);
                var material = Convert.ToString(dataGridView3[2, dataGridView3.CurrentRow.Index].Value);
                var lote = Convert.ToString(dataGridView3[3, dataGridView3.CurrentRow.Index].Value);
                var kg = Convert.ToString(dataGridView3[4, dataGridView3.CurrentRow.Index].Value);

                var fecha = Convert.ToString(dataGridView3[5, dataGridView3.CurrentRow.Index].Value);
                var id = Convert.ToString(dataGridView3[6, dataGridView3.CurrentRow.Index].Value);
                archivo.WriteLine(tipo + "," + premezcla + "," + material + "," + lote + "," + kg + "," + fecha + "," + id);
                archivo.Close();

                StreamReader templado;
                StreamWriter temp;

                templado = File.OpenText("templado.txt");
                temp = File.CreateText("temp.txt");


                string[] campo = new string[11];
                while (!templado.EndOfStream)
                {
                    string cadena = templado.ReadLine();
                    campo = cadena.Split(",");

                    string id1 = campo[6];

                    if (id1 == id)
                    {

                    }
                    else
                    {
                        temp.WriteLine(cadena);
                    }
                }

                templado.Close();
                temp.Close();

                File.Delete("templado.txt");
                File.Move("temp.txt", "templado.txt");

                return true;
            }
            catch
            {
                archivo.Close();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //camara 9

            string[] campo = new string[7];

            if (!File.Exists("camara9.txt"))
            {
                StreamWriter archivo = new StreamWriter("camara9.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("camara9.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo = aux.Split(",");
                    string tipo = campo[0];
                    string premezcla = campo[1];
                    string lote = campo[2];
                    string material = campo[3];
                    string kg = campo[4];
                    /*
                    string humedad = campo[5];
                    string grasa = campo[6];
                    string sal = campo[7];
                    string nitritos = campo[8];
                    */
                    string fecha = campo[5];
                    string id = campo[6];


                    //dataGridView2.Rows.Add(tipo, premezcla, lote, material, kg, humedad, grasa, sal, nitritos, fecha, id);
                    dataGridView2.Rows.Add(tipo, premezcla, lote, material, kg, fecha, id);

                }
                archivo.Close();
            }
            //templado

            string[] campo1 = new string[7];

            if (!File.Exists("templado.txt"))
            {
                StreamWriter archivo = new StreamWriter("templado.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("templado.txt");
                while (!archivo.EndOfStream)
                {
                    var aux = archivo.ReadLine();
                    campo1 = aux.Split(",");
                    string tipo = campo1[0];
                    string premezcla = campo1[1];
                    string lote = campo1[2];
                    string material = campo1[3];
                    string kg = campo1[4];
                    /*
                    string humedad = campo1[5];
                    string grasa = campo1[6];
                    string sal = campo1[7];
                    string nitritos = campo1[8];
                    */
                    string fecha = campo1[5];
                    string id = campo1[6];


                    //dataGridView3.Rows.Add(tipo, premezcla, lote, material, kg, humedad, grasa, sal, nitritos, fecha, id);
                    dataGridView3.Rows.Add(tipo, premezcla, lote, material, kg, fecha, id);

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

                    dataGridView1.Rows.Add(tipo, premezclas, material, lote, kg, fecha, id);
                }
                archivo.Close();
            }
        }
        //camara9
        private void button8_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView3.CurrentRow;

            bool exist = false;
            bool validar = false;

            if (exist == true)
            {
                MessageBox.Show("premezcla ya registrada, favor de validar");
                validar = true;
            }
            else
            {
                StreamReader templado;
                StreamWriter temp2;
                string cadena2;
                string[] campo2 = new string[7];
                bool encontrado2 = false;
                if (GrabarDatos2() == true)
                {
                    templado = File.OpenText("templado.txt");
                    temp2 = File.CreateText("temp2.txt");

                    cadena2 = templado.ReadLine();

                    while (cadena2 != null)
                    {
                        campo2 = cadena2.Split(",");
                        if (campo2[6].Equals(row.Cells["ID3"].Value))
                        {
                            encontrado2 = true;
                            campo2 = cadena2.Split(",");
                            var nuevoNumero = 0;
                            var myString = nuevoNumero.ToString();
                            campo2[4] = myString;
                            temp2.WriteLine(campo2[0] + "," + campo2[1] + "," + campo2[2] + "," + campo2[3] + "," + campo2[4] + "," + campo2[5] + "," + campo2[6]);
                        }
                        else
                        {
                            temp2.WriteLine(cadena2);
                        }
                        cadena2 = templado.ReadLine();

                    }
                    templado.Close();
                    temp2.Close();

                    File.Delete("templado.txt");
                    File.Move("temp2.txt", "templado.txt");
                }

                Form form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
        }
        //templado
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                if (row.Cells["KG"].Value.ToString() == "0")
                {
                    MessageBox.Show("premezcla sin kg, favor de agregar alguno");
                }
                else
                {
                    StreamReader alfas;
                    StreamWriter temp2;
                    string cadena2;
                    string[] campo2 = new string[7];
                    bool encontrado2 = false;
                    if (GrabarDatos() == true)
                    {
                        alfas = File.OpenText("alfas.txt");
                        temp2 = File.CreateText("temp2.txt");

                        cadena2 = alfas.ReadLine();

                        while (cadena2 != null)
                        {
                            campo2 = cadena2.Split(",");
                            if (campo2[6].Equals(row.Cells["ID"].Value.ToString()))
                            {
                                encontrado2 = true;
                                campo2 = cadena2.Split(",");
                                var nuevoNumero = 0;
                                var myString = nuevoNumero.ToString();
                                campo2[4] = myString;
                                temp2.WriteLine(campo2[0] + "," + campo2[1] + "," + campo2[2] + "," + campo2[3] + "," + campo2[4] + "," + campo2[5] + "," + campo2[6]);
                            }
                            else
                            {
                                temp2.WriteLine(cadena2);
                            }
                            cadena2 = alfas.ReadLine();
                        }
                        alfas.Close();
                        temp2.Close();

                        File.Delete("alfas.txt");
                        File.Move("temp2.txt", "alfas.txt");
                    }
                    dataGridView1.Refresh();
                    dataGridView2.Refresh();
                    dataGridView3.Refresh();
                    
                    Form form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
                    this.Close();
                    
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            if (numericUpDown3.Text.Length == 0)
            {
                MessageBox.Show("No pueden quedar campos vacios, favor de verificar");
            }
            else
            {
                StreamReader almacen;
                StreamReader alfas;
                StreamWriter temp;
                StreamWriter temp2;
                string cadena;
                string cadena2;
                string[] campo = new string[8];
                string[] campo2 = new string[7];
                try
                {
                    almacen = File.OpenText("almacen.txt");
                    temp = File.CreateText("temp.txt");
                    cadena = almacen.ReadLine();

                    while (cadena != null)
                    {
                        campo = cadena.Split(",");
                        if (campo[1].Equals(row.Cells["LOTE"].Value))
                        {
                            var number = int.Parse(campo[5]);
                            var number2 = 0 + int.Parse(numericUpDown3.Text);
                            int nuevoNumero = number - number2;
                            string myString = nuevoNumero.ToString();


                            if (nuevoNumero > 0)
                            {
                                temp.WriteLine(campo[0] + "," + campo[1] + "," + campo[2] + "," + campo[3] + "," + campo[4] + "," + myString + "," + campo[6] + "," + campo[7]);
                            }

                            if (nuevoNumero < 0)
                            {
                                MessageBox.Show("No hay suficientes KG de el elemento seleccionado");

                                temp.WriteLine(campo[0] + "," + campo[1] + "," + campo[2] + "," + campo[3] + "," + campo[4] + "," + campo[5] + "," + campo[6] + "," + campo[7]);
                                break;
                            }

                            alfas = File.OpenText("alfas.txt");
                            temp2 = File.CreateText("temp2.txt");

                            cadena2 = alfas.ReadLine();

                            while (cadena2 != null)
                            {
                                campo2 = cadena2.Split(",");
                                if (campo2[6].Equals(row.Cells["ID"].Value))
                                {
                                    campo2 = cadena2.Split(",");
                                    number = int.Parse(campo2[4]);
                                    number2 = 0 + int.Parse(numericUpDown3.Text);
                                    nuevoNumero = number + number2;
                                    myString = nuevoNumero.ToString();
                                    campo2[4] = myString;
                                    temp2.WriteLine(campo2[0] + "," + campo2[1] + "," + campo2[2] + "," + campo2[3] + "," + campo2[4] + "," + campo2[5] + "," + campo2[6]);
                                }
                                else
                                {
                                    temp2.WriteLine(cadena2);
                                }
                                cadena2 = alfas.ReadLine();

                            }
                            alfas.Close();
                            temp2.Close();

                            File.Delete("alfas.txt");
                            File.Move("temp2.txt", "alfas.txt");
                        }
                        else
                        {
                            temp.WriteLine(cadena);
                        }
                        cadena = almacen.ReadLine();
                    }
                    almacen.Close();
                    temp.Close();

                    File.Delete("almacen.txt");
                    File.Move("temp.txt", "almacen.txt");

                }
                catch
                {
                    MessageBox.Show("Error: form2 > button4_click");
                }
                dataGridView2.Rows.Add(numericUpDown3);

                numericUpDown3.Text = "";
                
                Form form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }
        //}

    }
    //agregar kg


}
