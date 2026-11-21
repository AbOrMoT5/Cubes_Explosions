using UnityEngine;

public class Cube : MonoBehaviour
{
    public int SplitChance { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    public void Init(int splitChance, Vector3 scale, Vector3 position)
    {
        SplitChance = splitChance;
        transform.localScale = scale;
        transform.position = position;
    }
}
