using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("상호 작용 설정")]
    public float interactionRange = 2.0f;
    public LayerMask interactionLayerMask = 1;
    public KeyCode interactionKey = KeyCode.E;

    [Header("UI 설정")]
    public Text interactionText;
    public GameObject interactionUI;

    private Transform playerTransform;
    private interactableObject currentinteractable;

    void Start()
    {
        playerTransform = transform;
        HideInteractionUI();
    }

    void Update()
    {
        CheckForInteractables();
        HandleInteractionInput();
    }

    void HandleInteractionInput()
    {
        if(currentinteractable != null && Input.GetKeyDown(interactionKey))
        {
            currentinteractable.Interact();
        }
    }

    void ShowInteractionUI(string text)
    {
        if(interactionUI != null)
        {
            interactionUI.SetActive(true);
        }

        if(interactionText != null)
        {
            interactionText.text = text;
        }
    }

    void HideInteractionUI()
    {
        if(interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    void CheckForInteractables()
    {
        Vector3 checkPosition = playerTransform.position + playerTransform.forward * (interactionRange * 0.5f);

        Collider[] hitColliders = Physics.OverlapSphere(checkPosition, interactionRange, interactionLayerMask);

        interactableObject closestInteractable = null;
        float closestDistance = float.MaxValue;

        foreach(Collider collider in hitColliders)
        {
            interactableObject interactable = collider.GetComponent<interactableObject>();
            if (interactable != null)
            {
                float distance = Vector3.Distance(playerTransform.position, collider.transform.position);

                Vector3 directionToObject = (collider.transform.position - playerTransform.position).normalized;
                float angle = Vector3.Angle(playerTransform.forward, directionToObject);
        
                if(angle < 90f && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }

            if(closestInteractable != currentinteractable)
            {
                if (currentinteractable != null)
                    currentinteractable.OnPlayerExit();

                currentinteractable = closestInteractable;

                if(currentinteractable != null)
                {
                    currentinteractable.OnPlayerEnter();
                    ShowInteractionUI(currentinteractable.GetInteractionText());
                }
                else
                {
                    HideInteractionUI();
                }
            }

        }
    }
}
