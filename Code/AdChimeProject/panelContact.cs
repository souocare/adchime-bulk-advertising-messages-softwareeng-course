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
    
    public partial class panelContact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public panelContact()
        {
            this.panelContactsVariables = new HashSet<panelContactsVariable>();
            this.tRecipientNumbers = new HashSet<tRecipientNumber>();
        }
    
        public int idContact { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> bActive { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCodePhone { get; set; }
        public string Country { get; set; }
        public Nullable<int> optinSMS { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updatedate { get; set; }
        public string updatedbyuser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<panelContactsVariable> panelContactsVariables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tRecipientNumber> tRecipientNumbers { get; set; }
    }
}
