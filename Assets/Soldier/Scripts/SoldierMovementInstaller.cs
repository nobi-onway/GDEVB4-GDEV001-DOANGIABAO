using UnityEngine;

public class SoldierMovementInstaller : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        MovementSystem.Instance.AddSoldier(transform, _speed);
        InputSystem.Instance.OnPointerDown += HandlePointerDown;
    }

    private void OnDestroy()
    {
        MovementSystem.Instance.RemoveSoldier(transform);
        InputSystem.Instance.OnPointerDown -= HandlePointerDown;
    }

    private void HandlePointerDown(Vector2 target)
    {
        MovementSystem.Instance.SetSoldierTarget(transform, target);
    }
}
