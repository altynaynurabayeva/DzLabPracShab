public class ACOnCommand : ICommand
{
    private AirConditioner _ac;
    public ACOnCommand(AirConditioner ac) => _ac = ac;
    public void Execute() => _ac.On();
    public void Undo() => _ac.Off();
}
