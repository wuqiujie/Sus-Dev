using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject card;
    
    private void Start()
    {
        card.GetComponent<Animator>().Play("idle");
    }
     public void OnPointerEnter(PointerEventData eventData)
    {
        card.GetComponent<Animator>().Play("HoverOn");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        card.GetComponent<Animator>().Play("HoverOff");
    }
}
