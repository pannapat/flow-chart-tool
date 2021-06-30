using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphInfoLogger : MonoBehaviour, IPointerClickHandler
{
    private Button graphInfoButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Number of nodes: " + Global.graph.Count + "\nNumber of edges: " + Global.graph.EdgeCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        graphInfoButton = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
