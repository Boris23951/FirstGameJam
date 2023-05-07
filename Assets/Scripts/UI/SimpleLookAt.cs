using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    private Transform target;
    private void Start()
    {
        target = Camera.main.gameObject.transform;
    }
    private void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
    }
}
