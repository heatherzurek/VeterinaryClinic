using Microsoft.VisualStudio.TestTools.UnitTesting;
using BHVet.Models;
using System.Collections.Generic;
using System;

namespace BHVet.Tests
{
  [TestClass]
  public class VetTest : IDisposable
  {

    public VetTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bhvet_test;Convert Zero Datetime=True";
    }

    public void Dispose()
    {
      Vet.ClearAll();
      Patient.ClearAll();
    }

    [TestMethod]
    public void VetConstructor_CreatesInstanceOfVet_Vet()
    {
      Vet newVet = new Vet("Doctor Bill", "Buttstuff");
      Assert.AreEqual(typeof(Vet), newVet.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAllVetObjects_VetList()
    {
      //Arrange
      Vet newVet1 = new Vet("Doctor Bill", "Buttstuff");
      newVet1.Save();
      Vet newVet2 = new Vet("Doctor Phil", "Headstuff");
      newVet2.Save();
      List<Vet> newList = new List<Vet> { newVet1, newVet2 };

      //Act
      List<Vet> result = Vet.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsVetInDatabase_Vet()
    {
      //Arrange
      Vet testVet = new Vet("Doctor Bill", "Buttstuff");
      testVet.Save();

      //Act
      Vet foundVet = Vet.Find(testVet.Id);

      //Assert
      Assert.AreEqual(testVet, foundVet);
    }

    [TestMethod]
    public void GetPatients_ReturnsEmptyPatientList_PatientList()
    {
      //Arrange
      string name = "Work";
      Vet newVet = new Vet("Doctor Bill", "Buttstuff");
      List<Patient> newList = new List<Patient> { };

      //Act
      List<Patient> result = newVet.GetPatients();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_VetsEmptyAtFirst_List()
    {
      //Arrange, Act
      int result = Vet.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Vet()
    {
      //Arrange, Act
      Vet firstVet = new Vet("Doctor Bill", "Buttstuff");
      Vet secondVet = new Vet("Doctor Bill", "Buttstuff");

      //Assert
      Assert.AreEqual(firstVet, secondVet);
    }

    [TestMethod]
    public void Save_SavesVetToDatabase_VetList()
    {
      //Arrange
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();

      //Act
      List<Vet> result = Vet.GetAll();
      List<Vet> testList = new List<Vet>{testVet};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToVet_Id()
    {
      //Arrange
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();

      //Act
      Vet savedVet = Vet.GetAll()[0];

      int result = savedVet.Id;
      int testId = testVet.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void GetPatients_RetrievesAllPatientsWithVet_PatientList()
    {
      //Arrange, Act
      DateTime dob = new DateTime(1986, 12, 5);

      Console.WriteLine(dob);

      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();
      Patient firstPatient = new Patient("Larry", "hernia", "bird", dob);
      firstPatient.Save();
      testVet.AddPatient(firstPatient);
      Patient secondPatient = new Patient("barry", "hernia", "bird", dob);
      secondPatient.Save();
      testVet.AddPatient(secondPatient);
      List<Patient> testPatientList = new List<Patient> {firstPatient, secondPatient};
      List<Patient> resultPatientList = testVet.GetPatients();

      //Assert
      CollectionAssert.AreEqual(testPatientList, resultPatientList);
    }

    [TestMethod]
    public void Delete_DeletesVetAssociationsFromDatabase_VetList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();
      string testName = "Home stuff";
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();

      //Act
      testVet.AddPatient(testPatient);
      testVet.Delete();
      List<Vet> resultPatientVets = testPatient.GetVets();
      List<Vet> testPatientVets = new List<Vet> {};

      //Assert
      CollectionAssert.AreEqual(testPatientVets, resultPatientVets);
    }

    [TestMethod]
    public void Test_AddPatient_AddsPatientToVet()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();
      Patient testPatient = new Patient("Larry", "hernia", "bird", dob);
      testPatient.Save();
      Patient testPatient2 = new Patient("Jim", "ugly", "cow", dob);
      testPatient2.Save();

      //Act
      testVet.AddPatient(testPatient);
      testVet.AddPatient(testPatient2);
      List<Patient> result = testVet.GetPatients();
      List<Patient> testList = new List<Patient>{testPatient, testPatient2};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetPatients_ReturnsAllVetPatients_PatientList()
    {
      //Arrange
      DateTime dob = new DateTime(1986, 12, 5);
      Vet testVet = new Vet("Doctor Phil", "Headstuff");
      testVet.Save();
      Patient testPatient1 = new Patient("Larry", "hernia", "bird", dob);
      testPatient1.Save();
      Patient testPatient2 = new Patient("Jim", "ugly", "cow", dob);
      testPatient2.Save();

      //Act
      testVet.AddPatient(testPatient1);
      List<Patient> savedPatients = testVet.GetPatients();
      List<Patient> testList = new List<Patient> {testPatient1};

      //Assert
      CollectionAssert.AreEqual(testList, savedPatients);
    }


  }
}
