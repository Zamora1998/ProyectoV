//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataPeliculas
{
    using System;
    using System.Collections.Generic;
    
    public partial class RolesEnPelicula
    {
        public int RolEnPeliculaID { get; set; }
        public Nullable<int> RolID { get; set; }
        public Nullable<int> ActorStaffID { get; set; }
        public Nullable<int> IDPelic { get; set; }
        public Nullable<int> OrdenAparicion { get; set; }
    
        public virtual ActoresStaff ActoresStaff { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
