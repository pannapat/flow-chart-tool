using System.Collections;
using System.Collections.Generic;
using Graphs;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RectangleCreator : MonoBehaviour, IPointerClickHandler
{
    public GameObject originNode;
    private Graph<GameObject> grahDS;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        Vector2 popupPosition = new Vector2(mousePosition.x, mousePosition.y - 50);

        GameObject newElement = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/NewRectangle.prefab"));
        newElement.transform.SetParent(GameObject.Find("FlowChartPanel").transform);
        newElement.transform.localPosition = new Vector3(0, -200, 0);
        newElement.tag = "UIDraggable";

        GameObject emptyObj = new GameObject("edge", typeof(RectTransform));
        emptyObj.AddComponent<Image>();
        emptyObj.transform.SetParent(this.gameObject.transform.parent.parent.parent);
        Image image = emptyObj.GetComponent<Image>();
        image.color = Color.red;
        RectTransform newEdge = emptyObj.GetComponent<RectTransform>();

        (GameObject.FindObjectOfType(typeof(UIEdgeRenderer)) as UIEdgeRenderer).SetObjects(newElement, this.originNode, newEdge);

        grahDS = GameObject.Find("FlowChartPanel").GetComponent<FlowChartPanel>().getGraph();
        grahDS.AddNode(newElement);
        grahDS.AddEdge(this.originNode, newElement);

        Destroy(this.transform.parent.gameObject);
    }

    void Start()
    {
        this.originNode = this.transform.parent.parent.gameObject;
    }
}
