using UnityEngine;
using UnityEngine.Events;

public class BasePoint : MonoBehaviour
{
    public UnityEvent BaswCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //sound?
            Bank.PlayerHealth = Bank.PlayerMaxHealth;
        }
    }
}
