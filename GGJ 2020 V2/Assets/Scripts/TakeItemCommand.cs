using System.Collections;
using UnityEngine;

public class TakeItemCommand : Command
{
    private Item _item;
    private TraySpot _traySpot;

    public TakeItemCommand(TraySpot traySpot) {
        _traySpot = traySpot;

    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(_traySpot.transform.root.position);

        if (avatar.Item == null && _traySpot.item !=null)
        {
            avatar.Item = _traySpot.item;
            avatar.Item.transform.parent = avatar.transform;
            //pickup position
            avatar.Item.transform.position = avatar.transform.position + new Vector3(0,-0.5f,0);
            _traySpot.item = null;
        }

        IsDone = true;
    }
}