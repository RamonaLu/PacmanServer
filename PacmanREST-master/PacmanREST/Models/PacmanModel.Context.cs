﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PacmanREST.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class pacmanAndroidNew_dbEntities : DbContext, IPacmanRESTContext
{
    public pacmanAndroidNew_dbEntities()
        : base("name=pacmanAndroidNew_dbEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Pacman_carer_db> Pacman_carer_db { get; set; }

    public virtual DbSet<Pacman_carer_patient_db> Pacman_carer_patient_db { get; set; }

    public virtual DbSet<Pacman_fence_db> Pacman_fence_db { get; set; }

    public virtual DbSet<Pacman_location_db> Pacman_location_db { get; set; }

    public virtual DbSet<Pacman_patient_db> Pacman_patient_db { get; set; }

    public virtual DbSet<Fence> Fences { get; set; }

    public virtual DbSet<FencePoint> FencePoints { get; set; }
        public void MarkAsModified(Pacman_patient_db item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }

}

