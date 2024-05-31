using UnityEngine;

public class RampMovement : MonoBehaviour
{
    public GameObject ramp;
    public Transform rampTransform; // Reference to the ramp's Transform component

    [SerializeField] private float duration = 2f; // Duration for the movement and rotation

    [Header("Starting Position and Rotation")]
    [SerializeField] private Vector3 startPosition = new Vector3(-408.5f, 36.9f, 209.2f);
    [SerializeField] private Vector3 startRotationEuler = new Vector3(90f, 0f, 90f);

    [Header("End Position and Rotation")]
    [SerializeField] private Vector3 endPosition = new Vector3(-450.7379f, -2.294304f, 217.2754f);
    [SerializeField] private Vector3 endRotationEuler = new Vector3(0f, 0f, 0f);

    private Quaternion startRotation;
    private Quaternion endRotation;
    private float startTime;
    private bool isMoving = false;
    private bool isFrozen = false;

    private void Start()
    {
        // Convert Euler angles to Quaternion for rotations
        startRotation = Quaternion.Euler(startRotationEuler);
        endRotation = Quaternion.Euler(endRotationEuler);

        // Ensure the ramp starts at the defined start position and rotation
        rampTransform.position = startPosition;
        rampTransform.rotation = startRotation;
        ramp.SetActive(false);
    }

    private void Update()
    {
        if (Crystals.completed && !isMoving && !isFrozen)
        {
            startTime = Time.time;
            isMoving = true;
            ramp.SetActive(true);
        }

        if (isMoving)
        {
            MoveRamp();
        }
    }

    void MoveRamp()
    {
        float elapsedTime = Time.time - startTime;
        float t = Mathf.Clamp01(elapsedTime / duration);

        // Lerp position and rotation
        rampTransform.position = Vector3.Lerp(startPosition, endPosition, t);
        rampTransform.rotation = Quaternion.Lerp(startRotation, endRotation, t);

        if (t >= 1f)
        {
            isMoving = false;
            isFrozen = true; // Freeze the ramp in place
        }
    }
}
