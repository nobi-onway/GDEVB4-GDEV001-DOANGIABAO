using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private const float DAMAGE_INTERVAL = 1f;
    private const float DETECTION_DISTANCE = 1f;
    [SerializeField] private float _lifeTime = 10f;
    private CountdownTimer _damageTimer;
    private CountdownTimer _lifetimeTimer;
    private bool _playerInZone = false;

    private void Start()
    {
        _lifetimeTimer = new CountdownTimer(_lifeTime);
    }

    private void Update()
    {
        DetectPlayer();
        UpdateLifetime();
    }

    private void UpdateLifetime()
    {
        _lifetimeTimer.Tick(Time.deltaTime, () => Destroy(gameObject));
    }

    private void DetectPlayer()
    {
        if (MovementSystem.Instance?.Player == null) return;

        Transform player = MovementSystem.Instance.Player;
        float distance = Vector2.Distance(player.position, transform.position);
        bool isInZone = distance <= DETECTION_DISTANCE;

        if (isInZone && !_playerInZone)
        {
            _playerInZone = true;
            _damageTimer = new CountdownTimer(DAMAGE_INTERVAL);
        }
        else if (!isInZone && _playerInZone)
        {
            _playerInZone = false;
            _damageTimer = null;
        }

        if (_playerInZone && _damageTimer != null)
        {
            _damageTimer.Tick(Time.deltaTime, OnDamageInterval);
        }
    }

    private void OnDamageInterval()
    {
        GameManager.Instance.DamageHealth(1);
        _damageTimer = new CountdownTimer(DAMAGE_INTERVAL);
    }
}
