using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money;

    public void AddMoney(int money) =>
        _money += money;
}
