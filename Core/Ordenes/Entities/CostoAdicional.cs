namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class CostoAdicional
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal Monto { get; private set; }

        // Relación con OrdenServicio
        public Guid OrdenId { get; private set; }
        public OrdenDeServicio Orden { get; private set; } = null!;

        public CostoAdicional(Guid id, string nombre, decimal monto, Guid ordenId)
        {
            Id = id;
            Nombre = nombre;
            Monto = monto;
            OrdenId = ordenId;
        }
    }
}
