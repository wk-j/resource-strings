## Resource Strings

```csharp
var key = "Acc_NotClassInit";
var rs = ResourceStrings.Parser.GetValue(key);
Assert.True(rs == "Type initializer was not callable.");
```