using System;

// Responsável por guardar as informações dos itens
// Recalcula o preço a cada compra
// Tem a quantidade de itens comprados

public class GeneratorStoreItem
{
    public decimal CurrentPrice => CalculatePrice();
    
    public PassiveGeneratorData Data { get; private set; }
    public int BoughtQuantity { get; private set; }

    public event Action<GeneratorStoreItem> Purchased;

    public GeneratorStoreItem(PassiveGeneratorData data)
    {
        Data = data;
        BoughtQuantity = 0;
    }
    
    public bool TryPurchase(PointsWallet wallet)
    {
        decimal price = CurrentPrice;

        if (!wallet.TrySpendPoints(price)) return false;

        Purchased?.Invoke(this);
        BoughtQuantity++;
        return true;
    }

    private decimal CalculatePrice()
    {
        decimal growthPrice = (decimal)MathF.Pow(Data.PriceGrowth, BoughtQuantity);
        decimal price = Data.BasePrice * growthPrice;

        decimal remainder = price % 1;
        decimal roundedPrice = price - remainder;

        return roundedPrice;
    }
}
