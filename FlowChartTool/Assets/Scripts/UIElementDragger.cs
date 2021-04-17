using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : MonoBehaviour
{
    public GameObject FlowChartPanel;

    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;

    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();

    #region MonoBehavior API

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if(objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;

            if (objectToDrag != null)
            {
                Image clonedObject = Instantiate(objectToDrag.GetComponent<Image>());
                //clonedObject.tag = "Untagged";
                clonedObject.raycastTarget = false;
                clonedObject.transform.SetParent(FlowChartPanel.transform);

                clonedObject.transform.position = Input.mousePosition;
                objectToDrag.position = originalPosition;
            }
        }
    }

    #endregion

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0)
        {
            return null;
        }
        return hitObjects[0].gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }
        return null;
    }
}