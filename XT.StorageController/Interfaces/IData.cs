using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XT.StorageController.Interfaces
{
    public interface IData
    {
        dynamic GetData(int type);
    }
}
