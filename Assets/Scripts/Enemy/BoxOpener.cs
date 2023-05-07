using TMPro;
using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    public GameObject boxOpenerEvent;
    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    public TMP_Text miniGameText;
    private int _punchToDestroy;
    private GameObject cloneEnemy;

    [SerializeField] private GameObject _pipe1;
    [SerializeField] private GameObject _pipe2;
    private int _try;
    private int _result;

    private void OnEnable()
    {
        _try = 3;
        PlayerInput.playerControlOn = false;
        UiUpdate();
        cloneEnemy = Instantiate(enemyPrefab, enemyBattleStation);
    }
    private void OnDisable()
    {
        PlayerInput.playerControlOn = true;
        Destroy(cloneEnemy);
    }
    public void PuchButton()
    {
        //playsound
        UiUpdate();
        if (_try == 0)
        {
            LoseGame();
        }
    }
    private void Pipe1()
    {

    }
    private void Pipe2()
    {

    }
    private void UiUpdate()
    {
        miniGameText.text = "Осталось попыток: " + _try.ToString();
    }
    private void WinGame()
    {
        //sound
        boxOpenerEvent.SetActive(false);
    }
    private void LoseGame()
    {

    }
    private void Update()
    {
        _pipe1.transform.Rotate(0, 0, 22.5f);
        _result = Mathf.RoundToInt(transform.eulerAngles.z);
        Debug.Log(_result);
    }
}
