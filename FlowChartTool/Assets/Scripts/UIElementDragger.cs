using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Graphs;

public class UIElementDragger : MonoBehaviour
{
    public GameObject FlowChartPanel;

    public const string CLONABLE_TAG = "UIClonable";
    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;
    private bool cloning = false;

    private Vector2 originalPosition;

    private Transform objectToDrag;
    private Image objectToDragImage;


    LinkedList<String> myList = new LinkedList<String>();

    List<RaycastResult> hitObjects = new List<RaycastResult>();

    #region MonoBehavior API

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                //objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (objectToDrag != null)
            {
                if (objectToDrag.tag == CLONABLE_TAG && !cloning)
                {
                    cloning = true;
                    objectToDragImage = objectToDrag.GetComponent<Image>();
                    Image clonedObject = Instantiate(objectToDrag.GetComponent<Image>());
                    clonedObject.tag = DRAGGABLE_TAG;
                    clonedObject.transform.SetParent(FlowChartPanel.transform);

                    GraphNode<GameObject> node = new GraphNode<GameObject>(clonedObject.gameObject, clonedObject.transform);
                    FlowChartPanel.GetComponent<FlowChartPanel>().getGraph().AddNode(node);
                    Debug.Log(FlowChartPanel.GetComponent<FlowChartPanel>().getGraph().Count);

                    clonedObject.transform.position = Input.mousePosition;
                    objectToDrag.position = originalPosition;

                    InputField inputField2 = clonedObject.transform.GetChild(0).gameObject.GetComponent<InputField>();
                    inputField2.placeholder.color = new Color(0.1960784f, 0.1960784f, 0.1960784f);


                    objectToDrag = null;
                }
            }

            dragging = false;
            cloning = false;
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

        if (clickedObject != null && clickedObject.tag == CLONABLE_TAG || clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }
        return null;
    }

    private void storeNewNode()
    {
        // Adding nodes in LinkedList
        myList.AddLast("Geeks");
        myList.AddLast("for");
        myList.AddLast("Data Structures");
        myList.AddLast("Noida");

        // To check if LinkedList is empty or not
        if (myList.Count > 0)
            Console.WriteLine("LinkedList is not empty");
        else
            Console.WriteLine("LinkedList is empty");
    }
}