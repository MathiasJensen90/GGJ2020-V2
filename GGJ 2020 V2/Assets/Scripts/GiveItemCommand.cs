﻿using System.Collections;

public class GiveItemCommand : Command
{
    public Patient _patient;

    public GiveItemCommand(Patient patient) {
        _patient = patient;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(_patient.transform.root.position);

        var temp = _patient.Item;
        _patient.Item = avatar.Item;
        if (_patient.Item)
            _patient.Item.transform.parent = _patient.transform;
        avatar.Item = temp;
        if (avatar.Item)
            avatar.Item.transform.parent = avatar.transform;

        IsDone = true;
    }
}