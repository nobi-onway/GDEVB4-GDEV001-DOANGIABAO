using UnityEngine;
using System.Collections.Generic;

public class MovementSystem : Singleton<MovementSystem>
{
    private Transform _player;
    private List<Transform> _soldiers = new List<Transform>();
    private Vector2? _playerTarget;
    private float _playerSpeed;
    private Dictionary<Transform, Vector2?> _soldierTargets = new Dictionary<Transform, Vector2?>();
    private Dictionary<Transform, float> _soldierSpeeds = new Dictionary<Transform, float>();

    public Transform Player => _player;
    public List<Transform> Soldiers => _soldiers;
    public Vector2? PlayerTarget => _playerTarget;

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    public void SetPlayerTarget(Vector2 target, float speed)
    {
        _playerTarget = target;
        _playerSpeed = speed;
    }

    public void AddSoldier(Transform soldier, float speed = 5f)
    {
        if (soldier != null && !_soldiers.Contains(soldier))
        {
            _soldiers.Add(soldier);
            _soldierSpeeds[soldier] = speed;
        }
    }

    public void RemoveSoldier(Transform soldier)
    {
        _soldiers.Remove(soldier);
        _soldierTargets.Remove(soldier);
        _soldierSpeeds.Remove(soldier);
    }

    public void SetSoldierTarget(Transform soldier, Vector2 target)
    {
        if (soldier != null && _soldiers.Contains(soldier))
        {
            _soldierTargets[soldier] = target;
        }
    }

    public void SetAllSoldierTargets(Vector2 target)
    {
        foreach (var soldier in _soldiers)
        {
            _soldierTargets[soldier] = target;
        }
    }

    public bool UpdatePlayerPosition()
    {
        if (_player != null && _playerTarget.HasValue)
        {
            bool isComplete = MoveStraight(_playerTarget, _playerSpeed, _player);
            if (isComplete)
            {
                _playerTarget = null;
            }
            return isComplete;
        }
        return true;
    }

    public void UpdateAllSoldierPositions()
    {
        foreach (var soldier in _soldiers)
        {
            if (soldier != null && _soldierTargets.TryGetValue(soldier, out var target) && target.HasValue)
            {
                float speed = _soldierSpeeds.TryGetValue(soldier, out var s) ? s : 5f;
                bool isComplete = MoveStraight(target, speed, soldier);
                if (isComplete)
                {
                    _soldierTargets[soldier] = null;
                }
            }
        }
    }

    public bool MoveStraight(Vector2? target, float speed, Transform transform)
    {
        if (target == null) return true;

        Vector2? direction = target - (Vector2)transform.position;
        float distance = direction.Value.magnitude;

        if (distance > 0)
        {
            direction.Value.Normalize();
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        return distance <= 0.1f;
    }
}