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
    
    public partial class sp_ConsultarPeliculaPorCodigo_Result
    {
        public int PeliculaID { get; set; }
        public string CodPelicula { get; set; }
        public string Nombre { get; set; }
        public string Resena { get; set; }
        public Nullable<int> CalificacionGenerQal { get; set; }
        public Nullable<System.DateTime> FechaLanzamiento { get; set; }
        public Nullable<int> PosterID { get; set; }
    }
}