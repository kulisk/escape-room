using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractable {
    public int buttonIndex; // Index of the button in the sequence
    [SerializeField] private float pressedOffsetX = -0.1f; // Offset when pressed along the x-axis

    private Vector3 originalPosition; // Original position of the button
    private bool isPressed = false; // Track if the button is already pressed

    private void Start() {
        originalPosition = transform.position;
    }

    public void Interact() {
        PressButton(); // Trigger button press when interacted with
    }

    public void PressButton() {
        if (!isPressed) {
            isPressed = true;
            transform.position += new Vector3(pressedOffsetX, 0f, 0f); // Move the button along the x-axis
        }
    }

    public void ResetButton() {
        isPressed = false;
        transform.position = originalPosition; // Reset position to original
    }
}
