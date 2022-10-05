namespace MinimalAPI_Basics
{
    public class Service : IService
    {
        public List<string> GetNames()
        {
            return new List<string>
            {
                "Zeke",
                "Timothy",
                "Luna",
                "Billy",
                "Cloud"
            };
        }
    }
}
