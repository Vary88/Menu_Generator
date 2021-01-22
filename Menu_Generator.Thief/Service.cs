using System;
using System.Collections.Generic;
using System.Text;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public class Service
    {
        private readonly IDownloader _downloader;
        private readonly IProductCreator _productCreator;
        private readonly IXmlGenerator _generator;

        public Service
            (IDownloader downloader,
            IProductCreator productCreator,
            IXmlGenerator generator)
        {
            _downloader = downloader;
            _productCreator = productCreator;
            _generator = generator;
        }

        public void Processor(XmlRooting xmlRooting)
        {
          

            var downloadedData = _downloader.Get(xmlRooting.SourceUrl);
            var products = _productCreator.Create(downloadedData);
            var xmlDocument = _generator.Generate(products);

            xmlDocument.Save(xmlRooting.TargetFilePath);
        }
    }
}
