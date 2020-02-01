public class TakeItemCommand : Command
{
    private Item _item;

    public bool IsDone;

    public TakeItemCommand(Item item) {
        _item = item;
    }

    public override void ExecuteCommand(Player avatar)
    {
    }
}