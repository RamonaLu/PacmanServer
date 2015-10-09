using PacmanREST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanREST.Tests
{
     public class TestPacmanRESTContext : IPacmanRESTContext
    {
        public TestPacmanRESTContext()
        {
            this.Pacman_patient_db = new TestPatientDbSet();
        }

        public DbSet<Pacman_patient_db> Pacman_patient_db { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Pacman_patient_db item) { }
        public void Dispose() { }
    }
}
 
