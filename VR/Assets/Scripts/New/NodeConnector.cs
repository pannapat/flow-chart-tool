using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour
{
    public Vector3 Vector3 { get; private set; }
    private Vector3 startPosition;
    private LineRenderer lineRenderer;
    private float mZCoord;
    private Vector3 mOffset;
    public bool isDragging;
    private readonly object ANCHOR_TAG = "Anchor";

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        if(lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.02f;
    }

    private void ResetLineRender()
    {
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnMouseDown()
    {
        isDragging = true;
        // create an edge
        startPosition = this.transform.position;


        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseDrag()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, GetMouseAsWorldPoint());
    }

    private void OnMouseUp()
    {
        GameObject endObject = DetectHitObject();
        if (isDragging)
        {
            if (endObject == null)
            {
                Debug.Log("null endObject");
                lineRenderer.positionCount = 0;
            }
            else
            {
                GameObject startObject = this.transform.parent.gameObject;
                GraphNode<GameObject> startNode = Global.graph.Find(startObject);
                GraphNode<GameObject> endNode;

                if (endObject.tag.Equals(ANCHOR_TAG))
                {
                    endNode = Global.graph.Find(endObject.transform.parent.gameObject);
                }
                else
                {
                    endNode = Global.graph.Find(endObject);
                }

                lineRenderer.SetPosition(0, startObject.transform.position);
                lineRenderer.SetPosition(1, endObject.transform.position);

                LineRenderer settledLineRender = Instantiate(lineRenderer, lineRenderer.transform.position, Quaternion.identity, lineRenderer.transform.parent);
                Global.graph.AddEdge(startNode.Value, endNode.Value, settledLineRender);
                Debug.Log("A new edge has been added to the graph ( from: " + startNode.Value.name + " to: " + endNode.Value.name +")");

                ResetLineRender();
            }
        }


        isDragging = false;
    }


    private GameObject DetectHitObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            //Debug.Log(hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        return null;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
