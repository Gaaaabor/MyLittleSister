public class RestartCommand : CommandBase
{
    public RestartCommand()
    {
        CommandText = "restart";
        ParameterCount = 0;
    }

    public override bool Execute(string[] parameters)
    {
        if (!base.Execute(parameters))
        {
            return false;
        }

        PlayerController.Instance.Die();

        return true;
    }
}