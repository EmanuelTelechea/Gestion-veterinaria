using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obligatorio.Presentacion
{
    public partial class frmVeterinaria : Form
    {
        public frmVeterinaria()
        {
            InitializeComponent();
        }

        private void aBMVeterinarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aBMVeterinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Singleton(string pFormularioHijo)
        {
            bool encontrado = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(pFormularioHijo))
                {
                    encontrado = true;
                    form.Activate();
                }
                else
                {
                    form.Close();
                }
            }
            if (!encontrado)
            {
                switch (pFormularioHijo)
                {
                    case "frmCliente":
                        Presentacion.frmCliente unFrmCliente = new Presentacion.frmCliente();
                        unFrmCliente.MdiParent = this;
                        unFrmCliente.Top = 0;
                        unFrmCliente.Left = 0;
                        unFrmCliente.Show();
                        break;
                    case "frmVeterinario":
                        Presentacion.frmVeterinario unFrmVeterinario = new Presentacion.frmVeterinario();
                        unFrmVeterinario.MdiParent = this;
                        unFrmVeterinario.Show();
                        break;
                    case "frmMascota":
                        Presentacion.frmMascota unFrmMascota = new Presentacion.frmMascota();
                        unFrmMascota.MdiParent = this;
                        unFrmMascota.Top = 0;
                        unFrmMascota.Left = 0;
                        unFrmMascota.Show();
                        break;
                    case "frmConsulta":
                        Presentacion.frmConsulta unFrmConsulta = new Presentacion.frmConsulta();
                        unFrmConsulta.MdiParent = this;
                        unFrmConsulta.Top = 0;
                        unFrmConsulta.Left = 0;
                        unFrmConsulta.Show();
                        break;
                    case "frmAtendidos":
                        Presentacion.frmAtendidos unFrmAtendidos = new Presentacion.frmAtendidos();
                        unFrmAtendidos.MdiParent = this;
                        unFrmAtendidos.Top = 0;
                        unFrmAtendidos.Left = 0;
                        unFrmAtendidos.Show();
                        break;
                }
            }
        }
        private void frmVeterinaria_Load(object sender, EventArgs e)
        {
            Dominio.Controladora pControladora = new Dominio.Controladora();
            pControladora.CargoDatosDePrueba();
        }

        private void mascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string pFormularioHijo = "frmMascota";
            this.Singleton(pFormularioHijo);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string pFormularioHijo = "frmCliente";
            this.Singleton(pFormularioHijo);
        }

        private void veterinariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string pFormularioHijo = "frmVeterinario";
            this.Singleton(pFormularioHijo);
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string pFormularioHijo = "frmConsulta";
            this.Singleton(pFormularioHijo);
        }

        private void atendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pFormularioHijo = "frmAtendidos";
            this.Singleton(pFormularioHijo);
        }
    }
}
