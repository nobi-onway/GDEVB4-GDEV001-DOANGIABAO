using UnityEngine;

public static class MovementSystem
{
    public static bool MoveStraight(Vector2? target, float speed, Transform transform)
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