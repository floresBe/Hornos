﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HornosHaltingEntities : DbContext
    {
        public HornosHaltingEntities()
            : base("name=HornosHaltingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ciclo> Cicloes { get; set; }
        public virtual DbSet<Defecto> Defectoes { get; set; }
        public virtual DbSet<Muestra> Muestras { get; set; }
        public virtual DbSet<NumeroParte> NumeroPartes { get; set; }
        public virtual DbSet<ParteCiclo> ParteCicloes { get; set; }
        public virtual DbSet<PartePrueba> PartePruebas { get; set; }
        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Prueba> Pruebas { get; set; }
        public virtual DbSet<PruebaPieza> PruebaPiezas { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<TipoSensor> TipoSensors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
