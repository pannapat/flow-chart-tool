using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectCloner : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        originPosition = gameObject.transform.position;
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
    }

    private void OnMouseUp()
    {
        transform.position = originPosition;
        GameObject rectanglePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/New/Rectangle.prefab");
        GameObject newRectangle = Instantiate(rectanglePrefab, GetMouseAsWorldPoint(), rectanglePrefab.transform.rotation);
        newRectangle.transform.SetParent(this.transform.parent);

        Global.graph.AddNode(newRectangle);
        Debug.Log("A new rectangle node has been added.");
    }

}
