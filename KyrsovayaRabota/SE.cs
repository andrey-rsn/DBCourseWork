//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KyrsovayaRabota
{
    using System;
    using System.Collections.Generic;
    
    public partial class SE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SE()
        {
            this.UZ = new HashSet<UZ>();
        }
    
        public string CodeSE { get; set; }
        public string NameSE { get; set; }
        public double e { get; set; }
        public double del_tk { get; set; }
        public int m { get; set; }
        public double PsiP { get; set; }
        public double Ip { get; set; }
        public double q { get; set; }
        public double z0 { get; set; }
        public string TrType { get; set; }
        public double bo { get; set; }
        public double br { get; set; }
        public double N { get; set; }
        public double F_okr { get; set; }
        public double u { get; set; }
        public string DET_id { get; set; }
        public double F_pred { get; set; }
        public double h { get; set; }
        public double a { get; set; }
        public double a_min { get; set; }
        public double a_max { get; set; }
        public double del { get; set; }
    
        public virtual DET DET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UZ> UZ { get; set; }
    }
}
