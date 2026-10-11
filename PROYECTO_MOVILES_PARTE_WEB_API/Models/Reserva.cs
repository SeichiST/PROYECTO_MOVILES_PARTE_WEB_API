using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime HoraInicio { get; set; }

    public DateTime HoraFin { get; set; }

    public decimal PrecioReserva { get; set; }

    public string EstadoReserva { get; set; } = null!;

    public decimal MontoRecibido { get; set; }

    public int IdCliente { get; set; }

    public int IdCancha { get; set; }

    public int IdUsuario { get; set; }

    [JsonIgnore]
    public virtual Cliente? IdClienteNavigation { get; set; }

    [JsonIgnore]
    public virtual Cancha? IdCanchaNavigation { get; set; }

    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<PrestamoBalon> PrestamoBalons { get; set; } = new List<PrestamoBalon>();
}
