using UnityEngine;

public class SoldierBehaviorInstaller : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;
    private CountdownTimer _countdownTimer;

    private void Start()
    {
        _countdownTimer = new CountdownTimer(_lifeTime);
        GameEvents.OnPlayerEnterSoldierZone += HandlePlayerEnterZone;
        GameEvents.OnPlayerExitSoldierZone += HandlePlayerExitZone;
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerEnterSoldierZone -= HandlePlayerEnterZone;
        GameEvents.OnPlayerExitSoldierZone -= HandlePlayerExitZone;
    }

    private void Update()
    {
        _countdownTimer.Tick(Time.deltaTime, OnLifetimeEnd);
    }

    private void HandlePlayerEnterZone(Transform soldier)
    {
        if (soldier == transform)
        {
            _countdownTimer.Stop();
        }
    }

    private void HandlePlayerExitZone(Transform soldier)
    {
        if (soldier == transform)
        {
            _countdownTimer.Resume();
        }
    }

    private void OnLifetimeEnd()
    {
        GameManager.Instance.IncrementDieCount();
        Destroy(gameObject);
    }
}