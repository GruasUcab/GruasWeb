namespace GrúasUCAB.Core.Ordenes.Entities{
public enum OrdenEstado
{
    Pendiente,
    Asignada,
    EnProgreso,
    Completada,
    Cancelada
}

public enum OrdenTrigger
{
    Asignar,
    Iniciar,
    Completar,
    Cancelar
}
}
