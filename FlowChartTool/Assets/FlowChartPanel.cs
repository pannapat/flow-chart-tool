using System.Collections;
using System.Collections.Generic;
using Graphs;
using UnityEngine;

public class FlowChartPanel : MonoBehaviour
{
    Graph<string> graph;

    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Graph<string> getGraph()
    {
        return this.graph;
    }

}
