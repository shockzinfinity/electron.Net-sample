using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace processes.Pages
{
  public class IndexModel : PageModel
  {
    public List<Process> Processes { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    public void OnGet()
    {
      var items = Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.ProcessName) && !p.ProcessName.Contains("handle="));
      Processes = items.ToList();
    }
  }
}
