// Responsável pela ação de comprar

public class BuyModifierCommand
{
    protected readonly PointsWallet _playerWallet;
    protected readonly ModifierStoreItem _storeItem;

    public BuyModifierCommand(PointsWallet playerWallet, ModifierStoreItem storeItem)
    {
        _playerWallet = playerWallet;
        _storeItem = storeItem;
    }

    public bool Execute()
    {
        return _storeItem.TryPurchase(_playerWallet);
    }
}
