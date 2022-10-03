using System.ComponentModel.DataAnnotations;

namespace AP1_AP_Oly.Models
{
    public class Aportes
    {

        [Key]
        public int AportesId { get; set; }

        public string Persona { get; set; }

        public double Monto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;



    }
}
