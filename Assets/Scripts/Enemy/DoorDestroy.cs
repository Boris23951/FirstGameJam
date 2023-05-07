using TMPro;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{
    public GameObject doorDestroyEvent;
    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    public TMP_Text miniGameText;
    private GameObject cloneEnemy;

    public float dontDestroyChance = 0.3f;
    [SerializeField] private BattleSystem _battleSystem;
    [SerializeField] private AudioSource _punch;

    private void OnEnable()
    {
        PlayerInput.playerControlOn = false;
        
        UiUpdate();
        cloneEnemy = Instantiate(enemyPrefab, enemyBattleStation);
    }
    private void OnDisable()
    {
        PlayerInput.playerControlOn = true;
        Destroy(cloneEnemy);
    }
    public void Punch()
    {
        _punch.Play();
        if (Random.value > dontDestroyChance)
        {
            EndGame();
        }
        else
        {
            _battleSystem.PlayerTakeDamage?.Invoke();
            Bank.PlayerHealth -= 5;
        }
        UiUpdate();
        if(Bank.PlayerHealth <= 0)
        {
            miniGameText.text = "Катись домой :(";
            Invoke("EndGame", 2.5f);
            Invoke("GoHome", 2.5f);
        }
    }
    private void UiUpdate()
    {
        miniGameText.text = "Текущее здороье "+ Bank.PlayerHealth.ToString();
    }
    private void EndGame()
    {
        doorDestroyEvent.SetActive(false);
    }
    private void GoHome()
    {
        Bank.GoBase = true;
    }
}
