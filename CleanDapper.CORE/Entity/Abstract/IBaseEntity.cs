using CleanDapper.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanDapper.CORE.Entity.Abstract
{
    public interface IBaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Situations Statu { get; set; }
    }
}
