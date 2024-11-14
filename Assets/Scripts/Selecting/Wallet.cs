using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public void AddMoney(Money money) =>
        _money += money.Value;
}
