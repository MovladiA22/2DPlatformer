using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value => _value;
}
