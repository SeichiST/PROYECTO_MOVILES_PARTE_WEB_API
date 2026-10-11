using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string NombreAlumno { get; set; } = null!;

    public string? TelefonoApoderado { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public bool ActivoAlumno { get; set; }

    public int IdUsuario { get; set; }

    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
}
