public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Metadata Metadata { get; set; }

    public Feature[] Features { get; set; }

    public double[] Bbox { get; set; }
}

public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
}


public class Feature
{
    public string Id { get; set; }
    public string Type { get; set; }
    public Property Properties { get; set; }
    public Geometry Geometry { get; set; }
}

public class Property
{
    public double Mag { get; set; }
    public string Place { get; set; }
    public long Time { get; set; }
    public long Updated { get; set; }
    public string Tz { get; set; }
    public string Url { get; set; }
    public string Detail { get; set; }
    public int? Felt { get; set; }
    public double? Cdi { get; set; }
    public double? Mmi { get; set; }
    public string Alert { get; set; }
    public string Status { get; set; }
    public int Tsunami { get; set; }
    public int Sig { get; set; }
    public string Net { get; set; }
    public string Code { get; set; }
    public string Ids { get; set; }
    public string Sources { get; set; }
    public string Types { get; set; }
    public int? Nst { get; set; }
    public double? Dmin { get; set; }
    public double? Rms { get; set; }
    public object Gap { get; set; }
    public string MagType { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public double[] Coordinates { get; set; }
}