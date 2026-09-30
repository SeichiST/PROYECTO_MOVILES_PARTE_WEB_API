using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Profesor
{
    public int PkIdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? CategoriaEdad { get; set; }

    public int? FkIdUsuario { get; set; }

    [JsonIgnore]
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    [JsonIgnore]
    public virtual Usuario? FkIdUsuarioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<HorarioAcademia> HorarioAcademia { get; set; } = new List<HorarioAcademia>();
}
