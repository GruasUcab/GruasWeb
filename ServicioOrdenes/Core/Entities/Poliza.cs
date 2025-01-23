using System;

namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class Poliza
    {
        public Guid Id { get; private set; }
        public  string? Nombre {get; private set;} 
        public string TipoCobertura { get; private set; } = default!;
        public decimal KilometrosIncluidos { get; private set; }
        public decimal CostoXKilometro {get; private set;} 

        public Poliza(Guid id, string tipoCobertura, decimal kilometrosIncluidos, string nombre, decimal costoxKilometro)
        {
            Id = id;
            TipoCobertura = tipoCobertura;
            KilometrosIncluidos = kilometrosIncluidos;
            Nombre = nombre;
            CostoXKilometro = costoxKilometro;
        }

        public void Actualizar(string tipoCobertura, decimal kilometrosIncluidos, decimal costoxKilometro)
        {
            TipoCobertura = tipoCobertura;
            KilometrosIncluidos = kilometrosIncluidos;
            CostoXKilometro = costoxKilometro;
        }
        private Poliza(){}
    }
}
