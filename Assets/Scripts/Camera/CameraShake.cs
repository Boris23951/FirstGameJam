using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _speed;//30-100
    [SerializeField] private int _range;//5
    [SerializeField] private BattleSystem _battleSystem;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _battleSystem.PlayerTakeDamage += OnPlayerDamaged;
    }
    private void OnDisable()
    {
        _battleSystem.PlayerTakeDamage -= OnPlayerDamaged;
    }
    private void OnPlayerDamaged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Shake());
    }
    private IEnumerator Shake()
    {
        int shakeRange = _range;
        Quaternion targetRotation;

        while(shakeRange != 0)
        {
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, shakeRange);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _speed * Time.deltaTime);

            if (transform.rotation == targetRotation)
                shakeRange = (Mathf.Abs(shakeRange) - 1) * -1;

            yield return new WaitForEndOfFrame();
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        _coroutine = null;
    }
}
