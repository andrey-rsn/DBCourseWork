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
    
    public partial class Details_In_SESet
    {
        public int Id { get; set; }
        public string DETCodeDET { get; set; }
        public string SECodeSE { get; set; }
    
        public virtual DET DET { get; set; }
        public virtual SE SE { get; set; }
    }
}
