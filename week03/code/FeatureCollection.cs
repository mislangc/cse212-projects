public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public Feature[] Features { get; set; }

    public class Feature
    {
        public string Type { get; set; }
        public Property Properties { get; set; }
    }

    public class Property
    {
        public double Mag { get; set; }
        public string Place { get; set; }
    }
}