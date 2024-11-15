using UnityEngine;

public class GoldCoin : MonoBehaviour, ISelected
{
    [field: SerializeField] public int Value { get; private set; }
}
