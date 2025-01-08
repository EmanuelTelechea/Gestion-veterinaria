using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Consulta
    {
        private short _codigo;
        private DateTime _fecha;
        private Mascota _codigoMascota;
        private Veterinario _veterinario;
        private string _comentario;

        public short Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public Mascota CodigoMascota
        {
            get { return _codigoMascota; }
            set { _codigoMascota = value; }
        }
        public Veterinario Veterinario
        {
            get { return _veterinario; }
            set { _veterinario = value; }
        }
        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
        public override string ToString()
        {
            return this.Codigo + " " + this.Fecha + " " + this._veterinario + " " + this.CodigoMascota;
        }

        public Consulta(short pCodigo, DateTime pFecha, Mascota pCodigoMascota, Veterinario pVeterinario, string pComentario)
        {
            this.Codigo = pCodigo;
            this.Fecha = pFecha;
            this.CodigoMascota = pCodigoMascota;
            this.Veterinario = pVeterinario;
            this.Comentario = pComentario;
        }
    }
}
