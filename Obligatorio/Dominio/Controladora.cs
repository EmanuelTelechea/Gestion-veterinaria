using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Controladora
    {
        private static List<Mascota> _listaMascotas = new List<Mascota>();
        private static List<Veterinario> _listaVeterinarios = new List<Veterinario>();
        private static List<Consulta> _listaConsultas = new List<Consulta>();
        private static List<Cliente> _listaClientes = new List<Cliente>();

        private static short _ProximoCodigoCLiente = 1;
        private static short _ProximoCodigoVeterinario = 1;
        private static short _ProximoCodigoMascota= 1;
        private static short _ProximoCodigoConsulta = 1;
        public short ProximoId(string opcion)
        {
            short Codigo = 0;
            switch (opcion)
            {
                case "cliente":
                    Codigo = _ProximoCodigoCLiente;
                    break;
                case "veterinario":
                    Codigo = _ProximoCodigoVeterinario;
                    break;
                case "mascota":
                    Codigo = _ProximoCodigoMascota;
                    break;
                case "consulta":
                    Codigo = _ProximoCodigoConsulta;
                    break;
            }
            return Codigo;
        }

        public void IncrementoId(string opcion)
        {
            switch (opcion)
            {
                case "cliente":
                    _ProximoCodigoCLiente++;
                    break;
                case "veterinario":
                    _ProximoCodigoVeterinario++;
                    break;
                case "mascota":
                    _ProximoCodigoMascota++;
                    break;
                case "consulta":
                    _ProximoCodigoConsulta++;
                    break;
            }
        }

        #region " ABM Mascota "

        public List<Mascota> ListaMascotas()
        {
            return _listaMascotas;
        }

        public Mascota BuscarMascota(short pCodigo)
        {
            foreach (Mascota unaMascota in _listaMascotas)
            {
                if (unaMascota.Codigo.Equals(pCodigo))
                {
                    return unaMascota;
                }
            }
            return null;
        }

        public bool AltaMascota(Mascota pMascota)
        {
            Mascota unaMascota = BuscarMascota(pMascota.Codigo);

            if (unaMascota == null)
            {
                _listaMascotas.Add(pMascota);
                this.IncrementoId("mascota");
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ModificarMascota(short pCodigo, DateTime pFechaNacimiento, string pRaza, string pTipoMascota, string pNombre, Cliente pDuenio)
        {
            Mascota unaMascota = BuscarMascota(pCodigo);
            if (unaMascota != null)
            {
                unaMascota.FechaNacimiento = pFechaNacimiento;
                unaMascota.Raza = pRaza;
                unaMascota.TipoMascota = pTipoMascota;
                unaMascota.Nombre = pNombre;
                unaMascota.Duenio = pDuenio;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaMascota(short pCodigo)
        {
            Mascota unaMascota = BuscarMascota(pCodigo);
            if (unaMascota != null)
            {
                _listaMascotas.Remove(unaMascota);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region " ABM Veterinario "

        public List<Veterinario> ListaVeterinarios()
        {
            return _listaVeterinarios;
        }

        public Veterinario BuscarVeterinario(short pCodigo)
        {
            foreach (Veterinario unVeterinario in _listaVeterinarios)
            {
                if (unVeterinario.Codigo.Equals(pCodigo))
                {
                    return unVeterinario;
                }
            }
            return null;
        }

        public bool AltaVeterinario(Veterinario pVeterinario)
        {
            Veterinario unVeterinario = BuscarVeterinario(pVeterinario.Codigo);

            if (unVeterinario == null)
            {
                _listaVeterinarios.Add(pVeterinario);
                this.IncrementoId("veterinario");
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ModificarVeterinario(short pCodigo, string pNombre, string pApellido, string pDireccion, int pTelefono)
        {
            Veterinario unVeterinario  = BuscarVeterinario(pCodigo);
            if (unVeterinario != null)
            {
                unVeterinario.Nombre = pNombre;
                unVeterinario.Apellido = pApellido;
                unVeterinario.Direccion = pDireccion;
                unVeterinario.Telefono = pTelefono;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaVeterinario(short pCodigo)
        {
            Veterinario unVeterinario = BuscarVeterinario(pCodigo);
            if (unVeterinario != null)
            {
                _listaVeterinarios.Remove(unVeterinario);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region " ABM Cliente "

        public List<Cliente> ListaClientes()
        {
            return _listaClientes;
        }

        public Cliente BuscarCliente(short pCodigo)
        {
            foreach (Cliente unCliente in _listaClientes)
            {
                if (unCliente.Codigo.Equals(pCodigo))
                {
                    return unCliente;
                }
            }
            return null;
        }

        public bool AltaCliente(Cliente pCliente)
        {
            Cliente unCliente = BuscarCliente(pCliente.Codigo);

            if (unCliente == null)
            {
                _listaClientes.Add(pCliente);

                this.IncrementoId("cliente");
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ModificarCliente(short pCodigo, string pNombre, string pApellido, string pDireccion, int pTelefono)
        {
            Cliente unCliente = BuscarCliente(pCodigo);
            if (unCliente != null)
            {
                unCliente.Nombre = pNombre;
                unCliente.Apellido = pApellido;
                unCliente.Direccion = pDireccion;
                unCliente.Telefono = pTelefono;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaCliente(short pCodigo)
        {
            Cliente unCliente = BuscarCliente(pCodigo);
            if (unCliente != null)
            {
                _listaClientes.Remove(unCliente);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region " ABM Consulta "

        public List<Consulta> ListaConsultas()
        {
            return _listaConsultas;
        }

        public List<Consulta> ListaConsultaXFecha(DateTime pFecha)
        {
            List<Consulta> ListaAux = new List<Consulta>();
            foreach (Consulta unaConsulta in _listaConsultas)
            {
                if (unaConsulta.Fecha.Date == pFecha.Date)
                {
                    ListaAux.Add(unaConsulta);
                }
            }
            return ListaAux;
        }
        public List<Consulta> ListaConsultaXFechaGato(DateTime pFecha)
        {
            List<Consulta> ListaAux = new List<Consulta>();
            foreach (Consulta unaConsulta in _listaConsultas)
            {
                if (unaConsulta.Fecha.Date == pFecha.Date && unaConsulta.CodigoMascota.TipoMascota == "Gato")
                {
                    ListaAux.Add(unaConsulta);
                }
                
                
            }
            return ListaAux;
        }
        public List<Consulta> ListaConsultaXFechaVet(Veterinario pVeterinario, DateTime pFecha)
        {
            List<Consulta> ListaAux = new List<Consulta>();
            foreach (Consulta unaConsulta in _listaConsultas)
            {
                if (unaConsulta.Veterinario.Codigo.Equals(pVeterinario.Codigo) && unaConsulta.Fecha.Date == pFecha.Date)
                {
                        ListaAux.Add(unaConsulta);
                }
            }
            return ListaAux;
        }

        public Consulta BuscarConsulta(short pCodigo)
        {
            foreach (Consulta unaConsulta in _listaConsultas)
            {
                if (unaConsulta.Codigo.Equals(pCodigo))
                {
                    return unaConsulta;
                }
            }
            return null;
        }

        public bool AltaConsulta(Consulta pConsulta)
        {
            Consulta unaConsulta = BuscarConsulta(pConsulta.Codigo);

            if (unaConsulta == null)
            {
                _listaConsultas.Add(pConsulta);

                this.IncrementoId("consulta");
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ModificarConsulta(short pCodigo, DateTime pFecha, Mascota pCodigoMascota, Veterinario pVeterinario, string pComentario)
        {
            Consulta unaConsulta = BuscarConsulta(pCodigo);
            if (unaConsulta != null)
            {
                unaConsulta.Fecha = pFecha;
                unaConsulta.CodigoMascota = pCodigoMascota;
                unaConsulta.Veterinario = pVeterinario; 
                unaConsulta.Comentario = pComentario;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaConsulta(short pCodigo)
        {
            Consulta unaConsulta = BuscarConsulta(pCodigo);
            if (unaConsulta != null)
            {
                _listaConsultas.Remove(unaConsulta);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region " DATOS DE PRUEBA "

        public void CargoDatosDePrueba()
        {
            // Cliente
            Cliente Cliente1 = new Cliente(1, "Emanuel", "Telechea", "Barrio alonso", 092120366);
            _listaClientes.Add(Cliente1);
            this.IncrementoId("cliente");
            Cliente Cliente2 = new Cliente(2, "Nicolas", "Lima", "Su casa", 092761485);
            _listaClientes.Add(Cliente2);
            this.IncrementoId("cliente");

            // Veterinario
            Veterinario Veterinario1 = new Veterinario(1, "Agustin", "Gutierrez", "CAMEC", 092056345);
            _listaVeterinarios.Add(Veterinario1);
            this.IncrementoId("veterinario");
            Veterinario Veterinario2 = new Veterinario(2, "Martin", "Velazquez", "Hospital", 098632693);
            _listaVeterinarios.Add(Veterinario2);
            this.IncrementoId("veterinario");

            // Mascota
            Mascota Mascota1 = new Mascota(1, DateTime.Now, "Ciames", "Gato", "Michi", Cliente1);
            _listaMascotas.Add(Mascota1);
            this.IncrementoId("mascota");
            Mascota Mascota2 = new Mascota(2, DateTime.Now, "Caniche", "Perro", "Toby", Cliente2);
            _listaMascotas.Add(Mascota2);
            this.IncrementoId("mascota");
        }


        #endregion


        public Controladora()
        {
        }
    }
}
