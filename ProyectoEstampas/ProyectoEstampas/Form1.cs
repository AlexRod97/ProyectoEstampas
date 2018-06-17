using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstampas
{
    public partial class Form1 : Form
    {
        SortedDictionary<int, Estampa> album = new SortedDictionary<int, Estampa>(); 
        List<int> InsertedNumbers = new List<int>(); 
        
        public Form1()
        {
            InitializeComponent();
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
            }
            else
            {
                added.Numero = numero;
                added.CantidadObtenida = 1; 
                album.Add(numero, added);
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
                added.CantidadObtenida = added.CantidadObtenida - 1;
            }
            else
            {
                album.Remove(numero);
            }
        }
    }
}
