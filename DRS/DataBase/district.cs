//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DRS.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;

    [MetadataType(typeof(District))]

    public partial class district
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public district()
        {
            this.vessels = new HashSet<vessel>();
        }
    
        public int district_id { get; set; }
        public string district_code { get; set; }
        public string district_name { get; set; }
        public System.DateTime district_created_date { get; set; }
        public string district_created_by { get; set; }
        public System.DateTime district_last_modified_date { get; set; }
        public string district_last_modified_by { get; set; }
        public int district_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vessel> vessels { get; set; }
    }
}
