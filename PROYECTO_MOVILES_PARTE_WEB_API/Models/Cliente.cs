using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string TipoCliente { get; set; } = null!;

    public bool ActivoCliente { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string? TelefonoCliente { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
