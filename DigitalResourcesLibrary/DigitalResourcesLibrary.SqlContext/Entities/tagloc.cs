//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalResourcesLibrary.SqlContext.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tagloc
    {
        public int tag { get; set; }
        public int locale { get; set; }
        public string value { get; set; }
    
        public virtual locale locale1 { get; set; }
        public virtual tag tag1 { get; set; }
    }
}
