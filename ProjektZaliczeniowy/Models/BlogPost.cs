using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektZaliczeniowy.Models
{
    public class BlogPost
    {
        [Key]
        public int PostID { get; set; }
        public string UserID { get; set; }
        public string Post_title { get; set; }
        public string Image { get; set; }

        public string Podpis { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }

    }
}