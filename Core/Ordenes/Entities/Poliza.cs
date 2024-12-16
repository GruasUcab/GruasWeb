namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class Poliza
    {
        public Guid Id { get; private set; }
        public string TipoCobertura { get; private set; }
        public int KilometrosIncluidos { get; private set; }

        public Poliza(Guid id, string tipoCobertura, int kilometrosIncluidos)
        {
            Id = id;
            TipoCobertura = tipoCobertura;
            KilometrosIncluidos = kilometrosIncluidos;
        }
    }
}
