using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;

namespace ApiCompatibleTypeChange.Tests;

public class WeatherTests
{
    private WebApplicationFactory<Program> factory;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown()
    {
        factory.Dispose();
    }

    [TestCase("20.0", HttpStatusCode.BadRequest)]
    [TestCase(@"""20.0""", HttpStatusCode.Accepted)]
    [TestCase(@"""Cold""", HttpStatusCode.Accepted)]
    [TestCase(@"""Rainy""", HttpStatusCode.BadRequest)]
    public async Task PostAcceptsOnlyValidTemperatures(
        string serializedTemperature,
        HttpStatusCode statusCode
    )
    {
        var client = factory.CreateClient();
        var json = $$"""{"temperature":{{serializedTemperature}}}""";
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/weather", content);
        response.StatusCode.ShouldBe(statusCode);
    }
}
