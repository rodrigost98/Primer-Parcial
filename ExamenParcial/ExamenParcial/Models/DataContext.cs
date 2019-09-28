using System.Data.Entity;

namespace ExamenParcial.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ExamenParcial.Models.Amigo> Amigoes { get; set; }
    }
}