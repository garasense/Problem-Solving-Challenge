using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float speed = 100f;
    [SerializeField] private MovementType movementType;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (movementType == MovementType.RANDOM)
        {
            Vector2 ballDirection = GetRandomDirection();
            MoveBall(ballDirection);
        }
    }

    public void MoveBall(Vector3 direction)
    {
        rigidbody2D.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private Vector2 GetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        return randomDirection;
    }
}

public enum MovementType
{
    RANDOM,
    KEYBOARD_CONTROLLED,
    MOUSE_CONTROLLED
}
