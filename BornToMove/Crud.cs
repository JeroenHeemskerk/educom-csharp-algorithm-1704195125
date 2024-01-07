using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Crud : IDisposable
{
    // Properties
    private string connectionString = "Server=localhost;Database=Born2Move;User ID=nicole;Password=4cbfBC&~*4mmQmu;Pooling=true;";
    private MySqlConnection connection = null;
    private MySqlCommand sqlCommand;
    private bool disposed = false;

    // Constructor
    public Crud()
    {
        ConnectDatabase();
    }

    // Dispose method
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Dispose implementation
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            // Connection sluiten
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

            disposed = true;
        }
    }

    // Connectie maken met de database
    private void ConnectDatabase()
    {
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    // SQL-commando voorbereiden en binden
    private void PrepareAndBind(string sql, Dictionary<string, object> parameters)
    {
        sqlCommand = new MySqlCommand(sql, connection);
        sqlCommand.CommandType = System.Data.CommandType.Text;

        foreach (var parameter in parameters)
        {
            sqlCommand.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
        }
    }

    // Nieuwe rij toevoegen aan de database
    public int CreateRow(string sql, Dictionary<string, object> parameters)
    {
        PrepareAndBind(sql, parameters);

        sqlCommand.ExecuteNonQuery();

        // Return het laatst ingevoegde ID
        sqlCommand.CommandText = "SELECT LAST_INSERT_ID()";
        return Convert.ToInt32(sqlCommand.ExecuteScalar());
    }

    // Eén rij ophalen uit de database
    public dynamic ReadOneRow(string sql, Dictionary<string, object> parameters)
    {
        PrepareAndBind(sql, parameters);

        using (MySqlDataReader reader = sqlCommand.ExecuteReader())
        {
            if (reader.Read())
            {
                // Object retourneren
                var result = new System.Dynamic.ExpandoObject();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ((IDictionary<string, object>)result).Add(reader.GetName(i), reader[i]);
                }
                return result;
            }
            return null;
        }
    }

    // Meerdere rijen ophalen uit de database
    public List<dynamic> ReadManyRows(string sql, Dictionary<string, object> parameters)
    {
        PrepareAndBind(sql, parameters);

        List<dynamic> resultList = new List<dynamic>();

        using (MySqlDataReader reader = sqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                var result = new System.Dynamic.ExpandoObject();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ((IDictionary<string, object>)result).Add(reader.GetName(i), reader[i]);
                }
                resultList.Add(result);
            }
        }

        return resultList;
    }

    // Rij bijwerken in de database
    public void UpdateRow(string sql, Dictionary<string, object> parameters)
    {
        PrepareAndBind(sql, parameters);
        sqlCommand.ExecuteNonQuery();
    }

    // Rij verwijderen uit de database
    public void DeleteRow(string sql, Dictionary<string, object> parameters)
    {
        PrepareAndBind(sql, parameters);
        sqlCommand.ExecuteNonQuery();
    }
}
