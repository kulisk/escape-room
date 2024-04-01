using UnityEngine;

public class PlayerObjectTrigger : MonoBehaviour
{
    public Transform playerTransform; // Το Transform του παίκτη
    public Transform objectToMove; // Το Transform του αντικειμένου που θα μετακινηθεί
    public float xThreshold = 5f; // Η τιμή x που θα προκαλέσει τη μετακίνηση
    public Vector3 newPosition; // Οι νέες συντεταγμένες του αντικειμένου όταν γίνει η μετακίνηση

    private bool hasMoved = false; // Έχει ήδη γίνει η μετακίνηση;

    void Start()
    {
        // Ορίζουμε τον προορισμό ως την αρχική θέση του αντικειμένου
        Vector3 newPosition = new Vector3(objectToMove.position.x, objectToMove.position.y, objectToMove.position.z);
    }

    void Update()
    {
        // Εάν ο παίκτης έχει ξεπεράσει την τιμή x και δεν έχει γίνει ήδη η μετακίνηση
        if (playerTransform.position.x < xThreshold && !hasMoved)
        {
            
            // Μετακινούμε το αντικείμενο στις νέες συντεταγμένες
            objectToMove.position = newPosition;
            // Ορίζουμε ότι έχει γίνει η μετακίνηση
            hasMoved = true;
        }
    }
}
