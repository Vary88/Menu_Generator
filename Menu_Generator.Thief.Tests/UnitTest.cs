using NUnit.Framework;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public class Tests
    {
        private Service _service;

        [SetUp]
        public void Setup()
        {
            IDownloader downloader = new Downloader();
            IProductCreator productCreator = new ProductCreator();
            IXmlGenerator xmlGenerator = new XmlGenerator();

            _service = new Service(downloader,
                productCreator,
                xmlGenerator);
        }

        [Test]
        public void Test()
        {
            //Arrange
            var sourceUrl = "https://egeszsegkonyha.hu/index.php/etlapunk?week=202103";
            var targetFilePath = @"d:\work\FHCN\Menu_Generator.Thief.Tests\Products.xml";

            var xmlRooting = new XmlRooting(sourceUrl,
                targetFilePath);

            //Act
            _service.Processor(xmlRooting);

          //Assert
         
        }
    }
}