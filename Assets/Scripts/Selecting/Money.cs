using UnityEngine;

public class Money : MonoBehaviour, ISelected
{
    [field: SerializeField] public int Value { get; private set; }
}
