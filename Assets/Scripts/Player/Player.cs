using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Collector _collector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _collector.PickedUpMedKit += ReplenishHealth;
        _collector.PickedUpMoney += PutMoneyInWallet;
    }

    private void OnDisable()
    {
        _collector.PickedUpMedKit -= ReplenishHealth;
        _collector.PickedUpMoney -= PutMoneyInWallet;
    }

    private void ReplenishHealth(MedKit medKit) =>
        _health.Replenish(medKit.Value);

    private void PutMoneyInWallet(GoldCoin goldCoin) =>
        _wallet.AddMoney(goldCoin.Value);
}
