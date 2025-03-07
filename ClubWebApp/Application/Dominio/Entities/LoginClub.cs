using System.ComponentModel.DataAnnotations;

namespace ClubWebApp.Application.Dominio.Entities
{
    public partial class LoginClub
    {
        [Key]
        public int IdLogin { get; set; }
        public string Usuario { get; set; }
        public string PasswordU { get; set; }
        public int Pin { get; set; }
    }
}
