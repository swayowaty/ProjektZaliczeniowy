using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektZaliczeniowy.Models
{
    public class Uzytkownik
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Musisz podac imie!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Musisz podac Nazwisko!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Musisz podac Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Musisz podac Nickname!")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Musisz podac Haslo!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Potwierdz haslo.")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
        public virtual ICollection<BlogPost> BlogPost { get; set; }


    }
}