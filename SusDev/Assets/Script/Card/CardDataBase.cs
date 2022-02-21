using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "0", "0", -1, -1, -1, Resources.Load<Sprite>("0")));
        cardList.Add(new Card(1, "1", "1", -1, -1, -1, Resources.Load<Sprite>("1")));
        cardList.Add(new Card(2, "2", "2", -1, -1, -1, Resources.Load<Sprite>("2")));
        cardList.Add(new Card(3, "3", "3", -1, -1, -1, Resources.Load<Sprite>("3")));
        cardList.Add(new Card(4, "4", "4", -1, -1, -1, Resources.Load<Sprite>("4")));
        cardList.Add(new Card(5, "5", "5", -1, -1, -1, Resources.Load<Sprite>("5")));
    }
    public Card getCard(int i)
    {
        return cardList[i];
    }

}
