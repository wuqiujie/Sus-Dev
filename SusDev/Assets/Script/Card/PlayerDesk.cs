using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesk : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Card container = new Card();
    public static List<Card> staticDeck = new List<Card>();
    public List<GameObject> currentDeck = new List<GameObject>();


    public static int deskSize =8;

    public GameObject HandArea;
    public GameObject CardToHand;
    public GameObject CardToTable;
    void Start()
    { 

        for (int i = 0; i < deskSize; i++)
        {
            deck[i] = CardDataBase.cardList[Random.Range(0, 5)];
        }
       
    }

    public void startTurn()
    {
        StartCoroutine(StartGame());
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
            Instantiate(CardToHand, transform.position, transform.rotation);

        }
       
    }
    IEnumerator RandomCard()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToTable, transform.position, transform.rotation);

        }
    }

    void Update()
    {
        staticDeck = deck;
       
    }

    public void Update_currentDesk()
    {
        HandArea = GameObject.Find("HandArea");
        for (int i = 0; i < 6; i++)
        {
           
            currentDeck.Add(HandArea.transform.GetChild(i).gameObject);
        }
        
    }


}
