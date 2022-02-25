namespace SimpleRPG.Game
{
    public class TestClass
    {
        public string Name { get; set; } = string.Empty;
        
        public bool DoSomething(string value)
        {
            Name = value;
            return true;
        }
    }
}
