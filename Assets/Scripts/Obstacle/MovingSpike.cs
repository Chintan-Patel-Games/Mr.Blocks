using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    private void Start() => SetPatrolPoints();

    private void Update()
    {
        RotateSpikeBall();
        PatrolSpikeBall();
    }

    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }

    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);

    private void PatrolSpikeBall()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
}