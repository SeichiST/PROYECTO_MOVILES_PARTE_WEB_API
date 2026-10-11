using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Cancha
{
    public int IdCancha { get; set; }

    public string NombreCancha { get; set; } = null!;

    public string DescripcionCancha { get; set; } = null!;

    public decimal PrecioAlquiler { get; set; }

    public bool ActivoCancha { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [JsonIgnore]
    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
