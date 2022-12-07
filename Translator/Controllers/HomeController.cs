using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Translator.Models;

namespace Translator.Controllers;

public class HomeController : Controller
{
    private readonly IAPIClient _apiClient;

    public HomeController(IAPIClient apiClient)
    {
        _apiClient = apiClient;
    }

    public IActionResult Index(Translation translation)
    {
        //var translation = new Translation();

        if (translation.TextToTranslate == null)
        {
            return View(translation);
        }

        translation = _apiClient.Translate(translation);

        return View(translation);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

