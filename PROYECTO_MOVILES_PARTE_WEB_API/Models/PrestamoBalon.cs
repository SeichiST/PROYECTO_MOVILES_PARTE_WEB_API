using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class PrestamoBalon
{
    public int PkIdPrestamo { get; set; }

    public int FkIdReserva { get; set; }

    public string DniGarantia { get; set; } = null!;

    public DateTime FechaEntrega { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public string Estado { get; set; } = null!;

    [JsonIgnore]
    public virtual Reserva FkIdReservaNavigation { get; set; } = null!;
}
