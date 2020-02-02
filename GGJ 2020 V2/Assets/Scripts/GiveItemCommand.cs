using System.Collections;
using UnityEngine;

public class GiveItemCommand : Command
{
    public Patient _patient;

    public GiveItemCommand(Patient patient) {
        _patient = patient;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(_patient.transform.root.position);

        if (_patient.IsDead) {
            IsDone = true;
            yield break;
        }

        if (_patient.Blood > 90f) {
            _patient.Cure();
            IsDone = true;
            yield break;
        }

        var temp = _patient.Item;
        _patient.Item = avatar.Item;
        if (_patient.Item != null) {
            _patient.Item.transform.parent = _patient.MountingPoint.transform;
            _patient.Item.transform.localPosition = Vector2.zero;
            _patient.Item.transform.localRotation = Quaternion.identity;
        }

        avatar.Item = temp;
        if (avatar.Item)
        {
            avatar.Item.transform.parent = avatar.transform;
            //pickup position
            avatar.Item.transform.position = avatar.transform.position + new Vector3(0, -0.5f, 0);
        }
           

        IsDone = true;
    }
}