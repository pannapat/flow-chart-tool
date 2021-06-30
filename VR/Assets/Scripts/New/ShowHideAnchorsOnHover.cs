using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideAnchorsOnHover : MonoBehaviour
{
    private bool hovering;
    private bool dragging;

    GameObject topAnchor;
    GameObject rightAnchor;
    GameObject bottomAnchor;
    GameObject leftAnchor;
    //GameObject centerAnchor;

    void Start()
    {
        topAnchor = this.transform.GetChild(0).gameObject;
        rightAnchor = this.transform.GetChild(1).gameObject;
        bottomAnchor = this.transform.GetChild(2).gameObject;
        leftAnchor = this.transform.GetChild(3).gameObject;
        //centerAnchor = this.transform.GetChild(4).gameObject;

        HideAnchors();
    }

    void Update()
    {
    }

    private void OnMouseOver()
    {
        hovering = true;
        ShowAnchors();
    }

    private void OnMouseExit()
    {
        hovering = false;
        HideAnchors();
    }

    private void ShowAnchors()
    {
        topAnchor.SetActive(true);
        rightAnchor.SetActive(true);
        bottomAnchor.SetActive(true);
        leftAnchor.SetActive(true);
        //centerAnchor.SetActive(true);
    }

    private void HideAnchors()
    {
        topAnchor.SetActive(false);
        rightAnchor.SetActive(false);
        bottomAnchor.SetActive(false);
        leftAnchor.SetActive(false);
        //centerAnchor.SetActive(false);
    }

}
