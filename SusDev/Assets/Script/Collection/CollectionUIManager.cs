using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CollectionUIManager : MonoBehaviour
{
    public GameObject[] cardSlot;
    public GameObject[] goalSlot;
    public GameObject[] turnPageButton;
    public TurnController turnController;
    public List<int> collectedCards;
    public GameObject desPanel;
    public GameObject[] relatedGoalSlot;
    public static List<Card> wholeCollection = ReadCSV._cardList;
    void Start()
    {
        collectedCards = new List<int>();
        Debug.Log("card amount: " + wholeCollection.Count);
        for (int i = 0 ; i < wholeCollection.Count; i++)
        {
            //check if all cards are loaded correctly
/*            Debug.Log("----------");
            Debug.Log("card id: " + wholeCollection[i].getID());
            Debug.Log("card name: " + wholeCollection[i].getCardName());
            Debug.Log("card description: " + wholeCollection[i].getCardDescription());*/

/*            string printGoals = "card related goals: ";
            foreach(var item in wholeCollection[i]._goals)
            {
                printGoals += item.ToString() + ",";
            }
            Debug.Log(printGoals);*/

        }
       
        
    }
    private void Update()
    {
        collectedCards = turnController.collectID;
        DisplayCards();
    }

    private void DisplayCards()
    {
        for (int i = 0; i < wholeCollection.Count; i++)
        {
            //display the card if it has already been played
            if (collectedCards.Contains(i))
            {
                cardSlot[i].GetComponent<Image>().sprite = wholeCollection[i].getCardSprite();
                cardSlot[i].GetComponent<Button>().enabled = true;
            }


        }
    }

    public void Search(int _searchgoal)
    {
        //Debug.Log("now displaying goal " + _searchgoal);
        for (int i = 0; i < wholeCollection.Count; i++)
        {
            if(Array.Exists(wholeCollection[i]._goals,element => element == _searchgoal))
            {
                cardSlot[i].gameObject.SetActive(true);
            }
            else
            {
                cardSlot[i].gameObject.SetActive(false);
            }
        }
        DisplayCards();
    }

    public void TurnPage(int _page)
    {
        Debug.Log("current page: " + _page);
        if(_page == 0)
        {
            for(int i = 0; i < 8; i++)
            {
                goalSlot[i].gameObject.SetActive(true);
                goalSlot[i + 8].gameObject.SetActive(false);
                var tempColor = goalSlot[i].transform.GetChild(0).GetComponent<Image>().color;
                tempColor.a = 0;
                goalSlot[i].transform.GetChild(0).GetComponent<Image>().color = tempColor;
               // Debug.Log("goal " + (i+1) + " alpha reset");
            }
            turnPageButton[0].gameObject.SetActive(false);
            turnPageButton[1].gameObject.SetActive(true);
            goalSlot[0].GetComponent<Toggle>().isOn = true;
            goalSlot[0].GetComponent<Animator>().SetBool("Selected", true);

        }

        if (_page == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                goalSlot[i].gameObject.SetActive(false);
                goalSlot[i + 8].gameObject.SetActive(true);
                var tempColor = goalSlot[i].transform.GetChild(0).GetComponent<Image>().color;
                tempColor.a = 0;
                goalSlot[i+8].transform.GetChild(0).GetComponent<Image>().color = tempColor;
              //  Debug.Log("goal " + (i+9) + " alpha reset");
            }
            turnPageButton[1].gameObject.SetActive(false);
            turnPageButton[0].gameObject.SetActive(true);
            goalSlot[8].GetComponent<Toggle>().isOn = true;
            goalSlot[8].GetComponent<Animator>().SetBool("Selected", true);
        }

    }

    public void AddCard(int _cardid)
    {
        collectedCards.Add(_cardid);
        string result = "collected cards: ";
        foreach(var item in collectedCards)
        {
            result += item.ToString() + ",";
        }
        Debug.Log(result);
    }

    public void ShowDescription(int _cardid)
    {
        desPanel.gameObject.SetActive(true);
        desPanel.gameObject.transform.GetChild(1).GetComponent<Text>().text = wholeCollection[_cardid].getCardDescription();
        desPanel.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = wholeCollection[_cardid].getCardSprite();
        
        for(int i = 0; i < relatedGoalSlot.Length; i++)
        {
            relatedGoalSlot[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < wholeCollection[_cardid]._goals.Length; i++)
        {
            //Debug.Log(wholeCollection[_cardid]._goals[i]);
            relatedGoalSlot[wholeCollection[_cardid]._goals[i]-1].gameObject.SetActive(true);

        }

    }

    public void HideDescrptioin()
    {
        desPanel.gameObject.SetActive(false);
    }
}
