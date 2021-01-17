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
            var downloadData = new DownloadData();
            DownLoadedData downloadedData = downloadData.Get(xmlRooting.SourceUrl);

            var organizerData = new OrganizerData();
            var products = organizerData.Organizer(downloadedData);

            var createXml = new CreateXml();
            createXml.Create(products, xmlRooting.TargetFilePath);
        }
    }
}
