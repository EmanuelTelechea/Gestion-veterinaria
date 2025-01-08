using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Mascota
    {
        private short _codigo;
        private DateTime _fechaNacimiento;
        private string _raza;
        private string _TipoMascota;
        private string _nombre;
        private Cliente _duenio;

        public short Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public string Raza
        {
            get { return _raza; }
            set { _raza = value; }
        }
        public string TipoMascota
        {
            get { return _TipoMascota; }
            set { _TipoMascota = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public Cliente Duenio
        {
            get { return _duenio; }
            set { _duenio = value; }
        }
        public override string ToString()
        {
            return this.Codigo + " " + this.TipoMascota + " " + this.Raza + " " + this.FechaNacimiento + " " + this.Duenio + " " + this.Nombre;
        }

        public Mascota(short pCodigo, DateTime pFechaNacimiento, string pRaza, string pTipoMascota, string pNombre,  Cliente pDuenio)
        {
            this.Codigo = pCodigo;
            this.FechaNacimiento = pFechaNacimiento;
            this.Raza = pRaza;
            this.TipoMascota = pTipoMascota;
            this.Nombre = pNombre;
            this.Duenio = pDuenio;
        }
    }
}
