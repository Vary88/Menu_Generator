using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Menu_Generator.Thief.Model;

namespace Menu_Generator.Thief
{
    public interface IXmlGenerator
    {
        XmlDocument Generate(Products products);
    }
}
