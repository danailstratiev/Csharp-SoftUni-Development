namespace P10.ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName(string name);

    }
}
