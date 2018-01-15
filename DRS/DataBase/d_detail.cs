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

    [MetadataType(typeof(DistressViewModel))]

    public partial class d_detail
    {
        public int d_detail_id { get; set; }
        public string d_detail_lkp_lat_deg { get; set; }
        public string d_detail_lkp_lat_min { get; set; }
        public string d_detail_lkp_lat_direction { get; set; }
        public string d_detail_lkp_long_deg { get; set; }
        public string d_detail_lkp_long_min { get; set; }
        public string d_detail_lkp_long_direction { get; set; }
        public System.DateTime d_detail_lkp_date { get; set; }
        public System.TimeSpan d_detail_lkp_time { get; set; }
        public string d_detail_communication_freqency { get; set; }
        public string d_detail_nature_of_distress { get; set; }
        public int d_detail_no_of_crew { get; set; }
        public string d_detail_names_of_crew { get; set; }
        public string d_detail_action_taken { get; set; }
        public string d_detail_remarks { get; set; }
        public System.DateTime d_detail_departure_date { get; set; }
        public System.TimeSpan d_detail_departure_time { get; set; }
        public string d_detail_departure_location { get; set; }
        public System.DateTime d_detail_created_date { get; set; }
        public string d_detail_created_by { get; set; }
        public System.DateTime d_detail_last_modified_date { get; set; }
        public string d_detail_last_modified_by { get; set; }
        public int d_detail_status { get; set; }
        public int vessel_id { get; set; }
        public int distress_id { get; set; }
        public int mcs_id { get; set; }
    
        public virtual distress distress { get; set; }
        public virtual radio_station radio_station { get; set; }
        public virtual vessel vessel { get; set; }
    }
}
