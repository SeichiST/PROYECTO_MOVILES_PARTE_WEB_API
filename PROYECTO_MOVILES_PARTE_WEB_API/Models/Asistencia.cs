using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Asistencia
{
    public int PkIdAsistencia { get; set; }

    public DateOnly FechaClase { get; set; }

    public string Estado { get; set; } = null!;

    public int FkIdAlumno { get; set; }

    [JsonIgnore]
    public virtual Alumno FkIdAlumnoNavigation { get; set; } = null!;
}
