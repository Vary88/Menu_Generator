using System;
using System.IO;
using Menu_Generator.Thief;
using Menu_Generator.Thief.Model;

namespace OptimusTestPad
{
    class Program
    {
        static void Main(string[] args)
        {
            //var filename = "Products.xml";
            //var currentDirectory = Directory.GetCurrentDirectory();
            //var purchaseOrderFilepath = Path.Combine($"{currentDirectory}/../../..", filename);

            var sourceUrl = "https://egeszsegkonyha.hu/index.php/etlapunk?week=202103";
            var targetFilePath = @"d:\work\FHCN\OptimusTestPad\Products.xml";
            var xmlRooting = new XmlRooting(sourceUrl, targetFilePath);

            var service = new Service();
            service.Processor(xmlRooting);
        }
    }
}
