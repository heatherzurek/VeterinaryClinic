using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BHVet.Models;

namespace BHVet.Controllers
{
  public class VetsController : Controller
  {

    [HttpGet("/vets")]
    public ActionResult Index()
    {
      List<Vet> allVets = Vet.GetAll();
      return View(allVets);
    }

    [HttpGet("/vets/new")]
    public ActionResult New()
    {
      return View();
    }
    //
    [HttpPost("/vets")]
    public ActionResult Create(string vetName, string vetSpecialty)
    {
      Vet newVet = new Vet(vetName, vetSpecialty);
      newVet.Save();
      List<Vet> allVets = Vet.GetAll();
      return View("Index", allVets);
    }

    [HttpGet("/vets/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vet selectedVet = Vet.Find(id);
        List<Patient> vetPatients = selectedVet.GetPatients();
        List<Patient> allPatients = Patient.GetAll();
        model.Add("vet", selectedVet);
        model.Add("vetPatients", vetPatients);
        model.Add("allPatients", allPatients);
        return View(model);
    }

    // [HttpPost("/vets/{vetId}/patients/new")]
    // public ActionResult AddPatient(int vetId, int itemId)
    // {
    //   Vet vet = Vet.Find(vetId);
    //   Patient item = Patient.Find(itemId);
    //   vet.AddPatient(item);
    //   return RedirectToAction("Show",  new { id = vetId });
    // }

  }
}
