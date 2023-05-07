using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	public GameObject battleSystem;

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	private GameObject cloneEnemy;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public TMP_Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	public UnityAction PlayerTakeDamage;
	[SerializeField] private AudioSource _playerTakeDamage;

	IEnumerator SetupBattle()
	{
		GameObject playerGO = playerPrefab;
		playerUnit = playerGO.GetComponent<Unit>();
		playerUnit.currentHP = Bank.PlayerHealth;

		cloneEnemy = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = cloneEnemy.GetComponent<Unit>();

		dialogueText.text = "Ваш противник -  " + enemyUnit.unitName + ". Удачи";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		dialogueText.text = "Успешная атака!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " атакует!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		_playerTakeDamage.Play();
		PlayerTakeDamage?.Invoke();


		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "Вы победили!";
			Bank.PlayerHealth = playerUnit.currentHP;
		} 
		else if (state == BattleState.LOST)
		{
			Bank.GoBase = true;
			dialogueText.text = "Катись отсюда!.";
		}
		battleSystem.SetActive(false);
	}

	void PlayerTurn()
	{
		dialogueText.text = "Выберите действие:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(8);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "Вы чувстувете прилив сил!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}
    private void OnEnable()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
		PlayerInput.playerControlOn = false;
	}
    private void OnDisable()
    {
		Destroy(cloneEnemy);
		PlayerInput.playerControlOn = true;
	}
}
