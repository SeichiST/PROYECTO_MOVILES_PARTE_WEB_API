using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Clase
{
    public int IdClase { get; set; }

    public int IdUsuario { get; set; }

    public int IdCancha { get; set; }

    public DateOnly FechaClase { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string EstadoClase { get; set; } = null!;

    public bool ActivoClase { get; set; }

    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [JsonIgnore]
    public virtual Cancha? IdCanchaNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();

    [JsonIgnore]
    public virtual ICollection<PrestamoBalon> PrestamoBalons { get; set; } = new List<PrestamoBalon>();
}
