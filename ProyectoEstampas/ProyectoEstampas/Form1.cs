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
        Equipo equipos = new Equipo();
        List<Equipo> estampas = new List<Equipo>(); 

        public Form1()
        {
            InitializeComponent();
        }
    }
}
