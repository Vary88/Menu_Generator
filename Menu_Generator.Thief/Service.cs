using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public class Service
    {
        public void Processor(XmlRooting xmlRooting)
        {
            var downloadData = new Downloader();
            DownLoadedData downloadedData = downloadData.Get(xmlRooting.SourceUrl);

            var organizerData = new Organizer();
            var products = organizerData.OrganizerData(downloadedData);

            var createXml = new XmlGenerator();
            createXml.Generate(products, xmlRooting.TargetFilePath);
        }
    }
}
