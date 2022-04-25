using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecretsCSIWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment hostEnvironment;

        public string StorageConnection { get; set; }
        public string SBConnection { get; set; }
        public string MountData { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment hostEnv)
        {
            _logger = logger;
            hostEnvironment = hostEnv;
        }

        public void OnGet()
        {
            //ViewBag.Message = "System version 1";
            string sbKey = Environment.GetEnvironmentVariable("sb-env-secret") ?? "NA";
            string storageKey = Environment.GetEnvironmentVariable("storage-env-secret") ?? "NA";
            string sbKeyFile = "NA";
            string secretsFolder = Path.Combine(hostEnvironment.WebRootPath, "secrets");
            string sbSecretFile = Path.Combine(secretsFolder, "servicebus-key");
            if (System.IO.File.Exists(sbSecretFile))
                sbKeyFile = System.IO.File.ReadAllText(sbSecretFile);

            // var message = $"System: Version 1.0 || Dapr SB Key: {daprSBKey} || Dapr Stg Key: {daprStorageKey} || Dapr SB File: {daprSBKeyFile}";
            StorageConnection = storageKey;
            SBConnection = sbKey;
            MountData = $"Secret found at ({sbSecretFile}): {sbKeyFile}";
        }
    }
}