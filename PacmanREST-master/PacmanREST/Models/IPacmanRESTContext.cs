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
        DbSet<Pacman_carer_db> Pacman_carer_db { get; }
        DbSet<Pacman_carer_patient_db> Pacman_carer_patient_db { get;  }
        DbSet<Pacman_fence_db> Pacman_fence_db { get; }
        DbSet<Pacman_location_db> Pacman_location_db { get; }
        DbSet<Fence> Fences { get; }
        DbSet<FencePoint> FencePoints { get;  }
        int SaveChanges();
        void MarkAsModifiedPacman_patient_db(Pacman_patient_db item);
        void MarkAsModifiedPacman_carer_db(Pacman_carer_db item);
        void MarkAsModifiedPacman_carer_patient_db(Pacman_carer_patient_db item);
        void MarkAsModifiedPacman_fence_db(Pacman_fence_db item);
        void MarkAsModifiedPacman_location_db(Pacman_location_db item);
        void MarkAsModifiedFence(Fence item);
        void MarkAsModifiedFencePoint(FencePoint item);  
    }
}
