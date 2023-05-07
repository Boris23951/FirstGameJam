using UnityEngine;
using UnityEngine.Events;

public class FastTravel : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public Transform BasePoint;
    [SerializeField] private float speed;
    private bool runToBase;

    [Header("Ўл€па догон€ет")]
    [SerializeField] private float hatTransformSpeed;
    public GameObject hat;
    public Transform hatPosititionOnHead;
    public Transform hatPosititionFly;

    public UnityEvent BaseCollision;

    private void Start()
    {
        runToBase = false;
    }
    public void BaseButtonDown()
    {

    }
    private void FixedUpdate()
    {
        animator.SetFloat("Roll", 0);
        animator.SetFloat("WalkSpeed", 0);
        if (Input.GetKey(KeyCode.E) || Bank.GoBase)
        {
            PlayerInput.playerControlOn = false;
            player.transform.LookAt(BasePoint.position);
            runToBase = true;
        }
        if (runToBase)
        {
             player.transform.position = Vector3.MoveTowards(transform.position, BasePoint.position, speed * Time.deltaTime);
             animator.SetFloat("Roll", 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BasePoint")
        {
            //onSound
            Bank.GoBase = false;
            runToBase = false;
            PlayerInput.playerControlOn = true;
            Bank.PlayerHealth = Bank.PlayerMaxHealth;
        }
        if (other.name == "BasePoint")
        {
            //offSound
            Bank.PlayerHealth = Bank.PlayerMaxHealth;
            BaseCollision.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "BasePoint")
        {
            Bank.GoBase = false;
            runToBase = false;
            PlayerInput.playerControlOn = true;
            Bank.PlayerHealth = Bank.PlayerMaxHealth;
        }
    }
}