using Microsoft.Extensions.Logging;

namespace EnumerableExamplesEntity;

public static class Console
{
    public static void LogMessage(this ILogger logger, string message)
    {
        logger.LogInformation("\n {message} \n----------------------", message);
    }
}
