using UnityEngine;

public class SoldierMovementInstaller : MonoBehaviour
{
    private void Awake()
    {
        MovementSystem.Instance.AddSoldier(transform);
    }

    private void OnDestroy()
    {
        MovementSystem.Instance.RemoveSoldier(transform);
    }
}
