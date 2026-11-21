using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;
    [SerializeField] private float _spawnOffset = 0.2f;

    private const int ScaleDivider = 2;
    private const int ChanceDivider = 2;

    public List<Cube> GenerateCubesList(Cube source)
    {
        int count = Random.Range(_minCount, _maxCount + 1);
        List<Cube> cubes = new List<Cube>(count);

        for (int i = 0; i < count; i++)
        {
            cubes.Add(CreateCube(source));
        }

        return cubes;
    }

    private Cube CreateCube(Cube source)
    {
        Cube cube = Instantiate(_cubePrefab);

        Vector3 position = source.transform.position + Random.insideUnitSphere * _spawnOffset;
        Vector3 scale = source.transform.localScale / ScaleDivider;

        cube.Init(source.SplitChance / ChanceDivider, scale, position);
        _colorChanger.SetRandomColor(cube.Renderer);

        return cube;
    }
}
