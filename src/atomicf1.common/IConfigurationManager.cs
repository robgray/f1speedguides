namespace atomicf1.common
{
    public interface IConfigurationManager
    {
        string this[string key] { get; }
    }
}