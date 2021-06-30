using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
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

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;

        GraphNode<GameObject> focusNode = Global.graph.Find(this.gameObject);
        if(focusNode != null)
        {
            List<GraphEdge<LineRenderer>> graphEdgeList = focusNode.Edges;
            List<int> graphEdgePositionList = focusNode.EdgePositions;

            for(int i=0; i<graphEdgeList.Count; i++)
            {
                graphEdgeList[i].Value.SetPosition(graphEdgePositionList[i], focusNode.Value.transform.position);
            }
        }
    }

}