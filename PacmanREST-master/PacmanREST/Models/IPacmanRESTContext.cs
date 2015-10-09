using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PacmanREST.Models
{
    public interface IPacmanRESTContext : IDisposable
    {
        DbSet<Pacman_patient_db> Pacman_patient_db { get; }
        int SaveChanges();
        void MarkAsModified(Pacman_patient_db patient);
    }
}
