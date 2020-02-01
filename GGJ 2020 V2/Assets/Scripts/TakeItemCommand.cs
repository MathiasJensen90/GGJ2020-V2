using System.Collections;
using UnityEngine;

public class TakeItemCommand : Command
{
    private Item _item;


    public TakeItemCommand(Item item) {
        _item = item;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        yield return avatar.Move(_item.transform.position);

        if (avatar.Item == null)
        {
            avatar.Item = _item;
        }

        IsDone = true;
    }
}