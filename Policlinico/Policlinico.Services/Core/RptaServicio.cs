using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinico.Services.Core
{
    public class RptaServicio<T>
    {
        public RptaServicio(T datos,string mensajeError ="")
        {
            Datos = datos;
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MensajeError = mensajeError;
                TieneErrores = true;
            }
        }
        public bool TieneErrores { get; private set; }
        public string MensajeError { get; private set; }
        public T Datos  { get; private set; }

    }
}
