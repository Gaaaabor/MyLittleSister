namespace Assets._Scripts.Commands
{
    public abstract class CommandBase
    {
        public string CommandText;
        public int ParameterCount;

        public abstract void Execute(string[] parameters);
    }
}
