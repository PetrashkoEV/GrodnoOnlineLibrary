//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySqlContext.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class articleloc
    {
        public int article { get; set; }
        public int locale { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    
        public virtual article article1 { get; set; }
        public virtual locale locale1 { get; set; }
    }
}