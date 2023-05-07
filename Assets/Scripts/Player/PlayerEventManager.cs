using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public GameObject battleSystem;
    public GameObject lockMinniGame;
    public GameObject webClicker;
    public GameObject doorDestroy;

    void Start()
    {
        doorDestroy.SetActive(false);
        battleSystem.SetActive(false);
        webClicker.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Enemy")
        {
            battleSystem.SetActive(true);
            Destroy(other.gameObject);
        }
        if(other.name == "Web")
        {
            webClicker.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.name == "Door")
        {
            doorDestroy.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.name == "BonusBox")
        {
            doorDestroy.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
