using UnityEngine;

public class Health : MonoBehaviour, ISelected
{
    [field: SerializeField] public int Value { get; private set; }
}
