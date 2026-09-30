using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Reserva
{
    public int PkIdReserva { get; set; }

    public DateTime HoraInicio { get; set; }

    public DateTime HoraFin { get; set; }

    public decimal Adelanto { get; set; }

    public decimal Saldo { get; set; }

    public string Estado { get; set; } = null!;

    public int FkIdCancha { get; set; }

    public int FkIdCliente { get; set; }

    public int FkIdUsuario { get; set; }

    [JsonIgnore]
    public virtual Cancha FkIdCanchaNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Cliente FkIdClienteNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Usuario FkIdUsuarioNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<PrestamoBalon> PrestamoBalons { get; set; } = new List<PrestamoBalon>();
}
