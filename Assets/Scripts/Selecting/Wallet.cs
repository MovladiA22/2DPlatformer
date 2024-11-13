using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private int _money;

    private void OnEnable()
    {
        _collector.PickedUpMoney += AddMoney;
    }

    private void OnDisable()
    {
        _collector.PickedUpMoney -= AddMoney;
    }

    public void AddMoney(Money money) =>
        _money += money.Value;
}
