using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public interface IProductCreator
    {
        Products Get(DownLoadedData downloadData);
    }
}
