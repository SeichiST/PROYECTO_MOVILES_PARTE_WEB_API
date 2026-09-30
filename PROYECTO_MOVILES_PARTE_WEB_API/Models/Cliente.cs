using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Cliente
{
    public int PkIdCliente { get; set; }

    public string Dni { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string TipoCliente { get; set; } = null!;

    public bool Activo { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
