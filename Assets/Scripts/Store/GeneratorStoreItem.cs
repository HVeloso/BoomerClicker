using System;
using System.Diagnostics;

// Responsável por guardar as informações dos itens
// Recalcula o preço a cada compra
// Tem a quantidade de itens comprados

public class GeneratorStoreItem
{
    public decimal CurrentPrice => CalculatePrice();
    
    public PassiveGeneratorData Data { get; private set; }

    private int _quantity = 0;

    public event Action<GeneratorStoreItem> Purchased;

    public GeneratorStoreItem(PassiveGeneratorData data)
    {
        Data = data;
        _quantity = 0;
    }
    
    public bool TryPurchase(PointsWallet wallet)
    {
        decimal price = CurrentPrice;

        if (!wallet.TrySpendPoints(price)) return false;

        Purchased?.Invoke(this);
        _quantity++;
        return true;
    }

    private decimal CalculatePrice()
    {
        decimal growthPrice = (decimal)MathF.Pow(Data.PriceGrowth, _quantity);
        decimal price = Data.BasePrice * growthPrice;

        decimal roundedPrice = price - (price % 1);
        UnityEngine.Debug.Log($"{Data.GeneratorName}: {price} | {roundedPrice}");
        return roundedPrice;
    }
}
