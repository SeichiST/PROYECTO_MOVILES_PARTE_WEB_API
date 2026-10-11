using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string UsernameUsuario { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool ActivoUsuario { get; set; }

    public string Rol { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [JsonIgnore]
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    [JsonIgnore]
    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
