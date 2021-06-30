using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.ProceduralImage;

public class ElementCreator : MonoBehaviour, IPointerClickHandler
{
    public GameObject FlowChartPanel;
    //public GameObject newShapePopupPrefab;
    public GameObject originElement;
    public GameObject rectangleShapeObject;
    public GameObject diamondShapeObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rectangleShapeObject != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                
            }
        }
        if (diamondShapeObject != null)
        {

        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        Vector2 mousePosition = eventData.position;
        Vector2 popupPosition = new Vector2(mousePosition.x, mousePosition.y - 50);

        // show shape options: rectangle, diamond
        GameObject newShapePopupPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/NewShapePopup.prefab");
        GameObject newShapePopup = Instantiate(newShapePopupPrefab, popupPosition, Quaternion.identity);
        newShapePopup.transform.SetParent(originElement.transform);

        //this.GetComponent<UIEdgeRenderer>().SetObjects(originElement.gameObject, newShapePopup);
    }
}
