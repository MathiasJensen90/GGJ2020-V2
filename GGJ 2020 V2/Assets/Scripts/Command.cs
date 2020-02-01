using UnityEngine;

public abstract class Command 
{
    public bool IsDone;
    public abstract void ExecuteCommand(Player avatar);
}