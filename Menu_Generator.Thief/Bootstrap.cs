using System;
using System.Collections.Generic;
using System.Text;

using SimpleInjector;

namespace Menu_Generator.Thief
{
    class Bootstrap
    {
        public static Container container;

        public static void Start()
        {
            container = new Container();

            container.Register<IDownloader, Downloader>(Lifestyle.Transient);
            container.Register<IProductCreator, ProductCreator>(Lifestyle.Transient);
            container.Register<IXmlGenerator, XmlGenerator>(Lifestyle.Transient);

            container.Verify();
        }
    }
}
