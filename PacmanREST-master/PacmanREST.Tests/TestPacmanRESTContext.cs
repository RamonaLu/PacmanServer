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
            this.Pacman_carer_db = new TestCarerDbSet();
            this.Pacman_carer_patient_db = new TestCarerPatientDbSet();
            this.Pacman_fence_db = new TestFenceDbSet();
            this.Pacman_location_db = new TestLocationDbSet();
            this.Fences = new TestFencesDbSet();
            this.FencePoints = new TestFencePointDbSet();
        }

        public DbSet<Pacman_patient_db> Pacman_patient_db { get; set; }
        public DbSet<Pacman_carer_db> Pacman_carer_db { get; set; }
        public DbSet<Pacman_carer_patient_db> Pacman_carer_patient_db { get; set; }
        public DbSet<Pacman_fence_db> Pacman_fence_db { get; set; }
        public DbSet<Pacman_location_db> Pacman_location_db { get; set; }
        public DbSet<Fence> Fences { get; set; }
        public DbSet<FencePoint> FencePoints { get; set; }
        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModifiedPacman_patient_db(Pacman_patient_db item)
        {
            
        }
        public void MarkAsModifiedPacman_carer_db(Pacman_carer_db item)
        {
            
        }
        public void MarkAsModifiedPacman_carer_patient_db(Pacman_carer_patient_db item)
        {
            
        }
        public void MarkAsModifiedPacman_fence_db(Pacman_fence_db item)
        {
            
        }
        public void MarkAsModifiedPacman_location_db(Pacman_location_db item)
        {
            
        }
        public void MarkAsModifiedFence(Fence item)
        {
            
        }
        public void MarkAsModifiedFencePoint(FencePoint item)
        {
            
        }
        public void Dispose() { }
    }
}
 
