using Menu_Generator.Thief.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Logic
{
    public class Service
    {
        public static void Processor(string filePath)
        {
            List<string[]> downloadData = DownloadData.Download();
            List<Product> products = OrganizerData.Organizer(downloadData);
            CreateXml.Create(products, filePath);
        }
    }
}
