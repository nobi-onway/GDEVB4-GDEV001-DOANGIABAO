using UnityEngine;

public class SystemExecutor : MonoBehaviour
{
    private void Update()
    {
        ExecuteAllSystems();
    }

    private void ExecuteAllSystems()
    {
        ExecuteGameManager();
        ExecuteMovementSystem();
        ExecuteRescueSystem();
    }

    private void ExecuteGameManager()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.UpdateGameTimer();
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
