using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value => _value;
}
