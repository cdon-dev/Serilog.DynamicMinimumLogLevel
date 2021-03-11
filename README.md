# Serilog.DynamicMinimumLogLevel
Drive your minimum LogEventLevel for serilog via IConfiguration

Example:
````csharp
private static void ConfigureLogger(HostBuilderContext hostContext, IServiceProvider services, LoggerConfiguration config)
{
	config
		.MinimumLevel.Is(hostContext.Configuration.GetMinimumLoggingLevel());
}
````