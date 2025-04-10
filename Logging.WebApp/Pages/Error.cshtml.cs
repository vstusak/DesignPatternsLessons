using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Logging.WebApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string TraceId { get; set; }
        public Activity? CurrentActivity { get; set; }

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CurrentActivity = Activity.Current;
            TraceId = HttpContext.TraceIdentifier;
        }

        public void OnPost()
        {
            CurrentActivity = Activity.Current;
            TraceId = HttpContext.TraceIdentifier;
        }

    }

}
