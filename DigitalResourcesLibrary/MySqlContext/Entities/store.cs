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
    
    public partial class store
    {
        public store()
        {
            this.storeloc = new HashSet<storeloc>();
            this.tag = new HashSet<tag>();
        }
    
        public int id { get; set; }
        public long category { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<bool> visible { get; set; }
        public long owner { get; set; }
    
        public virtual category category1 { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<storeloc> storeloc { get; set; }
        public virtual ICollection<tag> tag { get; set; }
    }
}
