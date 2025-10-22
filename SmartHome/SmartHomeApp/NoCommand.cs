public class NoCommand : ICommand
{
    public void Execute() => System.Console.WriteLine("Команда не назначена");
    public void Undo() => System.Console.WriteLine("Команда не назначена");
}
