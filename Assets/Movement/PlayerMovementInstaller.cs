using UnityEngine;

public class PlayerMovementInstaller : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        MovementSystem.Instance.SetPlayer(transform);
        InputSystem.Instance.OnPointerDown += HandlePointerDown;
    }

    private void HandlePointerDown(Vector2 target)
    {
        MovementSystem.Instance.SetPlayerTarget(target, _speed);
    }
}