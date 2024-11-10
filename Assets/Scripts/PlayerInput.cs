using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public event Action<float> MovedHorizontally;
    public event Action PressedSpace;

    private void Update()
    {
        MovedHorizontally?.Invoke(Input.GetAxis(Horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
            PressedSpace?.Invoke();
    }
}
