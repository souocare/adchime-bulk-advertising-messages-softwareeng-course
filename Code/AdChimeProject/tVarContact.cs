//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdChimeProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class tVarContact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tVarContact()
        {
            this.panelContactsVariables = new HashSet<panelContactsVariable>();
        }
    
        public int idVar { get; set; }
        public Nullable<bool> visible { get; set; }
        public string VarName { get; set; }
        public Nullable<int> colNumber { get; set; }
        public string colTypeType { get; set; }
        public string colTypeFilter { get; set; }
        public Nullable<System.DateTime> insertdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<panelContactsVariable> panelContactsVariables { get; set; }
    }
}
