using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policlinico.Data.Model
{
    public  enum  ECalificacionAtencion : int 
    {
        Apto = 1 ,
        NoApto = 0
    }

    public enum EEstadoAtencion
    {
        Pendiente,
        Entregado
    }
}
