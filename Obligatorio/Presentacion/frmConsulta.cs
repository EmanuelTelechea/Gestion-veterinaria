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
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.LimpiarCajas();
            this.ListarConsulta();
        }
        private void LimpiarCajas()
        {
            Controladora pControladora = new Controladora();
            this.txtCodigo.Text = pControladora.ProximoId("consulta").ToString();
            this.dateTimePicker1.Text = string.Empty;
            this.txtComentario.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;
            this.txtCodigo.Focus();
            this.CargarMascota();
            this.CargarVeterinario();
        }

        private void CargarMascota()
        {
            Controladora unaControladora = new Controladora();
            this.cmbCodigoMascota.Items.Clear();
            this.cmbCodigoMascota.Items.Add("Seleccione una Mascota");
            foreach (Mascota unaMascota in unaControladora.ListaMascotas())
            {
                this.cmbCodigoMascota.Items.Add(unaMascota.Codigo + " " + unaMascota.Nombre + " " + unaMascota.TipoMascota);
            }
            this.cmbCodigoMascota.SelectedIndex = 0;
        }
        private void CargarVeterinario()
        {
            Controladora unaControladora = new Controladora();
            this.cmbVeterinario.Items.Clear();
            this.cmbVeterinario.Items.Add("Seleccione un Veterinario");
            foreach (Veterinario unVeterinario in unaControladora.ListaVeterinarios())
            {
                this.cmbVeterinario.Items.Add(unVeterinario.Codigo + " " + unVeterinario.Nombre + " " + unVeterinario.Apellido);
            }
            this.cmbVeterinario.SelectedIndex = 0;
        }

        private void ListarConsulta()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstConsulta.DataSource = null;
            this.lstConsulta.DataSource = unaControladora.ListaConsultas();
        }

        private void CargarConsulta(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Consulta unaConsulta = unaControladora.BuscarConsulta(pId);

            if (unaConsulta != null)
            {
                this.txtCodigo.Text = unaConsulta.Codigo.ToString();
                this.dateTimePicker1.Text = unaConsulta.Fecha.ToString();
                this.cmbCodigoMascota.Text = unaConsulta.CodigoMascota.ToString();
                this.cmbVeterinario.Text = unaConsulta.Veterinario.ToString();
                this.txtComentario.Text = unaConsulta.Comentario;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "" || !int.TryParse(txtCodigo.Text, out _))
            {
                lblMensaje.Text = "El Codigo no es correcto";
                return;
            }
            if (cmbCodigoMascota.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar una mascota";
                return;
            }
            if (cmbVeterinario.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un Veterinario";
                return;
            }

            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            DateTime FechaConsulta = dateTimePicker1.Value;
            string Comentario = txtComentario.Text;
            string lineamasc = this.cmbCodigoMascota.SelectedItem.ToString();
            string[] partesmasc = lineamasc.Split(' ');
            short CodigoMascota = Convert.ToInt16(partesmasc[0]);
            Mascota unaMascota = unaControladora.BuscarMascota(CodigoMascota);
            string linea = this.cmbVeterinario.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            short CodigoVeterinario = Convert.ToInt16(partes[0]);
            Veterinario unVeterinario = unaControladora.BuscarVeterinario(CodigoVeterinario);

            Consulta unaConsulta = new Consulta(Codigo, FechaConsulta, unaMascota, unVeterinario, Comentario);

            if (unaControladora.AltaConsulta(unaConsulta))
            {
                this.ListarConsulta();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe una mascota con ese Codigo";
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "" || !int.TryParse(txtCodigo.Text, out _))
            {
                lblMensaje.Text = "El Codigo no es correcto";
                return;
            }
            if (cmbCodigoMascota.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar una mascota";
                return;
            }
            if (cmbVeterinario.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un Veterinario";
                return;
            }

            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            DateTime FechaConsulta = dateTimePicker1.Value;
            string Comentario = txtComentario.Text;
            string lineamasc = this.cmbCodigoMascota.SelectedItem.ToString();
            string[] partesmasc = lineamasc.Split(' ');
            short CodigoMascota = Convert.ToInt16(partesmasc[0]);
            Mascota unaMascota = unaControladora.BuscarMascota(CodigoMascota);
            string linea = this.cmbVeterinario.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            short CodigoVeterinario = Convert.ToInt16(partes[0]);
            Veterinario unVeterinario = unaControladora.BuscarVeterinario(CodigoVeterinario);
            if (unaControladora.ModificarConsulta(Codigo, FechaConsulta, unaMascota, unVeterinario, Comentario))
            {
                this.ListarConsulta();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe una consulta con ese Codigo";
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "" || !int.TryParse(txtCodigo.Text, out _))
            {
                lblMensaje.Text = "El Codigo no es correcto";
                return;
            }

            short Codigo = Convert.ToInt16(txtCodigo.Text);

            Dominio.Controladora unaControladora = new Dominio.Controladora();

            if (unaControladora.BajaConsulta(Codigo))
            {
                this.ListarConsulta();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "No existe una consulta con ese Codigo";
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajas();
        }

        private void lstConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstConsulta.SelectedIndex != -1)
            {
                string linea = this.lstConsulta.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Codigo = Convert.ToInt16(partes[0]);
                this.CargarConsulta(Codigo);
            }
        }
    }
}
