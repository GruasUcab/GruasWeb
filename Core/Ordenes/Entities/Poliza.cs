using System;

namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class Poliza
    {
        public Guid Id { get; private set; }
        public string TipoCobertura { get; private set; } = default!;
        public decimal KilometrosIncluidos { get; private set; }

        public Poliza(Guid id, string tipoCobertura, decimal kilometrosIncluidos)
        {
            Id = id;
            TipoCobertura = tipoCobertura;
            KilometrosIncluidos = kilometrosIncluidos;
        }

        public void Actualizar(string tipoCobertura, decimal kilometrosIncluidos)
        {
            TipoCobertura = tipoCobertura;
            KilometrosIncluidos = kilometrosIncluidos;
        }
    }
}
