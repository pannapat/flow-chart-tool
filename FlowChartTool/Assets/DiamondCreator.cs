using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondCreator : MonoBehaviour, IPointerClickHandler
{
    public GameObject FlowChartPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = eventData.position;
        Vector2 popupPosition = new Vector2(mousePosition.x, mousePosition.y - 50);

        GameObject newElement = Instantiate(this.gameObject, popupPosition, Quaternion.identity);
        newElement.transform.SetParent(GameObject.Find("Canvas").transform);

        Destroy(this.transform.parent.gameObject);
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
