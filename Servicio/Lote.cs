//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Lote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lote()
        {
            this.Piezas = new HashSet<Pieza>();
        }
    
        public int PK_Lote { get; set; }
        public string Horno { get; set; }
        public int No_Ciclo { get; set; }
        public int PK_Usuario { get; set; }
        public string FechaAlta { get; set; }
    
        public virtual Ciclo Ciclo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pieza> Piezas { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
