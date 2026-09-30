using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class HorarioAcademia
{
    public int PkIdHorario { get; set; }

    public int FkIdProfesor { get; set; }

    public int FkIdCancha { get; set; }

    public string DiaSemana { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool Activo { get; set; }

    [JsonIgnore]
    public virtual Cancha FkIdCanchaNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Profesor FkIdProfesorNavigation { get; set; } = null!;
}
