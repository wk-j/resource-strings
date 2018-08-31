using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ResourceStrings {
    public class KeyValue {
        public string Key { set; get; }
        public string Value { set; get; }
    }

    public static class Parser {

        static IEnumerable<KeyValue> keyValues = Enumerable.Empty<KeyValue>();

        private static StreamReader ReadResource() {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("ResourceStrings.Strings.xml");
            return new StreamReader(resourceStream, Encoding.UTF8);
        }

        public static string GetValue(string key) {
            var kv = GetResource();
            return kv.FirstOrDefault(x => x.Key == key)?.Value ?? "";
        }

        private static IEnumerable<KeyValue> GetResource() {
            if (keyValues.Any()) {
                return keyValues;
            } else {
                var list = new List<KeyValue>();
                var stream = ReadResource();
                var resources = XDocument.Load(stream);
                foreach (var e in resources.Root.Elements("data")) {
                    var name = e.Attribute("name").Value;
                    var value = e.Element("value").Value;
                    list.Add(new KeyValue {
                        Key = name,
                        Value = value
                    });
                }
                keyValues = list;
                return list;
            }
        }
    }
}
