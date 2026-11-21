using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandomColor(Renderer target)
    {
        target.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
