
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PacmanREST.Models
{

using System;
    using System.Collections.Generic;
    
public partial class FencePoint
{

    public int Id { get; set; }

    public int FenceID { get; set; }

    public decimal XCoordinate { get; set; }

    public decimal YCoordinate { get; set; }



    public virtual Fence Fence { get; set; }

}

}
