using System.Collections;
using System.Collections.Generic;
using Graphs;
using UnityEngine;
using UnityEngine.EventSystems;

public class RectangleCreator : MonoBehaviour, IPointerClickHandler
{
    public GameObject FlowChartPanel;
    public GameObject originNode;
    public GameObject rectanglePrefab;
    private Graph<GameObject> grahDS;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        Vector2 popupPosition = new Vector2(mousePosition.x, mousePosition.y - 50);

        GameObject newElement = Instantiate(rectanglePrefab, popupPosition, Quaternion.identity);
        newElement.transform.SetParent(GameObject.Find("Canvas").transform);

        Destroy(this.transform.parent.gameObject);

        grahDS = GameObject.Find("FlowChartPanel").GetComponent<FlowChartPanel>().getGraph();
        grahDS.AddNode(newElement);
        grahDS.AddEdge(this.originNode, newElement);
        Debug.Log(grahDS.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
