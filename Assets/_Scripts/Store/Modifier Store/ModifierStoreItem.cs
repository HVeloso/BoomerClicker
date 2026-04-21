using System;

// Responsável por guardar as informações dos itens
// Recalcula o preço a cada compra
// Tem a quantidade de itens comprados

public class ModifierStoreItem
{
    public decimal CurrentPrice => Data.Price;
    public ModifierData Data { get; private set; }

    public event Action<ModifierStoreItem> Purchased;

    public ModifierStoreItem(ModifierData data)
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
}
