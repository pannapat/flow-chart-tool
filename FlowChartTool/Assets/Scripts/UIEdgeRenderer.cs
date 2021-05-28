using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.ProceduralImage;

public class UIEdgeRenderer : MonoBehaviour
{
    private RectTransform obj1;
    private RectTransform obj2;
    public RectTransform rectTransform { get; set; }
    public Image image { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponent<Image>();
        //rectTransform = GetComponent<RectTransform>();


        //GameObject emptyObj = new GameObject("edge", typeof(RectTransform));
        //emptyObj.AddComponent<Image>();
        //emptyObj.transform.SetParent(this.gameObject.transform.parent);
        //image = emptyObj.GetComponent<Image>();
        //image.color = Color.red;
        //rectTransform = emptyObj.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(obj1 && obj2 && obj1.gameObject.activeSelf && obj2.gameObject.activeSelf)
        {
            rectTransform.localPosition = (obj1.localPosition + obj2.localPosition) / 2;
            Vector3 dif = obj2.localPosition - obj1.localPosition;
            rectTransform.sizeDelta = new Vector3(dif.magnitude, 7);
            rectTransform.rotation = Quaternion.Euler(new Vector3(0, 20, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));

            //Debug.Log(rectTransform.localPosition);
        }
    }

    public void SetObjects(GameObject one, GameObject two)
    {
        obj1 = one.GetComponent<RectTransform>();
        obj2 = two.GetComponent<RectTransform>();

        RectTransform aux;
        if(obj1.localPosition.x > obj2.localPosition.x)
        {
            aux = obj1;
            obj1 = obj2;
            obj2 = aux;
        }
    }


}
