using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectButton : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject CollectionCanvas;

    public void clickCollectButton()
    {
        MainCanvas.SetActive(false);
        CollectionCanvas.SetActive(true);
    }

    public void clickBack()
    {
        MainCanvas.SetActive(true);
        CollectionCanvas.SetActive(false);
    }

}
