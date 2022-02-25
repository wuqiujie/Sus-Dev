using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public Card thisCard = new Card();
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

    /*** Affect***/
    public int environment_index;
    public int life_expectancy_index;
    public int social_stability_index;
    public int economics_index;

    public int numOfCandsInDesk;


    void Start()
    {
        thisCard = CardDataBase.cardList[thisCardID];
        numOfCandsInDesk = PlayerDesk.deskSize;

    }

    void Update()
    {
       
        /***Card Info ***/
        id = thisCard.getID();
        card_name = thisCard.getCardName();
        card_description = thisCard.getCardDescription();
        cost = thisCard.getCost();
        type = thisCard.getType();
        construction = thisCard.getConstruction();
        card_sprite = thisCard.getCardSprite();
        card_image.sprite = card_sprite;

        environment_index = thisCard.getEnvironment();
        life_expectancy_index = thisCard.getLife_expectancy();
        social_stability_index = thisCard.getSocial_stability();
        economics_index = thisCard.getEconomics();

        if (this.tag == "Clone")
        {
            thisCard = PlayerDesk.staticDeck[numOfCandsInDesk - 1];
            numOfCandsInDesk -= 1;
            PlayerDesk.deskSize -= 1;
            this.tag = "Untagged";
        }
    }   

}
