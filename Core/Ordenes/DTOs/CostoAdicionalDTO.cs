namespace GrúasUCAB.Core.Ordenes.DTOs
{
    public class CreateCostoAdicionalDTO
    {
        public required string Nombre { get; set; }
        public required string Descripcion {get; set; }
        public decimal Monto { get; set; }
        public Guid OrdenId { get; set; }
    }

    public class UpdateCostoAdicionalDTO
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion{get; set; }
        public decimal Monto { get; set; }
    }

    public class CostoAdicionalDTO
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion {get; set; }
        public decimal Monto { get; set; }
        public Guid OrdenId { get; set; }
    }
}
