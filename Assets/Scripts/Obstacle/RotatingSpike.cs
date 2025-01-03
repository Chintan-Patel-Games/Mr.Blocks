using UnityEngine;

public class RotatingSpike : MonoBehaviour
{
    [SerializeField] private float rotationAngle;
    private void Update() => RotateSpikeBall();
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
}