using System.Collections;

public class GiveItemCommand : Command
{
    public Patient _patient;

    public GiveItemCommand(Patient patient) {
        _patient = patient;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(_patient.transform.position);

        if (avatar.Item != null) {
            _patient.Item = avatar.Item;
            avatar.Item = null;
        }

        IsDone = true;
    }
}