//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palette.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class APIKeys
    {
        public int APIKeyID { get; set; }
        public int UserID { get; set; }
        public string APIRole { get; set; }
        public System.Guid UserKey { get; set; }
        public System.DateTime KeyCreateDate { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
