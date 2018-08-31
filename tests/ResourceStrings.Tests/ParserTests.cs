using System;
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
    }
}
