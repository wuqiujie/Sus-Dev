using UnityEngine;
using UnityEngine.EventSystems;

public class IndexHover : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        tooltipImage.gameObject.SetActive(true);

    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        tooltipImage.gameObject.SetActive(false);
    }
    public void Output()
    {
        Debug.Log("Here");
    }
}