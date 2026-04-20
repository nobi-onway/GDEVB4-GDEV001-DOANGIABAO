using UnityEngine;
using System.Collections.Generic;

public class RescueSystem : Singleton<RescueSystem>
{
    private const float RESCUE_COUNTDOWN_TIME = 1f;
    private const float PROXIMITY_DISTANCE = 1f;
    private Dictionary<Transform, CountdownTimer> _rescueTimers = new Dictionary<Transform, CountdownTimer>();
    private HashSet<Transform> _soldiersInProximity = new HashSet<Transform>();

    public void Update()
    {
        DetectProximityAndUpdateCountdowns();
    }

    private void DetectProximityAndUpdateCountdowns()
    {
        if (MovementSystem.Instance?.Player == null) return;

        Transform player = MovementSystem.Instance.Player;
        var soldiers = MovementSystem.Instance.Soldiers;

        foreach (var soldier in soldiers)
        {
            if (soldier == null) continue;

            float distance = Vector2.Distance(player.position, soldier.position);
            bool isInProximity = distance <= PROXIMITY_DISTANCE;

            if (isInProximity && !_soldiersInProximity.Contains(soldier))
            {
                _soldiersInProximity.Add(soldier);
                _rescueTimers[soldier] = new CountdownTimer(RESCUE_COUNTDOWN_TIME);
                GameEvents.PlayerEnterSoldierZone(soldier);
            }
            else if (!isInProximity && _soldiersInProximity.Contains(soldier))
            {
                _soldiersInProximity.Remove(soldier);
                _rescueTimers.Remove(soldier);
                GameEvents.PlayerExitSoldierZone(soldier);
            }

            if (_soldiersInProximity.Contains(soldier) && _rescueTimers.TryGetValue(soldier, out var timer))
            {
                timer.Tick(Time.deltaTime, () => CompleteSoldierRescue(soldier));
            }
        }
    }

    private void CompleteSoldierRescue(Transform soldier)
    {
        _soldiersInProximity.Remove(soldier);
        _rescueTimers.Remove(soldier);
        GameManager.Instance.IncrementRescueCount();
        Object.Destroy(soldier.gameObject);
    }
}
