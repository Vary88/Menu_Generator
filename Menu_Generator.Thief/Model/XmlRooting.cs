using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Generator.Thief.Model
{
    public class XmlRooting
    {
        public XmlRooting(string sourceUrl,
            string targetFilePath)
        {
            SourceUrl = sourceUrl;
            TargetFilePath = targetFilePath;
        }

        public string SourceUrl { get; }
        public string TargetFilePath { get; }
    }
}

