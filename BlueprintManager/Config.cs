using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    [Serializable]
    public class Config
    {
        public string BackupFolder { get; set; }
        public bool Startup { get; set; }
        public string TargetFolder { get; set; }

        internal static Config Load()
        {
            var path = "config.xml";
            if (!System.IO.File.Exists(path))
            {
                return new Config();
            }

            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            
            using (var f = new System.IO.StreamReader(path))
            {
                return (Config)ser.Deserialize(f);
            }
        }

        internal void Save()
        {
            var path = "config.xml";

            var ser = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            

            using (var f = new System.IO.StreamWriter(path))
            {
                ser.Serialize(f, this);
            }
        }
    }
}
