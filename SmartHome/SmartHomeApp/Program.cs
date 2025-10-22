using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        RemoteControl remote = new RemoteControl(3);

        Light livingRoomLight = new Light();
        TV tv = new TV();
        AirConditioner ac = new AirConditioner();

        remote.SetCommand(0, new LightOnCommand(livingRoomLight), new LightOffCommand(livingRoomLight));
        remote.SetCommand(1, new TVOnCommand(tv), new TVOffCommand(tv));
        remote.SetCommand(2, new ACOnCommand(ac), new ACOffCommand(ac));

        Console.WriteLine("=== Управление отдельными устройствами ===");
        remote.OnButtonPressed(0);   
        remote.OffButtonPressed(0);  
        remote.UndoButtonPressed();  

        Console.WriteLine("\n=== Макрокоманда ===");
        var macro = new MacroCommand(new List<ICommand> {
            new LightOnCommand(livingRoomLight),
            new TVOnCommand(tv),
            new ACOnCommand(ac)
        });
        macro.Execute();  
        macro.Undo();     
    }
}
