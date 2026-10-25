using System.Collections.Generic;
using UnityEngine;

public class Exploadeable_object : MonoBehaviour
{
    [SerializeField] private ObjectDetecter _objectDetecter;
    [SerializeField] private int _multiplyChance = 100;

    private int _lowRandomBorder = 0;
    private int _highRandomBorder = 100;
    private int _maxMultiply = 6;
    private float _explosionRadius = 10f;
    private float _explosionForce = 500f;

    private void OnEnable()
    {
        _objectDetecter.ObjectClicked += CheckTransform;
    }

    private void OnDisable()
    {
        _objectDetecter.ObjectClicked -= CheckTransform;
    }

    private Rigidbody CreateCube()
    {
        GameObject cube = Instantiate(gameObject);
        cube.name = "Cube";
        cube.transform.localScale /= 2;
        cube.transform.position = transform.position + Random.insideUnitSphere * 0.2f;
        cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        cube.GetComponent<Exploadeable_object>().SetMultiplyChance(_multiplyChance / 2);

        return cube.GetComponent<Rigidbody>();
    }

    private void Expload(List<Rigidbody> newCubes, Vector3 center)
    {
        foreach (Rigidbody cube in newCubes)
        {
            cube.AddExplosionForce(_explosionForce, center, _explosionRadius);
        }
    }

    public void MultiplyCubes()
    {
        if(Random.Range(_lowRandomBorder, _highRandomBorder) < _multiplyChance)
        {
            int count = Random.Range(2, _maxMultiply + 1);
            List<Rigidbody> newCubes = new List<Rigidbody>();   

            for (int i = 0; i < count; i++)
            {
                newCubes.Add(CreateCube());
            }

            Expload(newCubes, transform.position);
        }

        Destroy(gameObject);
    }

    private void CheckTransform(Transform clickedTransform)
    {
        if(clickedTransform == transform)
        {
            MultiplyCubes();
        }
    }

    public void SetMultiplyChance(int chance)
    {
        _multiplyChance = chance;
    }
}
