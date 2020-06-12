using Pixelplacement;
using UnityEngine;

public class SelectionEffect : MonoBehaviour
{
    public float rotationSpeed;

    public float scaleSpeed;
    public Vector3 largeScale;

    private void Awake()
    {
        Tween.LocalScale(transform, largeScale, 1f / scaleSpeed, 0f, Tween.EaseInOut, Tween.LoopType.PingPong);
    }

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}