using UnityEngine;

public class PlayerMovementInstaller : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector2? _currentTarget;

    private void Awake()
    {
        InputSystem.Instance.OnPointerDown += SetTarget;
    }

    private void SetTarget(Vector2 target) => _currentTarget = target;

    private void HandleMovement()
    {
        if (!MovementSystem.MoveStraight(_currentTarget, _speed, transform)) return;
        
        _currentTarget = null;
    }

    private void Update()
    {
        HandleMovement();
    }
}