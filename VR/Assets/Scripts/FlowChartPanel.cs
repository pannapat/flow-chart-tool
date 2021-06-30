using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowChartPanel : MonoBehaviour
{
    public Graph<GameObject> graph;

    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Graph<GameObject> getGraph()
    {
        return this.graph;
    }

}
