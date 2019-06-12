using ProjektZaliczeniowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjektZaliczeniowy.DAL
{
    public class UzytkownikDAL : DbContext
    {
        public UzytkownikDAL() : base("connectionString")
        {

        }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
    }


}