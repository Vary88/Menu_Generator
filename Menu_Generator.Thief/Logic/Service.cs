using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief.Logic
{
    public class Service
    {
        public static void Processor(string filePath)
        {
            DownLoadedData downloadData = DownloadData.Get();
            List<Product> products = OrganizerData.Organizer(downloadData);
            CreateXml.Create(products, filePath);
        }
    }
}
