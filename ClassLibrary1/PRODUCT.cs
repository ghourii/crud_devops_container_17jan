//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.ACCOUNTs = new HashSet<ACCOUNT>();
        }
    
        public string PRODUCT_CD { get; set; }
        public Nullable<System.DateTime> DATE_OFFERED { get; set; }
        public Nullable<System.DateTime> DATE_RETIRED { get; set; }
        public string NAME { get; set; }
        public string PRODUCT_TYPE_CD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT> ACCOUNTs { get; set; }
        public virtual PRODUCT_TYPE PRODUCT_TYPE { get; set; }
    }
}
