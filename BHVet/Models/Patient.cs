using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BHVet.Models
{
  public class Patient
  {
    public int Id { get; set;}
    public string Name { get; set; }
    public string VisitReason { get; set; }
    public string Type { get; set; }
    public DateTime Dob { get; set; }

    public Patient(string name, string visitReason, string type, DateTime dob, int id = 0)
    {
      Id = id;
      Name = name;
      VisitReason = visitReason;
      Type = type;
      Dob = dob;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM patients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherPatient)
    {
      if (!(otherPatient is Patient))
      {
        return false;
      }
      else
      {
        Patient newPatient = (Patient) otherPatient;
        bool idEquality = this.Id == newPatient.Id;
        bool nameEquality = this.Name == newPatient.Name;
        return (idEquality && nameEquality);
      }
    }

    public static List<Patient> GetAll()
    {
      List<Patient> allPatients = new List<Patient> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM patients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int patientId = rdr.GetInt32(0);
        string patientName = rdr.GetString(1);
        string patientVisitReason = rdr.GetString(2);
        string patientType = rdr.GetString(3);
        DateTime patientDob = rdr.GetDateTime(4);
        Patient newPatient = new Patient(patientName, patientVisitReason, patientType, patientDob, patientId);
        allPatients.Add(newPatient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPatients;
    }

    public static Patient Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM patients WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int patientId = 0;
      string patientName = "";
      string patientVisitReason = "";
      string patientType = "";
      DateTime patientDob = new DateTime(2000, 11, 11);
      while(rdr.Read())
      {
        patientId = rdr.GetInt32(0);
        patientName = rdr.GetString(1);
        patientVisitReason = rdr.GetString(2);
        patientType = rdr.GetString(3);
        patientDob = rdr.GetDateTime(4);
      }
      Patient newPatient = new Patient(patientName, patientVisitReason, patientType, patientDob, patientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newPatient;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO patients (name) VALUES (@name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this.Name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Vet> GetVets()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT vets.* FROM patients
      JOIN appts ON (patients.id = appts.patient_id)
      JOIN vets ON (appts.vet_id = vets.id)
      WHERE patients.id = @PatientId;";
      MySqlParameter patientIdParameter = new MySqlParameter();
      patientIdParameter.ParameterName = "@PatientId";
      patientIdParameter.Value = Id;
      cmd.Parameters.Add(patientIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Vet> vets = new List<Vet>{};
      while(rdr.Read())
      {
        int vetId = rdr.GetInt32(0);
        string vetName = rdr.GetString(1);
        string vetSpecialty = rdr.GetString(2);
        Vet newVet = new Vet(vetName, vetSpecialty, vetId);
        vets.Add(newVet);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return vets;
    }

  }
}
