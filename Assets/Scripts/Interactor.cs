using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void InteractWithTag(string tag);
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.InteractWithTag(hitInfo.collider.gameObject.tag);
                }
            }
        }
    }
}