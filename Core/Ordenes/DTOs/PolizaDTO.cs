namespace GrúasUCAB.Core.Ordenes.DTOs{

    public class CreatePolizaDTO
{
    
    public string TipoCobertura { get; set; } = default!;
    public decimal KilometrosIncluidos { get; set; }
    public required string Nombre {get; set;}
    public decimal CostoXKilometro {get; set;}
}

public class UpdatePolizaDTO
{
    public string TipoCobertura { get; set; } = default!;
    public decimal KilometrosIncluidos { get; set; }
    public decimal CostoXKilometro {get; set;}
}

public class PolizaDTO
{
    public Guid Id { get; set; }
    public required string Nombre {get; set;}
    public string TipoCobertura { get; set; } = default!;
    public decimal KilometrosIncluidos { get; set; }
    public decimal CostoXKilometro {get; set;}
}

}