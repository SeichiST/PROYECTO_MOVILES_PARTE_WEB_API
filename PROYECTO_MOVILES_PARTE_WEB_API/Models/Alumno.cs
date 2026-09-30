using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Alumno
{
    public int PkIdAlumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string? TelefonoApoderado { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public int FkIdProfesor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    [JsonIgnore]
    public virtual Profesor FkIdProfesorNavigation { get; set; } = null!;
}
