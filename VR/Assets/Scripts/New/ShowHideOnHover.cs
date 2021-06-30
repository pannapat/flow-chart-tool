using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOnHover : MonoBehaviour
{
    private void OnMouseOver()
    {
        this.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        this.gameObject.SetActive(false);
    }
}
