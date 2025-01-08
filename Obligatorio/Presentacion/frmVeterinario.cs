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
    public partial class frmVeterinario : Form
    {
        public frmVeterinario()
        {
            InitializeComponent();
        }

        private void frmVeterinario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.LimpiarCajas();
            this.ListarVeterinario();
        }
        private void LimpiarCajas()
        {
            Controladora pControladora = new Controladora();
            this.txtCodigo.Text = pControladora.ProximoId("veterinario").ToString();
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;
            this.txtCodigo.Focus();
        }
        private void ListarVeterinario()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstVeterinario.DataSource = null;
            this.lstVeterinario.DataSource = unaControladora.ListaVeterinarios();
        }

        private void CargarVeterinarios(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Veterinario unVeterinario = unaControladora.BuscarVeterinario(pId);

            if (unVeterinario != null)
            {
                this.txtCodigo.Text = unVeterinario.Codigo.ToString();
                this.txtNombre.Text = unVeterinario.Nombre;
                this.txtApellido.Text = unVeterinario.Apellido;
                this.txtDireccion.Text = unVeterinario.Direccion;
                this.txtTelefono.Text = unVeterinario.Telefono.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() == "" || !int.TryParse(txtCodigo.Text, out _))
            {
                lblMensaje.Text = "El Codigo no es correcto";
                return;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblMensaje.Text = "El nombre no es correcta";
                return;
            }
            if (txtApellido.Text.Trim() == "")
            {
                lblMensaje.Text = "El apellido no es correcta";
                return;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                lblMensaje.Text = "La direccion no es correcta";
                return;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                lblMensaje.Text = "El telefono no es correcta";
                return;
            }

            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Direccion = txtDireccion.Text;
            int Telefono = Convert.ToInt32(txtTelefono.Text);

            Veterinario unVeterinario = new Veterinario(Codigo, Nombre, Apellido, Direccion, Telefono);

            if (unaControladora.AltaVeterinario(unVeterinario))
            {
                this.ListarVeterinario();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe un veterinario con ese Codigo";
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
            if (txtNombre.Text.Trim() == "")
            {
                lblMensaje.Text = "El nombre no es correcta";
                return;
            }
            if (txtApellido.Text.Trim() == "")
            {
                lblMensaje.Text = "El apellido no es correcta";
                return;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                lblMensaje.Text = "La direccion no es correcta";
                return;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                lblMensaje.Text = "El telefono no es correcta";
                return;
            }

            Controladora unaControladora = new Controladora();

            short Codigo = Convert.ToInt16(txtCodigo.Text);
            string Nombre = txtNombre.Text;
            string Apellido = txtApellido.Text;
            string Direccion = txtDireccion.Text;
            int Telefono = Convert.ToInt32(txtTelefono.Text);
            if (unaControladora.ModificarVeterinario(Codigo, Nombre, Apellido, Direccion, Telefono))
            {
                this.ListarVeterinario();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe un veterinario con ese Codigo";
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

            if (unaControladora.BajaVeterinario(Codigo))
            {
                this.ListarVeterinario();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "No existe un veterinario con ese Codigo";
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajas();
        }

        private void lstVeterinario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstVeterinario.SelectedIndex != -1)
            {
                string linea = this.lstVeterinario.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Codigo = Convert.ToInt16(partes[0]);
                this.CargarVeterinarios(Codigo);
            }
        }
    }
}
