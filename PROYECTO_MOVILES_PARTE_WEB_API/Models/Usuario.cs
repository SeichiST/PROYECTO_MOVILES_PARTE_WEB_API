using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Usuario
{
    public int PkIdUsuario { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Activo { get; set; }

    public string Rol { get; set; } = null!;

    [JsonIgnore]
    public virtual Profesor? Profesor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
