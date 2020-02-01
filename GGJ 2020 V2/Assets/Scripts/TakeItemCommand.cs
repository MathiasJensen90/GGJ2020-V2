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
        yield return avatar.Move(_traySpot.transform.position);

        if (avatar.Item == null)
        {
            avatar.Item = _traySpot.item;
            avatar.Item.transform.parent = avatar.transform;
            _traySpot.item = null;
        }

        IsDone = true;
    }
}