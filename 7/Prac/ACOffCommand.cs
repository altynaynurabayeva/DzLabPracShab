public class ACOffCommand : ICommand
{
    private AirConditioner _ac;
    public ACOffCommand(AirConditioner ac) => _ac = ac;
    public void Execute() => _ac.Off();
    public void Undo() => _ac.On();
}
