using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Work.Pages;

public class Index_Tests : WorkWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
