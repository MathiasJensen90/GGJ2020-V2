using System.Collections;
using UnityEngine;

public abstract class Command 
{
    public bool IsDone;
    public abstract IEnumerator ExecuteCommand(Player avatar);
}