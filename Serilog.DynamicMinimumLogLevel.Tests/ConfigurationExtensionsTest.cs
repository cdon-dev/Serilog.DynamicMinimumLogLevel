using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Serilog.DynamicMinimumLogLevel.Tests
{
    public class ConfigurationExtensionsTest
    {
        [Fact]
        public void Should_return_Information_when_LogLevel_not_set()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["asd"] = "ftw"
                }).Build();

            var result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Information);
        }

        [Fact]
        public void Should_return_Information_when_LogLevel_set_to_invalid_value()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["LogLevel"] = "ftw"
                }).Build();

            var result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Information);
        }

        [Fact]
        public void Should_return_correct_LogEventLevel_when_set_in_config()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["LogLevel"] = "Verbose"
                }).Build();

            var result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Verbose);

            config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["LogLevel"] = "Warning"
                }).Build();

            result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Warning);

            config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["LogLevel"] = "Error"
                }).Build();

            result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Error);

            config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["LogLevel"] = "Information"
                }).Build();

            result = config.GetMinimumLoggingLevel();

            result.ShouldBe(LogEventLevel.Information);
        }
    }
}
