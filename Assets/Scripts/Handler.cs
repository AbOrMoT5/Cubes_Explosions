using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private const int MinChance = 0;
    private const int MaxChance = 100;

    private void OnEnable()
    {
        _raycaster.CubeHit += OnCubeHit;
    }

    private void OnDisable()
    {
        _raycaster.CubeHit -= OnCubeHit;
    }

    private void OnCubeHit(Cube cube)
    {
        if (Random.Range(MinChance, MaxChance) < cube.SplitChance)
        {
            List<Cube> newCubes = _spawner.GenerateCubesList(cube);
            _exploder.Explode(newCubes, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}
