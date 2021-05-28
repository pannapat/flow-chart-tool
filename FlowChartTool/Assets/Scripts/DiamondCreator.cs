using System.Collections;
using System.Collections.Generic;
using Graphs;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondCreator : MonoBehaviour, IPointerClickHandler
{
    private Graph<GameObject> grahDS;
    public GameObject FlowChartPanel;

    public GameObject originNode;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        Vector2 popupPosition = new Vector2(mousePosition.x, mousePosition.y - 50);

        GameObject newElement = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/NewDiamond.prefab"));
        newElement.transform.SetParent(GameObject.Find("Canvas").transform);
        newElement.transform.localPosition = new Vector3(0, -200, 0);
        newElement.tag = "UIDraggable";

        GameObject newEdgeElement = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/VerticalArrow.prefab"));
        newEdgeElement.transform.SetParent(GameObject.Find("Canvas").transform);
        newEdgeElement.transform.localPosition = new Vector3(0, -100, 0);


        Destroy(this.transform.parent.gameObject);
        grahDS = GameObject.Find("FlowChartPanel").GetComponent<FlowChartPanel>().getGraph();
        grahDS.AddNode(newElement);
        grahDS.AddEdge(this.originNode, newElement);
        Debug.Log(grahDS.Count);
    }
   
}
