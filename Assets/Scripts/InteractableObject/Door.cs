using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static interactableObject;

public class Door :interactableObject
{
    [Header("�� ����")]
    public bool isOpen = false;
    public Vector3 openPosition;
    public float openSpeed = 2f;

    private Vector3 closedPosition;

    protected override void Start()
    {
        base.Start();
        objectName = "��";
        interactionText = "[E] �� ����";
        interactionType = InteractionType.Building;

        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.right * 3f;
    }

    protected override void AccessBuilding()
    {
        isOp
    }
}
