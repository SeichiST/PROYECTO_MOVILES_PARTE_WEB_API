using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Cancha
{
    public int PkIdCancha { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoDeporteCesped { get; set; } = null!;

    public decimal PrecioAlquiler { get; set; }

    public bool Activo { get; set; }

    [JsonIgnore]
    public virtual ICollection<HorarioAcademia> HorarioAcademia { get; set; } = new List<HorarioAcademia>();

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
