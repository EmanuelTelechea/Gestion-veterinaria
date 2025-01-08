using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Persona
    {
        private short _codigo;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private int _telefono;

        public short Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre + " " + this.Apellido;
        }

        public Persona(short pCodigo, string pNombre, string pApellido, string pDireccion, int pTelefono)
        {
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
        }
    }
}
