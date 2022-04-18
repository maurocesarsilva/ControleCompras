using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ControleCompras.Pages
{
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	[IgnoreAntiforgeryToken]
	public class ErrorModel : PageModel
	{
		public string? Message { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(Message);

		private readonly ILogger<ErrorModel> _logger;

		public ErrorModel(ILogger<ErrorModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			Message = HttpContext.Items.ContainsKey("Exception ") ? HttpContext.Items["Exception "].ToString() : "";
		}
	}
}