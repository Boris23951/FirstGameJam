using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    public Animator animator;

    //On/Off control
    public static bool playerControlOn = true;
    void FixedUpdate()//onSound
    {
        if (playerControlOn == true)
        {
            animator.SetFloat("WalkSpeed", 0);
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 direction = new Vector3(-1, 0, 0);
                transform.position += direction * _speed * Time.deltaTime;
                transform.LookAt(transform.position + direction);
                animator.SetFloat("WalkSpeed", 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 direction = new Vector3(1, 0, 0);
                transform.position += direction * _speed * Time.deltaTime;
                transform.LookAt(transform.position + direction);
                animator.SetFloat("WalkSpeed", 1);
            }
        }
    }
}
