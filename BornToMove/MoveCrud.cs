using System;
using System.Collections.Generic;

public class MoveCrud
{
    // Constanten
    private const int RESULT_OK = 0;
    private const int RESULT_MOVE_ALREADY_EXIST = -1;

    // Dependency Injection
    private readonly Crud _crud;

    // Constructor voor Dependency Injection
    public MoveCrud(Crud crud)
    {
        _crud = crud;
    }

    // Checken of de move al bestaat
    public Dictionary<string, object> ReadMoveByName(string name)
    {
        string sql = "SELECT * FROM move WHERE name = @Name";
        Dictionary<string, object> parameters = new Dictionary<string, object> { { "Name", name } };

        dynamic checkMoveExist = _crud.ReadOneRow(sql, parameters);

        return checkMoveExist;
    }


    //Move toevoegen
    public void CreateMove(string name, string description, int sweatRate)
    {
        string sql = "INSERT INTO move (name, description, sweat_rate) VALUES (@Name, @Description, @Sweat_rate)";
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Name", name },
            { "Description", description },
            { "Sweat_rate", sweatRate }
        };

        _crud.CreateRow(sql, parameters);
    }

    //Lijst van moves weergeven
    public List<dynamic> ReadAllMoves()
    {
        string sql = "SELECT id, name, sweat_rate FROM move";
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        return _crud.ReadManyRows(sql, parameters);
    }

    //Move weergeven
    public Dictionary<string, object> ReadMoveById(int moveId)
    {
        string sql = "SELECT * FROM move WHERE id = @Id";
        Dictionary<string, object> parameters = new Dictionary<string, object> { { "Id", moveId } };
        var result = _crud.ReadOneRow(sql, parameters) as IDictionary<string, object>;

        if (result != null)
        {
            return new Dictionary<string, object>(result);
        }

        return null;
    }

    //Random move weergeven
    public Dictionary<string, object> ReadRandomMove()
    {
        string sql = "SELECT * FROM move ORDER BY RAND() LIMIT 1";
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        var result = _crud.ReadOneRow(sql, parameters) as IDictionary<string, object>;

        if (result != null)
        {
            return new Dictionary<string, object>(result);
        }

        return null; // Return null als er geen resultaten zijn gevonden.
    }
}