namespace s21_d03_Sources
{
    public interface IConfigurationSource
    {
        Dictionary<string, string> GetParams();
        int Priority { get; }
    }
}