using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JJOO.Models;

namespace JJOO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.Paises = bd.ListarPaises();
        return View();
    }
    public IActionResult Deportes()
    {
        ViewBag.Deportes = bd.ListarDeportes();
        return View("Deportes");
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.Deportes = bd.ListarDeportes();
        ViewBag.Paises = bd.ListarPaises();
        return View();
    }

    [HttpPost] public IActionResult GuardarDeportista(string apellido, string nombre, DateTime fechaNacimiento, string foto, int idPais, int idDeporte)
    {
        Deportista nuevoDeportista = new Deportista(0, apellido, nombre, fechaNacimiento, foto, idPais, idDeporte);
        bd.AgregarDeportista(nuevoDeportista);
        return View("Index");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult EliminarDeportista(int idCandidato)
    {
        bd.EliminarDeportista(idCandidato);
        return View();
    }
    public IActionResult VerDetalleDeportista(int IdDeportista)
    {
        ViewBag.Deportista = bd.VerInfoPais(IdDeportista);
        return View("DetalleDeportista");
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.Deportistas = bd.ListarDeportistasPais(idPais);
        ViewBag.Deportista = bd.VerInfoPais(idPais);
        return View("DetallePais");
    }
   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
