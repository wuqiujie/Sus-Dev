using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesk : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int deskSize = 10;
    public int x;
    

    void Start()
    {
        x = 0;
        for (int i = 0; i < deskSize; i++)
        {
            x = Random.Range(0, 4);
            deck[i] = CardDataBase.cardList[x];
        }
    }


    public void Shuffle()
    {
        for(int i =0 ; i<deskSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(1, deskSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

    }

}
