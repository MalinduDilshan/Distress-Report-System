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

    [MetadataType(typeof(Licence))]

    public partial class licence
    {
        public int licence_id { get; set; }
        public string licence_callsign { get; set; }
        public Nullable<System.DateTime> licence_date_from { get; set; }
        public Nullable<System.DateTime> licence_date_to { get; set; }
        public string licence_trc_fileno { get; set; }
        public System.DateTime licence_created_date { get; set; }
        public string licence_created_by { get; set; }
        public System.DateTime licence_last_modified_date { get; set; }
        public string licence_last_modified_by { get; set; }
        public int licence_status { get; set; }
        public int vessel_id { get; set; }
    
        public virtual vessel vessel { get; set; }
    }
}
