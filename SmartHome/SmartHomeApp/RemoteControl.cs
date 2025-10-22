using System;
using System.Collections.Generic;

public class RemoteControl
{
    private ICommand[] _onCommands;
    private ICommand[] _offCommands;
    private Stack<ICommand> _history;

    public RemoteControl(int slots)
    {
        _onCommands = new ICommand[slots];
        _offCommands = new ICommand[slots];
        _history = new Stack<ICommand>();

        ICommand noCommand = new NoCommand();
        for (int i = 0; i < slots; i++)
        {
            _onCommands[i] = noCommand;
            _offCommands[i] = noCommand;
        }
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        _onCommands[slot] = onCommand;
        _offCommands[slot] = offCommand;
    }

    public void OnButtonPressed(int slot)
    {
        _onCommands[slot].Execute();
        _history.Push(_onCommands[slot]);
    }

    public void OffButtonPressed(int slot)
    {
        _offCommands[slot].Execute();
        _history.Push(_offCommands[slot]);
    }

    public void UndoButtonPressed()
    {
        if (_history.Count > 0)
            _history.Pop().Undo();
        else
            Console.WriteLine("Нет команд для отмены");
    }
}
