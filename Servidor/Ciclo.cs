//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servidor
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciclo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ciclo()
        {
            this.Muestras = new HashSet<Muestra>();
            this.Lotes = new HashSet<Lote>();
        }
    
        public string Horno { get; set; }
        public int No_Ciclo { get; set; }
        public int PK_Usuario { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muestra> Muestras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
