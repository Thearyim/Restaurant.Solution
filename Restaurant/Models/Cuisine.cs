using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Restaurant.Models
{
  public class Cuisine
  {
    private int _id;
    private string _name;
    private string _typeOfFood;

    public Cuisine(int CuisineId, string CuisineName, string CuisineTypeOfFood)
    {
      _id = CuisineId;
      _name = CuisineName;
      _typeOfFood = CuisineTypeOfFood;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetTypeOfFood()
    {
      return _typeOfFood;
    }

    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisine = new List<Cuisine> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Cuisine;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int CuisineId = rdr.GetInt(0);
        string CuisineName = rdr.GetString(1);
        string CuisineTypeOfFood = rdr.GetString(2);
        Cuisine newCuisine = new Cuisine(CuisineId, CuisineName, CuisineTypeOfFood);
        allCuisines.Add(newCuisine)
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCuisines;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO cuisines (name) VALUES (@name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameter.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
