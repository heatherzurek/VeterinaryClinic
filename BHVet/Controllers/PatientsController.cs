using Microsoft.AspNetCore.Mvc;
using BHVet.Models;
using System.Collections.Generic;
using System;

namespace BHVet.Controllers
{
  public class PatientsController : Controller
  {

    [HttpGet("/patients")]
    public ActionResult Index()
    {
      List<Patient> allPatients = Patient.GetAll();
      return View(allPatients);
    }

    [HttpGet("/patients/new")]
    public ActionResult New()
    {
     return View();
    }

    [HttpPost("/patients")]
    public ActionResult Create(string name, string visitReason, string type, DateTime dob)
    {
      Patient newPatient = new Patient(name, visitReason, type, dob);
      newPatient.Save();
      List<Patient> allPatients = Patient.GetAll();
      return View("Index", allPatients);
    }


    [HttpGet("/patients/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Patient selectedPatient = Patient.Find(id);
      List<Vet> patientVets = selectedPatient.GetVets();
      List<Vet> allVets = Vet.GetAll();
      model.Add("selectedPatient", selectedPatient);
      model.Add("patientVets", patientVets);
      model.Add("allVets", allVets);
      return View(model);
    }

    [HttpPost("/patients/{patientId}/categories/new")]
    public ActionResult AddVet(int patientId, int vetId)
    {
      Patient patient = Patient.Find(patientId);
      Vet vet = Vet.Find(vetId);
      patient.AddVet(vet);
      return RedirectToAction("Show",  new { id = patientId });
    }

    // [HttpPost("/patients/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Patient.ClearAll();
    //   return View();
    // }
    //
    // [HttpGet("/categories/{vetId}/patients/{patientId}/edit")]
    // public ActionResult Edit(int vetId, int patientId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Vet vet = Vet.Find(vetId);
    //   model.Add("vet", vet);
    //   Patient patient = Patient.Find(patientId);
    //   model.Add("patient", patient);
    //   return View(model);
    // }
    //
    // [HttpPost("/categories/{vetId}/patients/{patientId}")]
    // public ActionResult Update(int vetId, int patientId, string newDescription)
    // {
    //   Patient patient = Patient.Find(patientId);
    //   patient.Edit(newDescription);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Vet vet = Vet.Find(vetId);
    //   model.Add("category", category);
    //   model.Add("patient", patient);
    //   return View("Show", model);
    // }

  }
}
