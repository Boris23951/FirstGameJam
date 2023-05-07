using UnityEngine;

public class DestroyWithChance : MonoBehaviour
{
    [Range(0, 1)]
    public float ChancceOfStaying = 0.5f;

    private void Start()
    {
        if(Random.value > ChancceOfStaying)
        {
            Destroy(gameObject);
        }
    }
}
