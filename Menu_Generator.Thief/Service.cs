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
            Bootstrap.Start();

            var downloader = Bootstrap.container.GetInstance<IDownloader>();
            var organizer = Bootstrap.container.GetInstance<IProductCreator>();
            var generator = Bootstrap.container.GetInstance<IXmlGenerator>();

            var downloadedData = downloader.Get(xmlRooting.SourceUrl);
            var products = organizer.Get(downloadedData);
            var xmlDocument = generator.Get(products);

            xmlDocument.Save(xmlRooting.TargetFilePath);
        }
    }
}
