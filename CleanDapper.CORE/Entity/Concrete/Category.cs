using CleanDapper.CORE.Entity.Abstract;
using CleanDapper.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanDapper.CORE.Entity.Concrete
{
    public class Category : IBaseEntity
    {
        private Situations _statu = Situations.Active;
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Situations Statu
        {
            get { return _statu; }
            set { _statu = value; }
        }
        public string CategoryName { get; set; }


    }
}
