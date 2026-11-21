using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _activeMouseButtonNumber = 0;

    public event Action<Vector3> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_activeMouseButtonNumber))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
