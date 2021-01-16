using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Model
{
    public class DownLoadedData
    {
        public DownLoadedData(
            List<string[]> data)
        {
            Data = data;
        }

        public List<string[]> Data { get;}
    }
}
