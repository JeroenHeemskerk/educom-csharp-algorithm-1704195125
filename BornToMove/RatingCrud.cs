using System;
using System.Collections.Generic;

public class RatingCrud
{
    private readonly Crud _crud;

    public RatingCrud (Crud crud)
    {
        _crud = crud;
    }

    //Rating maken
    public void CreateRating(int id, int review, int intensity)
    {
        string sql = "INSERT INTO rating (move_id, review, intensity) VALUES (@Move_id, @Review, @Intensity)";
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Move_id", id },
            { "Review", review },
            { "Intensity", intensity }
        };

        _crud.CreateRow(sql, parameters);
    }
}