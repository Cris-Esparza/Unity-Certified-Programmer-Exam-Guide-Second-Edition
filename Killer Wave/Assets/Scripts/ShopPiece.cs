using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPiece : MonoBehaviour
{
    [SerializeField]
    SOShopSelection shopSelection;
    public SOShopSelection ShopSelection
    {
        get { return shopSelection; }
        set { shopSelection = value; }
    }

    void Awake()
    {
        // update image of shop button
        if (transform.GetChild(3).GetComponent<Image>() != null)
        {
            transform.GetChild(3).GetComponent<Image>().sprite = shopSelection.icon;
        }

        // set text of button item
        if (transform.Find("itemText"))
        {
            GetComponentInChildren<Text>().text = shopSelection.cost.ToString();
        }
    }
}
