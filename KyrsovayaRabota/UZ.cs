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
    
    public partial class UZ
    {
        public string CodeUz { get; set; }
        public string NameUz { get; set; }
        public double NP { get; set; }
        public string SE_id { get; set; }
        public int i { get; set; }
    
        public virtual SE SE { get; set; }
    }
}
