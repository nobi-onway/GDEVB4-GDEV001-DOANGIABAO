using UnityEngine;

public class SoldierBehaviorInstaller : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;
    private CountdownTimer _countdownTimer;

    private void Start()
    {
        _countdownTimer = new CountdownTimer(_lifeTime);
    }

    private void Update()
    {
        _countdownTimer.Tick(Time.deltaTime, () => Destroy(gameObject));
    }
}