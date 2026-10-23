using System.Collections.Generic;
using UnityEngine;

public class Exploadeable_object : MonoBehaviour
{
    [SerializeField] private ObjectDetecter _objectDetecter;
    [SerializeField] private int _multiplyChance = 100;
    private int _lowRandomBorder = 0;
    private int _highRandomBorder = 100;
    private int _maxMultiply = 6;
    private float _explosionRadius = 40;
    private float _explosionForce = 1000;

    private void OnEnable()
    {
        _objectDetecter.ObjectClicked += CheckTransform;
    }

    private void OnDisable()
    {
        _objectDetecter.ObjectClicked -= CheckTransform;
    }

    private void Expload()
    {
        foreach(Rigidbody ExploadObject in GetExploadObject())
        {
            ExploadObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExploadObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> exploadObjects = new List<Rigidbody>();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
                exploadObjects.Add(hit.attachedRigidbody);
        }

        return exploadObjects;
    }

    private void CreateCube(GameObject cubeObject)
    {
        GameObject cube = Instantiate(cubeObject);
        cube.name = "Cube";
        cube.transform.localScale /= 2;
        cube.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        cube.GetComponent<Exploadeable_object>().SetMultiplyChance(_multiplyChance / 2);
    }

    public void MultiplyCubes()
    {
        if(Random.Range(_lowRandomBorder, _highRandomBorder) < _multiplyChance)
        {
            int count = Random.Range(2, _maxMultiply + 1);
            for (int i = 0; i < count; i++)
            {
                CreateCube(gameObject);
            }
            Expload();
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
