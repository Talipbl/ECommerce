using ECommerce.Trendyol;

namespace ECommerce.UnitTests.Trendyol;

public class TrendyolErrorParserTests
{
    [Fact]
    public void Parse_reads_trendyol_error_body()
    {
        const string body = """{"timestamp":1,"exception":"ValidationException","errors":[{"key":"barcode","message":"Zorunlu"}]}""";

        var error = TrendyolErrorParser.Parse(body);

        error.Exception.ShouldBe("ValidationException");
        error.Errors.ShouldHaveSingleItem().Message.ShouldBe("Zorunlu");
    }

    [Theory]
    [InlineData("Service Unavailable")]
    [InlineData("")]
    public void Parse_wraps_non_json_body_as_single_error(string body)
    {
        var error = TrendyolErrorParser.Parse(body);

        error.Errors.ShouldHaveSingleItem().Message.ShouldBe(body);
    }

    [Fact]
    public void Parse_handles_null_body()
    {
        var error = TrendyolErrorParser.Parse(null);

        error.Errors.ShouldHaveSingleItem().Message.ShouldBe(string.Empty);
    }
}
