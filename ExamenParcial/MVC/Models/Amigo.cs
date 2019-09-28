using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{

    public class Amigo
    {
        public enum TipoList
        {
            Sergio,
            Sebastian,
            Santiago,
            Sobre,
            Salazar
        }

        [Key]
        public int FriendId { get; set; }
        [Required]
        [Display(Description = "Nombre Completo")]
        public string Name { get; set; }
        public TipoList List { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Description = "Cumpleaños")]
        public DateTime Birthdate { get; set; }
    }
}