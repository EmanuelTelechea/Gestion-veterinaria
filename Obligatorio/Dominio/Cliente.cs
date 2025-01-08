using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Cliente: Persona
    {


        
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre + " " + this.Apellido;
        }

        public Cliente(short pCodigo, string pNombre, string pApellido, string pDireccion, int pTelefono)
            : base(pCodigo, pNombre, pApellido, pDireccion, pTelefono)
        {
            
        }
    }
}
