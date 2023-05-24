public record Coordinate(double Latitude, double Longtitude)
{
    //records are immutable by default (init in properies) can be changed
    //records compare by value("a"=="a"=>true) ! 
    //they have different places in the heap but it doesn't matter
    public static bool TryParse(string input, out Coordinate? coordinate)
    {
        coordinate = default;
        var splitArray = input.Split(',',2);
        if(splitArray.Length != 2) return false;
        if(!double.TryParse(splitArray[0], out var latitude)) return false;
        if(!double.TryParse(splitArray[1], out var longtitude)) return false;
        coordinate = new(latitude, longtitude);
        return true;
    }

    public static async ValueTask<Coordinate?> BindAsync(HttpContext context,
        ParameterInfo parameter)
    {
        return await Task<Coordinate?>.Run(()=>
        {
            var input = context.GetRouteValue(parameter.Name!) as string ?? string.Empty;
            TryParse(input, out var coordinate);
            return coordinate;
        });
        
    }
}