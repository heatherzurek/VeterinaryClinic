using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BHVet.Models
{
  public class Vet
  {
    public int Id { get; set;}
    public string Name { get; set; }
    public string Specialty { get; set; }

    public Vet(string name, string speciality, int id = 0)
    {
      Name = name;
      Specialty = speciality;
      Id = id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO vets (name) VALUES (@name);";
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

    public static Vet Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM vets WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int VetId = 0;
      string VetName = "";
      string VetSpecialty = "";
      while(rdr.Read())
      {
        VetId = rdr.GetInt32(0);
        VetName = rdr.GetString(1);
        VetSpecialty = rdr.GetString(2);
      }
      Vet newVet = new Vet(VetName, VetSpecialty, VetId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newVet;
    }

    // public void AddPatient(Patient newPatient)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   var cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO appts (vet_id, patient_id) VALUES (@VetId, @PatientId);";
    //   MySqlParameter vet_id = new MySqlParameter();
    //   vet_id.ParameterName = "@VetId";
    //   vet_id.Value = Id;
    //   cmd.Parameters.Add(vet_id);
    //   MySqlParameter patient_id = new MySqlParameter();
    //   patient_id.ParameterName = "@PatientId";
    //   patient_id.Value = newPatient.Id;
    //   cmd.Parameters.Add(patient_id);
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    public static List<Vet> GetAll()
    {
      List<Vet> allVets = new List<Vet> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM vets;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int VetId = rdr.GetInt32(0);
        string VetName = rdr.GetString(1);
        string VetSpecialty = rdr.GetString(2);
        Vet newVet = new Vet(VetName, VetSpecialty, VetId);
        allVets.Add(newVet);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allVets;
    }




    // public List<Patient> GetPatients()
    // {
    //     MySqlConnection conn = DB.Connection();
    //     conn.Open();
    //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //     cmd.CommandText = @"SELECT patients.* FROM vets
    //         JOIN appts ON (vets.id = appts.vets_id)
    //         JOIN patients ON (appts.patient_id = patients.id)
    //         WHERE vets.id = @VetId;";
    //     MySqlParameter vetIdParameter = new MySqlParameter();
    //     vetIdParameter.ParameterName = "@VetId";
    //     vetIdParameter.Value = Id;
    //     cmd.Parameters.Add(vetIdParameter);
    //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //     List<Patient> patients = new List<Patient>{};
    //     while(rdr.Read())
    //     {
    //       int patientId = rdr.GetInt32(0);
    //       string patientName = rdr.GetString(1);
    //       string patientVisit_Reason = rdr.GetString(2);
    //       string patientType = rdr.GetString(3);
    //       DateTime patientDob = rdr.GetDateTime(4);
    //       Patient newPatient = new Patient(patientId, patientName, patientVisit_Reason, patientType, patientDob);
    //       patients.Add(newPatient);
    //     }
    //     conn.Close();
    //     if (conn != null)
    //     {
    //       conn.Dispose();
    //     }
    //     return patients;
    // }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM vets;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherVet)
    {
      if (!(otherVet is Vet))
      {
        return false;
      }
      else
      {
        Vet newVet = (Vet) otherVet;
        bool idEquality = this.Id.Equals(newVet.Id);
        bool nameEquality = this.Name.Equals(newVet.Name);
        return (idEquality && nameEquality);
      }
    }
  }
}
