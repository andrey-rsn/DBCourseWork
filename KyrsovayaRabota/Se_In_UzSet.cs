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
    
    public partial class Se_In_UzSet
    {
        public int Id { get; set; }
        public string UZCodeUz { get; set; }
        public string SECodeSE { get; set; }
        public int i { get; set; }
    
        public virtual SE SE { get; set; }
        public virtual UZ UZ { get; set; }
    }
}