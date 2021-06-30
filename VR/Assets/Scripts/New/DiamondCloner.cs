using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DiamondCloner : MonoBehaviour
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
        GameObject diamondPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/New/Diamond.prefab");
        GameObject newDiamond = Instantiate(diamondPrefab, GetMouseAsWorldPoint(), diamondPrefab.transform.rotation);
        newDiamond.transform.SetParent(this.transform.parent);

        Global.graph.AddNode(newDiamond);
        Debug.Log("A new diamond node has been added.");
    }
}
