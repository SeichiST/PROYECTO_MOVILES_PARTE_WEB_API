using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public int IdClase { get; set; }

    public int IdAlumno { get; set; }

    public string EstadoAsistencia { get; set; } = null!;

    [JsonIgnore]
    public virtual Clase? IdClaseNavigation { get; set; }

    [JsonIgnore]
    public virtual Alumno? IdAlumnoNavigation { get; set; }
}
