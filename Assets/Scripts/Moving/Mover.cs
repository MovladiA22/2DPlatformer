using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public event Action<bool> Moved;

    protected void DeclareEventMoved(bool isMoved)
    {
        Moved?.Invoke(isMoved);
    }
}