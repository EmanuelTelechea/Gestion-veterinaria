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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.LimpiarCajas();
            this.ListarCliente();
        }
        private void LimpiarCajas()
        {
            Controladora pControladora = new Controladora();
            this.txtCodigo.Text = pControladora.ProximoId("cliente").ToString();
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.lblMensaje.Text = string.Empty;
            this.txtCodigo.Focus();
        }
        private void ListarCliente()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstCliente.DataSource = null;
            this.lstCliente.DataSource = unaControladora.ListaClientes().OrderBy(p => p.Apellido).ToList();
        }

        private void CargarClientes(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Cliente unCliente = unaControladora.BuscarCliente(pId);

            if (unCliente != null)
            {
                this.txtCodigo.Text = unCliente.Codigo.ToString();
                this.txtNombre.Text = unCliente.Nombre;
                this.txtApellido.Text = unCliente.Apellido;
                this.txtDireccion.Text = unCliente.Direccion;
                this.txtTelefono.Text = unCliente.Telefono.ToString();
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

            Cliente unCliente = new Cliente(Codigo, Nombre, Apellido, Direccion, Telefono);

            if (unaControladora.AltaCliente(unCliente))
            {
                this.ListarCliente();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe un cliente con ese Codigo";
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
            if (unaControladora.ModificarCliente(Codigo, Nombre, Apellido, Direccion, Telefono))
            {
                this.ListarCliente();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "Ya existe un cliente con ese Codigo";
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

            if (unaControladora.BajaCliente(Codigo))
            {
                this.ListarCliente();
                this.LimpiarCajas();
            }
            else
            {
                lblMensaje.Text = "No existe un cliente con ese Codigo";
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajas();
        }

        private void lstCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstCliente.SelectedIndex != -1)
            {
                string linea = this.lstCliente.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Codigo = Convert.ToInt16(partes[0]);
                this.CargarClientes(Codigo);
            }
        }
    }
}
