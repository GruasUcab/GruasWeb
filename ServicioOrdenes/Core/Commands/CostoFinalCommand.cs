using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GrúasUCAB.Core.Ordenes.Commands
{
    
    public class CostoFinalCommand : IRequest<Unit>
    {
        public Guid OrdenId { get; set; }
        //public int KilometrosTotales { get; set; }
        //public decimal CostoBase { get; set; }
        //public decimal CostoPorKilometro { get; set; }
        //public decimal CostosAdicionales { get; set; }

        public CostoFinalCommand(Guid ordenId)
        {
            OrdenId = ordenId;
            //KilometrosTotales = kilometrosTotales;
            //CostoBase = costoBase;
            //CostoPorKilometro = costoPorKilometro;
            //CostosAdicionales = costosAdicionales;
        }
    }
}
