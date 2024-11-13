using UnityEngine;

public class MedKit : MonoBehaviour, ISelected
{
    [field: SerializeField] public int Value { get; private set; }
}
