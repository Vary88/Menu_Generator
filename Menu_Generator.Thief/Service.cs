using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public class Service
    {
        public static void Processor(XmlRooting xmlRooting)
        {
            DownLoadedData downloadData = DownloadData.Get(xmlRooting.SourceUrl);
            Products products = OrganizerData.Organizer(downloadData);
            CreateXml.Create(products, xmlRooting.TargetFilePath);
        }
    }
}
