using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Collector _collector;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _collector.PickedUpMedKit += _health.Replenish;
        _collector.PickedUpMoney += _wallet.AddMoney;
    }

    private void OnDisable()
    {
        _collector.PickedUpMedKit -= _health.Replenish;
        _collector.PickedUpMoney -= _wallet.AddMoney;
    }
}
