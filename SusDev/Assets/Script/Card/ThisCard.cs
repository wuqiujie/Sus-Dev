using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();

    public int thisCardID;

    /***Card Info***/
    public int id;
    public string card_name;
    public string card_description;
    public Image card_image;
    public Sprite card_sprite;
    public int cost;
    public int type;
    public int construction;

    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisCardID];
    }

    void Update()
    {
        id = thisCard[0].getID();
        card_name = thisCard[0].getCardName();
        card_description = thisCard[0].getCardDescription();
        cost = thisCard[0].getCost();
        type = thisCard[0].getType();
        construction = thisCard[0].getConstruction();
        card_sprite = thisCard[0].getCardSprite();
        card_image.sprite = card_sprite;      
    }

}
