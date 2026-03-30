using System;

// Responsável por guardar as informações dos itens

public class GeneratorStoreItem
{
    public decimal CurrentPrice => CalculatePrice();
    
    public PassiveGeneratorData Data { get; private set; }

    public event Action<GeneratorStoreItem> Purchased;

    public GeneratorStoreItem(PassiveGeneratorData data)
    {
        Data = data;
    }

    public bool TryPurchase(PointsWallet wallet)
    {
        decimal price = CurrentPrice;

        if (!wallet.TrySpendPoints(price)) return false;

        Purchased?.Invoke(this);
        return true;
    }

    private decimal CalculatePrice()
    {
        return Data.BasePrice;
    }
}
