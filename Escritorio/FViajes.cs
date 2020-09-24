using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService1;

namespace Escritorio
{
    public partial class FViajes : Form
    {
        public FViajes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;
            DateTime FI = dateTimePicker1.Value;
            DateTime FF = dateTimePicker2.Value;
            ServiceReference1.ServiceViajeClient client = new ServiceReference1.ServiceViajeClient();
            //ServiceReference1.ViajeM[] lista= client.BuscarViajesTodos();
            ServiceReference1.ViajeM[] lista = client.BuscarViajes2(FI,FF,placa);
            //ViajeGM[] Lst = new ViajeGM[];
            List<ViajeGM> ListaViajes = new List<ViajeGM>();
            foreach (ServiceReference1.ViajeM item in lista)
            {
                ViajeGM temp = new ViajeGM(item);
                ListaViajes.Add(temp);
            }
            dataGridView1.DataSource = ListaViajes;
        }
    }
}
