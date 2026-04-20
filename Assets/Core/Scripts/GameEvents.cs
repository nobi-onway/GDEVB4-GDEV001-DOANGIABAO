using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<Transform, Transform> OnPlayerClosestToSoldier;
    public static event Action<Transform> OnPlayerEnterSoldierZone;
    public static event Action<Transform> OnPlayerExitSoldierZone;

    public static void PlayerClosestToSoldier(Transform player, Transform soldier)
    {
        OnPlayerClosestToSoldier?.Invoke(player, soldier);
    }

    public static void PlayerEnterSoldierZone(Transform soldier)
    {
        OnPlayerEnterSoldierZone?.Invoke(soldier);
    }

    public static void PlayerExitSoldierZone(Transform soldier)
    {
        OnPlayerExitSoldierZone?.Invoke(soldier);
    }
}
