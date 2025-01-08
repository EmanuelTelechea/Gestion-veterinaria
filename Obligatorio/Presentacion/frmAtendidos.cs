using Obligatorio.Dominio;
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
    public partial class frmAtendidos : Form
    {
        public frmAtendidos()
        {
            InitializeComponent();
        }

        private void frmAtendidos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.LimpiarCajas();
        }
        private void LimpiarCajas()
        {
            this.dateTimePicker1.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;
            this.ListarAtendidos();
            this.ListarVeterinario();
            this.ListarGatos();
        }
        private void ListarVeterinario()
        {
            Controladora unaControladora = new Controladora();

            cmbVeterinario.Items.Clear();

            cmbVeterinario.Items.Add("Seleccione un Veterinario");

            foreach (Veterinario pVeterinario in unaControladora.ListaVeterinarios())
            {
                cmbVeterinario.Items.Add(pVeterinario.ToString());
            }

            cmbVeterinario.SelectedIndex = 0;
        }
        private void ListarAtendidos()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstMascota.DataSource = null;
            DateTime fecha = dateTimePicker1.Value.Date;
            this.lstMascota.DataSource = unaControladora.ListaConsultaXFecha(fecha);

        }
        private void ListarGatos()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstMascota.DataSource = null;
            DateTime fecha = dateTimePicker2.Value.Date;
            this.lstMascota.DataSource = unaControladora.ListaConsultaXFechaGato(fecha);
        }



        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Controladora unaControladora = new Controladora();

            foreach (Consulta consultas in unaControladora.ListaConsultas())
            {
                if (dateTimePicker1.Value.Date == consultas.Fecha.Date)
                {
                    
                    Consulta unaConsulta = unaControladora.BuscarConsulta(consultas.Codigo);

                    this.lstMascota.DataSource = null;
                    this.lstMascota.DataSource = unaControladora.ListaConsultaXFecha(unaConsulta.Fecha.Date);

                    this.ListarAtendidos();

                }
            }
        }

        private void btnMostrarGatos_Click(object sender, EventArgs e)
        {
            Controladora unaControladora = new Controladora();

            foreach (Consulta consultas in unaControladora.ListaConsultas())
            {
                if (dateTimePicker2.Value.Date == consultas.Fecha.Date)
                {
                    
                    Consulta unaConsulta = unaControladora.BuscarConsulta(consultas.Codigo);

                    this.lstGatos.DataSource = null;
                    this.lstGatos.DataSource = unaControladora.ListaConsultaXFechaGato(unaConsulta.Fecha);

                    this.ListarGatos();

                }
            }
        }

        private void btnMostrarxVet_Click(object sender, EventArgs e)
        {
            Controladora unaControladora = new Controladora();

            if (cmbVeterinario.SelectedIndex != 0)
            {
                string lineaP = this.cmbVeterinario.SelectedItem.ToString();
                string[] partesP = lineaP.Split(' ');
                short IdP = Convert.ToInt16(partesP[0]);
                Veterinario unVeterinario = unaControladora.BuscarVeterinario(IdP);
                DateTime fecha = dateTimePicker3.Value.Date;
                this.lstVetMasc.DataSource = null;
                this.lstVetMasc.DataSource = unaControladora.ListaConsultaXFechaVet(unVeterinario, fecha);
                this.ListarVeterinario();
            }
            else
            {

            }
        }

        private void lnkLimpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LimpiarCajas();
        }
    }
}
