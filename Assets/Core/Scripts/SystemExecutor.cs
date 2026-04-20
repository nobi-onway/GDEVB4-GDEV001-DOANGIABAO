using UnityEngine;

public class SystemExecutor : MonoBehaviour
{
    private void Update()
    {
        ExecuteAllSystems();
    }

    private void ExecuteAllSystems()
    {
        ExecuteMovementSystem();
        ExecuteRescueSystem();
    }

    private void ExecuteRescueSystem()
    {
        if (RescueSystem.Instance == null) return;

        RescueSystem.Instance.Update();
    }

    private void ExecuteMovementSystem()
    {
        if (MovementSystem.Instance == null) return;

        MovementSystem.Instance.UpdatePlayerPosition();
        MovementSystem.Instance.UpdateAllSoldierPositions();
    }
}
