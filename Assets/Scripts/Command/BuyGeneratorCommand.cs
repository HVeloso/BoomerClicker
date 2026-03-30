// Responsável pela ação de comprar

public class BuyGeneratorCommand
{
    protected readonly PointsWallet _playerWallet;
    protected readonly GeneratorStoreItem _storeItem;

    public BuyGeneratorCommand(PointsWallet playerWallet, GeneratorStoreItem storeItem)
    {
        _playerWallet = playerWallet;
        _storeItem = storeItem;
    }

    public bool Execute()
    {
        return _storeItem.TryPurchase(_playerWallet);
    }
}
