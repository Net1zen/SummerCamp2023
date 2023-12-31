﻿using ConversorWeb.Models;
using ConversorWeb.Servicios;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalConsola;
using System.Diagnostics;

namespace ConversorWeb.Controllers
{
    // 1-Crear IRepositorio
    // 2-Crear Repositorio
    // 3-Agregar AddScoped<IRepositorio,Repositorio>
    // 4-Modificar constructor de HomeController para incluir IRepositorio
    // 5-Crear campo repositorio en HomeController
    // 6-Eliminar dependencia de proyecto lectura JSON Monedas
    // 7-Modificar metodo ObtenerMonedas en Repositorio para llamar al metodo libreria JSON
    // 8-En el metodo Index() llamar a repositorio.ObtenerMonedas, guardar en lista
    // 9-Pasar lista a la vista en return View(lista)
    // 10-Modificar vista @model IEnumerable<Moneda>
    // 11-Mostrar lista de monedas en la vista con un @foreach
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioMonedas repositorioMonedas;

        public HomeController(ILogger<HomeController> logger, IRepositorioMonedas repositorioMonedas)
        {
            _logger = logger;
            this.repositorioMonedas = repositorioMonedas;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Estoy en el index");
            IEnumerable<Models.Moneda> lista = repositorioMonedas.ObtenerMonedas();

            ViewBag.saludo = "Hola mundo desde C#";
            ViewBag.fecha = DateTime.Now;

            //ViewBag.Euro = new Moneda
            //{
            //    Codigo = "EUR",
            //    Nombre = "Euro",
            //    ValorEnDolares = 1.113
            //};

            //Conversor conversor = new Conversor();
            //foreach (var moneda in conversor.Monedas)
            //{

            //    ViewBag.Moneda += $"\t{moneda.Codigo} - {moneda.Nombre}";
            //}

            //var serviciomonedas = new ServicioMonedas();
            //var serviciomonedas = new ServicioCriptoMonedas();
            //IServicioMoneda servicioMoneda = new ServicioMoneda();
            //var lista = servicioMoneda.ObtenerMonedas();

            // Mostrar algo que va desde controller a la vista
            return View(lista); // Indicar explicitamente lo que queremos que llegue a la vista
        }

        public IActionResult Privacy()
        {
            throw new Exception();
            //IServicioMoneda servicioMoneda = new ServicioMoneda();
            //var lista = servicioMoneda.ObtenerMonedas();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}