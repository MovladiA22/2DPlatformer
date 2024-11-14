using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Money> PickedUpMoney;
    public event Action<MedKit> PickedUpMedKit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ISelected selected))
        {
            if (selected is Money money)
                PickedUpMoney?.Invoke(money);

            if (selected is MedKit medKit)
                PickedUpMedKit?.Invoke(medKit);

            Destroy(collision.gameObject);
        }
    }
}
