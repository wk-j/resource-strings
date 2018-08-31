using System;
using System.Resources;
using System.Threading.Tasks;
using Xunit;

namespace ResourceStrings.Tests {
    public class ParserTests {
        [Fact]
        public void GetValue() {
            var key = "";
            var rs = ResourceStrings.Parser.GetValue(key);
            Assert.True(rs == "");
        }

        [Fact]
        public void Acc_NotClassInit() {
            var key = "Acc_NotClassInit";
            var rs = ResourceStrings.Parser.GetValue(key);
            Assert.True(rs == "Type initializer was not callable.");
        }

        [Fact]
        public void X() {
            var manager = new global::System.Resources.ResourceManager("ResourceStrings.Tests.Strings", typeof(ParserTests).Assembly);
            var en = manager.GetString("Access_Void", new System.Globalization.CultureInfo("en-US"));
            var th = manager.GetString("Access_Void", new System.Globalization.CultureInfo("th-TH"));

            Console.WriteLine($">> {en}");
            Console.WriteLine($">> {th}");
        }
    }
}
