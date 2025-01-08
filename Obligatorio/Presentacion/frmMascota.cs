using Obligatorio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obligatorio.Presentacion
{
    public partial class frmMascota : Form
    {
        public frmMascota()
        {
            InitializeComponent();
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.LimpiarCajas();
            this.ListarMascota();
        }
        private void LimpiarCajas()
        {
            Controladora pControladora = new Controladora();
            this.txtCodigo.Text = pControladora.ProximoId("mascota").ToString();
            this.dateTimePicker1.Text = string.Empty;
            this.txtRaza.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;
            this.txtCodigo.Focus();
            this.CargarDuenios();
            this.CargoTipoMascota();
        }
        private void CargoTipoMascota()
        {
            cmbTipoMascota.Items.Clear();
            cmbTipoMascota.Items.Add("Seleccione el tipo de mascota");
            cmbTipoMascota.Items.Add("Gato");
            cmbTipoMascota.Items.Add("Perro");
            cmbTipoMascota.Items.Add("Tortuga");
            cmbTipoMascota.Items.Add("Hamster");
            cmbTipoMascota.Items.Add("Pez");
            cmbTipoMascota.Items.Add("Conejo");
            cmbTipoMascota.Items.Add("Oveja");
            cmbTipoMascota.SelectedIndex = 0;
        }

        private void CargarDuenios()
        {
            Controladora unaControladora = new Controladora();
            this.cmbDuenio.Items.Clear();
            this.cmbDuenio.Items.Add("Seleccione una Persona");
            foreach (Cliente unCliente in unaControladora.ListaClientes())
            {
                this.cmbDuenio.Items.Add(unCliente.Codigo + " " + unCliente.Nombre+ " " + unCliente.Apellido);
            }
            this.cmbDuenio.SelectedIndex = 0;
        }

        private void ListarMascota()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstMascota.DataSource = null;
            this.lstMascota.DataSource = unaControladora.ListaMascotas().OrderBy(p => p.TipoMascota).ToList();
        }

        private void CargarMascota(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Mascota unaMascota = unaControladora.BuscarMascota(pId);

            if (unaMascota != null)
            {
                this.txtCodigo.Text = unaMascota.Codigo.ToString();
                this.txtRaza.Text = unaMascota.Raza;
                this.cmbTipoMascota.Text = unaMascota.TipoMascota;
                this.txtNombre.Text = unaMascota.Nombre;
                this.cmbDuenio.Text = unaMascota.Duenio.ToString();

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "" || !int.TryParse(txtCodigo.Text, out _))
            {
                lblMensaje.Text = "El Codigo no es correcto";
                return;
            }
            if (txtRaza.Text.Trim() == "")
            {
                lblMensaje.Text = "La Raza no es correcta";
                return;
            }
            if (cmbTipoMascota.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un tipo de mascota";
                return;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblMensaje.Text = "El nombre no es correcta";
                return;
            }
            if (cmbDuenio.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un Dueño";
                return;
            }

            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            DateTime FechaNacimiento = dateTimePicker1.Value;
            string Raza = txtRaza.Text;
            string TipoMascota = cmbTipoMascota.Text;
            string Nombre = txtNombre.Text;

            string linea = this.cmbDuenio.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            short CodigoDuenio = Convert.ToInt16(partes[0]);
            Cliente unCliente = unaControladora.BuscarCliente(CodigoDuenio);

            Mascota unaMascota = new Mascota(Codigo, FechaNacimiento, Raza, TipoMascota, Nombre, unCliente);

            if (unaControladora.AltaMascota(unaMascota))
            {
                this.ListarMascota();
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
            if (txtRaza.Text.Trim() == "")
            {
                lblMensaje.Text = "La Raza no es correcta";
                return;
            }
            if (cmbTipoMascota.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un tipo de mascota";
                return;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblMensaje.Text = "El nombre no es correcta";
                return;
            }
            if (cmbDuenio.SelectedIndex == 0)
            {
                lblMensaje.Text = "Debe seleccionar un Dueño";
                return;
            }
            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            DateTime FechaNacimiento = dateTimePicker1.Value;
            string Raza = txtRaza.Text;
            string TipoMascota = cmbTipoMascota.Text;
            string Nombre = txtNombre.Text;

            string linea = this.cmbDuenio.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            short CodigoDuenio = Convert.ToInt16(partes[0]);
            Cliente unCliente = unaControladora.BuscarCliente(CodigoDuenio);
            if (unaControladora.ModificarMascota(Codigo, FechaNacimiento, Raza, TipoMascota, Nombre, unCliente))
            {
                this.ListarMascota();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe una mascota con ese Codigo";
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

            if (unaControladora.BajaMascota(Codigo))
            {
                this.ListarMascota();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "No existe una Mascota con ese Codigo";
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajas();
        }

        private void lstMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMascota.SelectedIndex != -1)
            {
                string linea = this.lstMascota.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Codigo = Convert.ToInt16(partes[0]);
                this.CargarMascota(Codigo);
            }
        }
    }
}
