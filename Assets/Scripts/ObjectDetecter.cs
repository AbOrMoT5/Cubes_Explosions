using System;
using UnityEngine;

public class ObjectDetecter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private int _activeMouseButtonNumber = 0;
    

    public event Action<Transform> ObjectClicked;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(_activeMouseButtonNumber))
        {
            return;
        }

        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, _maxDistance))
        {
            ObjectClicked?.Invoke(hit.transform);
        }
    }
}
