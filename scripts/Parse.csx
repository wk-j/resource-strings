#! "netcoreapp2.1"

using System.Resources;
using System.Xml;
using System.Xml.Linq;

var file = "src/ResourceStrings/Strings.resx";

using (var fs = File.OpenRead(file)) {
    var resx = XDocument.Load(fs);

    using (var writerStream = new MemoryStream()) {
        var rw = new ResourceWriter(writerStream);

        foreach (var e in resx.Root.Elements("data")) {
            var name = e.Attribute("name").Value;
            var value = e.Element("value").Value;
            Console.WriteLine($"{name} {value}");
        }
    }
}
