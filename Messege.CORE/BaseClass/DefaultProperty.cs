using Messege.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messege.CORE.BaseClass
{
    public class DefaultProperty
    {
        public DefaultProperty()
        {
            CreatedDate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
