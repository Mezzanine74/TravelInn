//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelInn.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uyruk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uyruk()
        {
            this.Musteris = new HashSet<Musteri>();
        }
    
        public int Id { get; set; }
        public string Uyrugu { get; set; }
        public string Uniqueidentifier { get; set; }
        public string WhoInserted { get; set; }
        public string WhoUpdated { get; set; }
        public string WhoDeleted { get; set; }
        public Nullable<System.DateTime> WhenInserted { get; set; }
        public Nullable<System.DateTime> WhenUpdated { get; set; }
        public Nullable<System.DateTime> WhenDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteris { get; set; }
    }
}
