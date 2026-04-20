using UnityEngine;
using System.Collections.Generic;

public class MovementSystem : Singleton<MovementSystem>
{
    private Transform _player;
    private List<Transform> _soldiers = new List<Transform>();
    private Vector2? _playerTarget;
    private float _playerSpeed;
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

    public void AddSoldier(Transform soldier)
    {
        if (soldier != null && !_soldiers.Contains(soldier))
        {
            _soldiers.Add(soldier);
        }
    }

    public void RemoveSoldier(Transform soldier)
    {
        _soldiers.Remove(soldier);
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
        // Soldiers are stationary, no position updates needed
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