using System.Collections;

public class TakeItemCommand : Command
{
    private Item _item;


    public TakeItemCommand(Item item) {
        _item = item;
    }

    public override IEnumerator ExecuteCommand(Player avatar)
    {
        return null;
    }
}