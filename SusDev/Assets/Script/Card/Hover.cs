using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject card;
    public GameObject description;
    public Text descriptionText;
    public GameObject questioncard;
    public GameObject ltcard;
    public GameObject goal;

    private void Start()
    {
        card.GetComponent<Animator>().Play("idle");
        goal = GameObject.Find("GoalPanel");
    }
     public void OnPointerEnter(PointerEventData eventData)
    {
        card.GetComponent<Animator>().Play("HoverOn");
        DescriptionCard();
        QuestionCard();
        LTCard();
        ShowGoal();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        card.GetComponent<Animator>().Play("HoverOff");
        questioncard.SetActive(false);
        ltcard.SetActive(false);
        description.SetActive(false);
        DestroyGoal();
    }

    public void DescriptionCard()
    {
        description.SetActive(true);
        descriptionText.text = card.GetComponent<ThisCard>().card_description;
    }
    public void QuestionCard()
    {
        
        if(card.GetComponent<ThisCard>().questionMark)
        {
            questioncard.SetActive(true);
        }
        
    }

    public void LTCard()
    {

        if (card.GetComponent<ThisCard>().LTMark)
        {
            ltcard.SetActive(true);
        }

    }

    public void ShowGoal()
    {
       
        int[] goals = card.GetComponent<ThisCard>().goals;
        for (int i = 0; i < goals.Length; i++)
        {
            goal.transform.GetChild(goals[i]-1).gameObject.SetActive(true);
        }

    }



    public void DestroyGoal()
    {
        for (int i = 0; i < goal.transform.childCount; i++)
        {
            goal.transform.GetChild(i).gameObject.SetActive(false);

        }
    }
}
