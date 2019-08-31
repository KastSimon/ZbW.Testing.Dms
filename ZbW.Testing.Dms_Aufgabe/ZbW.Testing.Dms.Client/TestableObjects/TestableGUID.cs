using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
    public class TestableGUID
    {
        public virtual Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
