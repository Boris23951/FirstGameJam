using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogsHatPlayer : MonoBehaviour
{
    public float closeDelay;
    [Header("Dialogs")]
    public static bool TalkingIsActive = false;// ����������� �� true �� ���� �������� smallTalk(��������� ��������������)

    public TMP_Text hatText;
    public GameObject hatPanel;

    public TMP_Text playerText;
    public GameObject playerPanel;
    private int bigDialogId;

    public GameObject verySmallHat;

    [Header("SongsAndTalks")]
    private int SmallTalkId;// if 0 - SmallTalk not active

    public TMP_Text smallHatText;
    public GameObject smallHatPanel;

    public TMP_Text smallPlayerText;
    public GameObject smallPlayerPanel;

    private float timer;
    private float dialogDelay;//random  float for start smalltalk

    private void Awake()
    {
        hatPanel.SetActive(false);
        playerPanel.SetActive(false);
        smallHatPanel.SetActive(false);
        smallPlayerPanel.SetActive(false);
    }
    private void Start()
    {
        TalkingIsActive = false;//!!!!!!
        bigDialogId = 1;
        HatBigPhrase();
        dialogDelay = Random.Range(20, 100);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > dialogDelay && TalkingIsActive == false)
        {
            RandomPhraseStart();
            timer = 0;
        }
    }
    #region Dialogs
    public void HatBigPhrase()
    {
        TalkingIsActive = true;
        EndPlayerSmallPhrase();
        EndHatSmallPhrase();
        hatPanel.SetActive(true);
        switch (bigDialogId)
        {
            case 1:
                PlayerInput.playerControlOn = false;
                hatText.text = "����������� ��� � ���� ����!";
                bigDialogId = 2;
                Invoke("EndHatPhrase", closeDelay);
                Invoke("PlayerAnswer", closeDelay);
                break;
            case 3:
                hatText.text = "X�����, �����.";
                bigDialogId = 4;
                verySmallHat.SetActive(false);
                Invoke("EndHatPhrase", closeDelay);
                Invoke("PlayerAnswer", closeDelay);
                break;
            case 5:
                hatText.text = "����������� A � D, E - ������� ����������� �� ����";
                bigDialogId = 6;
                Invoke("EndHatPhrase", closeDelay);
                Invoke("PlayerAnswer", closeDelay);
                break;
        }
    }
    private void PlayerAnswer()
    {
        playerPanel.SetActive(true);
        switch (bigDialogId)
        {
            case 2:
                playerText.text = "����� �����, ������ �����?";
                bigDialogId = 3;
                Debug.Log(2);
                Invoke("EndPlayerPhrase", closeDelay);
                Invoke("HatBigPhrase", closeDelay);
                break;
            case 4:
                playerText.text = "�������� ��� ����������.";
                bigDialogId = 5;
                Invoke("EndPlayerPhrase", closeDelay);
                Invoke("HatBigPhrase", closeDelay);
                break;
            case 6:
                PlayerInput.playerControlOn = true;
                playerText.text = "�����, ����� ����� ����.";
                bigDialogId = 7;
                Invoke("EndPlayerPhrase", closeDelay);
                break;
        }
    }
    private void EndHatPhrase()
    {
        hatPanel.SetActive(false);
    }
    private void EndPlayerPhrase()
    {
        playerPanel.SetActive(false);
    }
    #endregion
    #region RandomDialogs
    public void RandomPhraseStart()
    {
        SmallTalkId = Random.Range(1, 6);////�������� ����� ����������!!!!
        HatPhraseVariants();
    }
    private void HatPhraseVariants()//////////////���������!!!!
    {
        smallHatPanel.SetActive(true);
        switch (SmallTalkId)
        {
            case 1:
                smallHatText.text = "������ ���� � �����, ������� ������ ���� ����...";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
            case 2:
                smallHatText.text = "I am a passenger And I ride and I ride";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
            case 3:
                smallHatText.text = "��� ���� ���� ����� ��� ������";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
            case 4:
                smallHatText.text = "��������";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
            case 5:
                smallHatText.text = "�����-�� � ���� ���� ������ �����������";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
            case 6:
                smallHatText.text = "";
                Invoke("EndHatSmallPhrase", closeDelay);
                Invoke("AnwserPlayerSmallPhrase", closeDelay);
                break;
        }
        if (TalkingIsActive == true)
        {
            EndPlayerSmallPhrase();
            EndHatSmallPhrase();
        }
    }
    private void AnwserPlayerSmallPhrase()
    {
        smallPlayerPanel.SetActive(true);
        switch (SmallTalkId)
        {
            case 1:
                smallPlayerText.text = "��������? �� ��������� ������?";
                Invoke("EndPlayerSmallPhrase", closeDelay);
                break;
            case 2:
                smallPlayerText.text = "...";
                Invoke("EndPlayerSmallPhrase", closeDelay);
                break;
            case 3:
                smallPlayerText.text = "� ���������� ���� ���, � ��� �������";
                Invoke("EndPlayerSmallPhrase", closeDelay);
                break;
            case 4:
                smallPlayerText.text = "�� ���� ��������";
                Invoke("EndPlayerSmallPhrase", closeDelay);
                break;
            case 5:
                smallPlayerText.text = "� ���� ��� �������, ������� �� ��� �����";
                Invoke("EndPlayerSmallPhrase", closeDelay);
                break;
        }
        if (TalkingIsActive == true)
        {
            EndPlayerSmallPhrase();
            EndHatSmallPhrase();
        }
    }
    private void EndHatSmallPhrase()
    {
        smallHatPanel.SetActive(false);
    }
    private void EndPlayerSmallPhrase()
    {
        smallPlayerPanel.SetActive(false);
        SmallTalkId = 0;
        dialogDelay = Random.Range(20, 100);
        timer = 0;
    }
    #endregion
}
