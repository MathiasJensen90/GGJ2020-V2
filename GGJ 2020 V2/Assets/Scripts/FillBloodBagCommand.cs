using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBloodBagCommand : Command
{
    public Bloodbank Bloodbank;

    public FillBloodBagCommand(Bloodbank bloodbank) {
        Bloodbank = bloodbank;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(Bloodbank.transform.root.position);

        if (avatar.Item != null) {
            var bloodbag = avatar.Item as Bloodbag;
            if (bloodbag != null) {
                Bloodbank.RefillBloodbag(bloodbag);
            }
        }

        IsDone = true;
    }
}
