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
    
    public partial class Pieza
    {
        public int Lote { get; set; }
        public int No_Serie { get; set; }
        public string No_Parte { get; set; }
        public Nullable<int> PK_Defecto { get; set; }
        public Nullable<int> Aprobada { get; set; }
        public Nullable<int> Rebraze { get; set; }
        public Nullable<int> Reparo { get; set; }
        public string Serie { get; set; }
    
        public virtual Defecto Defecto { get; set; }
        public virtual Lote Lote1 { get; set; }
    }
}
