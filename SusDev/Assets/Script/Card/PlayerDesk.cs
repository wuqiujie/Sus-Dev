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

<<<<<<< Updated upstream
        for (int i = 0; i < deskSize; i++)
        {
            deck[i] = CardDataBase.cardList[Random.Range(0, 5)];
=======
    public void StartTurn()
    {
        deskSize = 6;
        count = 0;
        deck = new List<Card>();
        Shuffle();
        Debug.Log("Decksize is :" + DeckManager._deck.Count);
        for (int i = 0; i < deskSize; i++)
        {
            /*int cardSize = ReadCSV._cardList.Count;
            deck.Add(ReadCSV._cardList[i]);*/
            //new
            int cardSize = DeckManager._deck.Count;
            deck.Add(DeckManager._deck[i]);
>>>>>>> Stashed changes
        }
       
    }

    public void startTurn()
    {
<<<<<<< Updated upstream
        StartCoroutine(StartGame());
=======

        System.Random random = new System.Random();
        /*int cardSize = ReadCSV._cardList.Count;*/
        //new
        int cardSize = DeckManager._deck.Count;

        for (int j = 0; j < cardSize-1; j++)
        {
            int rd = random.Next(j, cardSize-1);
            /*Card temporary = ReadCSV._cardList[rd];
            ReadCSV._cardList[rd] = ReadCSV._cardList[j];
            ReadCSV._cardList[j] = temporary;*/
            //deck
            Card temporary = DeckManager._deck[rd];
            DeckManager._deck[rd] = DeckManager._deck[j];
            DeckManager._deck[j] = temporary;
        }
>>>>>>> Stashed changes
    }

    public void randomCardTurn()
    {
         StartCoroutine(RandomCard());
    }
    IEnumerator StartGame()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
           // Instantiate(CardToHand, transform.position, transform.rotation);
          var myCard = Instantiate(CardToHand, transform.position, transform.rotation);
           HandArea = GameObject.Find("HandArea");
            myCard.transform.SetParent(HandArea.transform);
         
                
        }
       
    }
    IEnumerator RandomCard()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
           //  Instantiate(CardToTable, transform.position, transform.rotation);
            var myCard = Instantiate(CardToHand, transform.position, transform.rotation);
            TableArea = GameObject.Find("TableArea");
            myCard.transform.SetParent(TableArea.transform);
        }
    }

    void Update()
    {
        staticDeck = deck;

        HandArea = GameObject.Find("HandArea");
        currentDeck = new GameObject[HandArea.transform.childCount];
        for (int i = 0; i < currentDeck.Length; i++)
        {
            currentDeck[i] = HandArea.transform.GetChild(i).gameObject;
        }

        if (HandArea.transform.childCount == 7)
        {
            TableArea.SetActive(false);
           
        }



        ZoneArea = GameObject.Find("ZoneArea");
        currentZone = new GameObject[ZoneArea.transform.childCount];

        
        for (int i = 0; i < currentZone.Length; i++)
        {
             currentZone[i] = ZoneArea.transform.GetChild(i).gameObject;
           
        }

      

        



    }




}
