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

    [MetadataType(typeof(RadioStation))]

    public partial class radio_station
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public radio_station()
        {
            this.d_detail = new HashSet<d_detail>();
            this.users = new HashSet<user>();
        }
    
        public int mcs_id { get; set; }
        public string mcs_callsign { get; set; }
        public string mcs_location { get; set; }
        public string mcs_radio_equipment { get; set; }
        public Nullable<System.DateTime> mcs_radio_equipment_place_date { get; set; }
        public System.DateTime mcs_created_date { get; set; }
        public string mcs_created_by { get; set; }
        public System.DateTime mcs_last_modified_date { get; set; }
        public string mcs_last_modified_by { get; set; }
        public int mcs_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<d_detail> d_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
