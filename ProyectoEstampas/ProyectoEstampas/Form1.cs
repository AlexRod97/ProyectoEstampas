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
        StreamWriter Archivo = new StreamWriter("C:\\Test.txt");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Archivo.Write(txtEscribir.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Archivo.Close();
        }
    }
}
