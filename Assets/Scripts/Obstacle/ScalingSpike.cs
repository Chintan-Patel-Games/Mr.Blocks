using UnityEngine;

public class ScalingSpike : MonoBehaviour
{
    //rotation variables
    public float rotationAngle = 90f;

    //scaling variables
    private float scalingFactor = 1f;
    private float currentScale;
    public float scalingSpeed = 15f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    //delay variables
    public float scaleDelay = 2f;
    private float timer = 0f;
    private bool isWaiting = false;

    private void Start()
    {
        currentScale = minScale;
        ApplyCurrentScale();
    }
    
    private void Update()
    {
        RotateSpikeBall();
        if (isWaiting)
            HandleWaiting();
        else
            ScaleSpikeBall();
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void ScaleSpikeBall()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scalingFactor = -scalingFactor;
            isWaiting = true;
        }
        ApplyCurrentScale();
    }

    private void ApplyCurrentScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

    private void HandleWaiting()
    {
        timer += Time.deltaTime;
        if (timer >= scaleDelay)
        {
            isWaiting = false;
            timer = 0f;
        }
    }
}