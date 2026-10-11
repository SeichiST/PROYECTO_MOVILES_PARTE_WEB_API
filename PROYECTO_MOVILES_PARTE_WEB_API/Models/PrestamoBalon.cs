using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class PrestamoBalon
{
    public int IdPrestamo { get; set; }

    public int? IdReserva { get; set; }

    public int? IdClase { get; set; }

    public DateTime FechaEntrega { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string EstadoPrestamo { get; set; } = null!;

    [JsonIgnore]
    public virtual Reserva? IdReservaNavigation { get; set; }

    [JsonIgnore]
    public virtual Clase? IdClaseNavigation { get; set; }
}
