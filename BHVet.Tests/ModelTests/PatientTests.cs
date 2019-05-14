using Microsoft.VisualStudio.TestTools.UnitTesting;
using BHVet.Models;
using System.Collections.Generic;
using System;

namespace BHVet.Tests
{
  [TestClass]
  public class PatientTest : IDisposable
  {

    public void Dispose()
    {
      Patient.ClearAll();
      Vet.ClearAll();
    }

    public PatientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bhvet_test;Convert Zero Datetime=True;";
    }

    [TestMethod]
    public void PatientConstructor_CreatesInstanceOfPatient_Patient()
    {
      DateTime dob = new DateTime(1986, 12, 5);
      Patient newPatient = new Patient("Larry", "hernia", "bird", dob);
      Assert.AreEqual(typeof(Patient), newPatient.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_PatientList()
    {
      //Arrange
      List<Patient> newList = new List<Patient> { };

      //Act
      List<Patient> result = Patient.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsPatients_PatientList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient newPatient1 = new Patient("Larry", "hernia", "bird", dob);
      newPatient1.Save();
      Patient newPatient2 = new Patient("Barry", "Chernia", "Tird", dob);
      newPatient2.Save();
      List<Patient> newList = new List<Patient> { newPatient1, newPatient2 };

      //Act
      List<Patient> result = Patient.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectPatientFromDatabase_Patient()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();

      //Act
      Patient foundPatient = Patient.Find(testPatient.Id);

      //Assert
      Assert.AreEqual(testPatient, foundPatient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Patient()
    {
      // Arrange, Act
      DateTime dob = new DateTime(1986, 12, 5);
      Patient firstPatient = new Patient("Barry", "Chernia", "Tird", dob);
      Patient secondPatient = new Patient("Barry", "Chernia", "Tird", dob);

      // Assert
      Assert.AreEqual(firstPatient, secondPatient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_PatientList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);

      //Act
      testPatient.Save();
      List<Patient> result = Patient.GetAll();
      List<Patient> testList = new List<Patient>{testPatient};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();

      //Act
      Patient savedPatient = Patient.GetAll()[0];

      int result = savedPatient.Id;
      int testId = testPatient.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetVets_ReturnsAllPatientVets_VetList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();
      Vet testVet1 = new Vet("Doctor Phil", "Headstuff");
      testVet1.Save();
      Vet testVet2 = new Vet("Phoctor Dil", "Poopstuff");
      testVet2.Save();

      //Act
      testPatient.AddVet(testVet1);
      List<Vet> result = testPatient.GetVets();
      List<Vet> testList = new List<Vet> {testVet1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddVet_AddsVetToPatient_VetList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();

      //Act
      testPatient.AddVet(testVet);

      List<Vet> result = testPatient.GetVets();
      List<Vet> testList = new List<Vet>{testVet};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void Delete_DeletesPatientAssociationsFromDatabase_PatientList()
    // {
    //   //Arrange
    //   Vet testVet = new Vet("Doctor Phil", "Headstuff");
    //   testVet.Save();
    // DateTime dob = new DateTime(1986, 12, 5);
    //   Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
    //   testPatient.Save();
    //
    //   //Act
    //   testPatient.AddVet(testVet);
    //   testPatient.Delete();
    //   List<Patient> resultVetPatients = testVet.GetPatients();
    //   List<Patient> testVetPatients = new List<Patient> {};
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testVetPatients, resultVetPatients);
    // }

  }
}
