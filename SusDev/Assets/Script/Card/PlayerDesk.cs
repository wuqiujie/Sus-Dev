using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesk : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();
    public GameObject[] currentDeck;

    public GameObject[] currentZone;

    public Card[] cards;

    public static int deskSize =8;

    public GameObject HandArea;
    public GameObject TableArea;
    public GameObject ZoneArea;

    public GameObject CardToHand;
    public GameObject CardToTable;

    void Start()
    { 

        for (int i = 0; i < deskSize; i++)
        {
            deck[i] = CardDataBase.cardList[Random.Range(0, 5)];
        }
       
    }

    public void StartTurn()
    {
       
        StartCoroutine(StartTurnByTime());
    }

    public void RrandomCard()
    {
         StartCoroutine(RandomCardByTime());
    }


    IEnumerator StartTurnByTime()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
          var myCard = Instantiate(CardToHand, transform.position, transform.rotation);
           HandArea = GameObject.Find("HandArea");
            myCard.transform.SetParent(HandArea.transform);   
        }
    }
    IEnumerator RandomCardByTime()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            var myCard = Instantiate(CardToHand, transform.position, transform.rotation);
            TableArea = GameObject.Find("TableArea");
            myCard.transform.SetParent(TableArea.transform);
        }
    }

    void Update()
    {
        staticDeck = deck;

        /** Draw Cards **/
        HandArea = GameObject.Find("HandArea");
        currentDeck = new GameObject[HandArea.transform.childCount];
        for (int i = 0; i < currentDeck.Length; i++)
        {
            currentDeck[i] = HandArea.transform.GetChild(i).gameObject;
        }

        /** Finish Choosing Cards **/
        if (HandArea.transform.childCount == 7)
        {
            TableArea.SetActive(false);
           
        }

        /** Play Card **/ 
        ZoneArea = GameObject.Find("ZoneArea");
        currentZone = new GameObject[ZoneArea.transform.childCount];

        
        for (int i = 0; i < currentZone.Length; i++)
        {
             currentZone[i] = ZoneArea.transform.GetChild(i).gameObject; 
        }

      

        



    }




}
