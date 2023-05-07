using TMPro;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    public GameObject spiderWebEvent;
    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    public TMP_Text miniGameText;
    private int _punchToDestroy;
    private GameObject cloneEnemy;

    [SerializeField] private AudioSource _punch;

    private void OnEnable()
    {
        PlayerInput.playerControlOn = false;
        _punchToDestroy = Random.Range(4, 12);
        UiUpdate();
        cloneEnemy =  Instantiate(enemyPrefab, enemyBattleStation);
    }
    private void OnDisable()
    {
        PlayerInput.playerControlOn = true;
        Destroy(cloneEnemy);
    }
    public void Punch()
    {
        _punch.Play();
        _punchToDestroy--;
        UiUpdate();
        if(_punchToDestroy == 0)
        {
            EndGame();
        }
    }
    private void UiUpdate()
    {
        miniGameText.text = _punchToDestroy.ToString();
    }
    private void EndGame()
    {
        spiderWebEvent.SetActive(false);
    }
}
