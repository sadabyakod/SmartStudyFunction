using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SmartStudyFunction;

public class BlobTriggerFunction
{
    private readonly ILogger<BlobTriggerFunction> _logger;

    public BlobTriggerFunction(ILogger<BlobTriggerFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobTriggerFunction))]
    public async Task Run([BlobTrigger("sample-container/{name}", Connection = "AzureWebJobsStorage")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("✅ FILE UPLOADED: {name}", name);
        _logger.LogInformation("File size: {size} bytes", stream.Length);
        _logger.LogInformation("Content preview: {content}", content.Substring(0, Math.Min(200, content.Length)));
    }
}