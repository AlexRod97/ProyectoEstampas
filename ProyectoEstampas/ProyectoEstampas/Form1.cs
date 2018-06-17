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

namespace ProyectoEstampas
{
    public partial class Form1 : Form
    {       
        SortedDictionary<int, Estampa> album = new SortedDictionary<int, Estampa>(); 
        List<int> InsertedNumbers = new List<int>(); 
        
        public Form1()
        {
            InitializeComponent();

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowCount = 20;

            for (int i = 0; i < 8; i++)
            {
                dataGridView2[0, i].Value = i;
                dataGridView2[0, i].Style.BackColor = Color.Red;
            }

            for (int i = 0; i < 12; i++)
            {
                dataGridView2[1, i].Value = i + 8;
                dataGridView2[1, i].Style.BackColor = Color.Red;
            }

            int count = 20;

            for (int i = 2; i < 34; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (count < 670)
                    {
                        dataGridView2[i, j].Value = count;
                        dataGridView2[i, j].Style.BackColor = Color.Red;
                        count++;
                    }
                }
            }
            count = 660; 

            for (int i = 0; i < 10; i++)
            {
                dataGridView2[34, i].Value = count;
                dataGridView2[34, i].Style.BackColor = Color.Red;
                count++;
            }

        }

        public void UpdateForm(int numeroEstampa, int cantEstampas)
        {
            for (int i = 0; i < 8; i++)
            {
                if (numeroEstampa.ToString() == dataGridView2[0,i].Value.ToString() && cantEstampas != 0)
                {
                    dataGridView2[0, i].Style.BackColor = Color.Green;
                }
                
            }

            for (int i = 0; i < 12; i++)
            {
                if (numeroEstampa.ToString() == dataGridView2[1, i].Value.ToString() && cantEstampas != 0)
                {
                    dataGridView2[1, i].Style.BackColor = Color.Green;
                }
            }

            for (int i = 2; i < 34; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (numeroEstampa.ToString() == dataGridView2[i, j].Value.ToString() && cantEstampas != 0)
                    {
                        dataGridView2[i, j].Style.BackColor = Color.Green;
                        break;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (numeroEstampa.ToString() == dataGridView2[34, i].Value.ToString() && cantEstampas != 0)
                {
                    dataGridView2[34, i].Style.BackColor = Color.Green;
                }
            }
        }

        private void UpdateRemove(int numeroEstampa, int cantEstampas)
        {
            for (int i = 0; i < 8; i++)
            {
                if (numeroEstampa.ToString() == dataGridView2[0, i].Value.ToString() && cantEstampas == 0)
                {
                    dataGridView2[0, i].Style.BackColor = Color.Red;
                }

            }

            for (int i = 0; i < 12; i++)
            {

                if (numeroEstampa.ToString() == dataGridView2[1, i].Value.ToString() && cantEstampas == 0)
                {
                    dataGridView2[1, i].Style.BackColor = Color.Red;
                }
            }

            for (int i = 2; i < 34; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (numeroEstampa.ToString() == dataGridView2[i, j].Value.ToString() && cantEstampas == 0)
                    {
                        dataGridView2[i, j].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            for (int i = 0; i < textBox2.Lines.Count(); i++)
            {
                AgregarEstampa(Convert.ToInt32(textBox2.Lines.ElementAt(i)));                   
            }

        }

        private bool BuscarEstampa(int numero)
        {
            if (album.ContainsKey(numero))
                return true;
            else
                return false; 
        }

        private void AgregarEstampa(int numero)
        {
            Estampa added = new Estampa();
            if(BuscarEstampa(numero))
            {
                added=  album[numero];
                added.CantidadObtenida = added.CantidadObtenida + 1;
                UpdateForm(numero, added.CantidadObtenida);
            }
            else
            {
                added.Numero = numero;
                added.CantidadObtenida = 1; 
                album.Add(numero, added);
                UpdateForm(numero, added.CantidadObtenida);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox2.Lines.Count(); i++)
            {
                EliminarEstampa(Convert.ToInt32(textBox2.Lines.ElementAt(i)));
            }
        }

       private void EliminarEstampa(int numero)
        {
            Estampa added = new Estampa();
            if (BuscarEstampa(numero))
            {
                added = album[numero];

                if (added.CantidadObtenida == 0)
                {
                    UpdateRemove(numero, 0);
                }
                else
                {
                    added.CantidadObtenida = added.CantidadObtenida - 1;
                    UpdateRemove(numero, added.CantidadObtenida);
                }
                
            }
            else
            {
                album.Remove(numero);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (BuscarEstampa(int.Parse(tbxBuscar.Text)))
                {
                    Estampa estampa = new Estampa();
                    album.TryGetValue(int.Parse(tbxBuscar.Text), out estampa);
                    MessageBox.Show("Queda(n): " + estampa.CantidadObtenida + " estampa(s) del número seleccionado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso el formato correcto","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter Archivo = new StreamWriter("Archivo.txt");
            foreach (var item in album)
            {
                Archivo.Write(item.Key + ",");
            }
            Archivo.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader ArchivoLeer = new StreamReader("Archivo.txt");
            string linea = "";
            List<string> ListaDeLineas = new List<string>();

            while (linea != null)
            {
                linea = ArchivoLeer.ReadLine();
                if (linea != null)
                    ListaDeLineas.Add(linea);
            }

            foreach (var item in ListaDeLineas)
            {
                String[] Estampitas = item.Split(',');
                foreach (string estampita in Estampitas)
                {
                    if (estampita!="")
                    {
                        AgregarEstampa(Convert.ToInt32(estampita));
                    }
                }
                    
            }
            ArchivoLeer.Close();
        }
    }
}
