using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card 
{
    /***Card***/
    public int id;
    public string card_name;
    public string card_description;
    public Sprite card_sprite;
    public int cost;
    public int type;
    public int construction;


    /*** Affect***/
    public float environment_index;
    public float life_expectancy_index;
    public float social_stability_index;
    public float economics_index;

    
    public Card()
    {

    }
    public Card(int Id, string Card_name, string Card_description, 
        int Cost, int Type, int Construction,
         Sprite Card_sprite)
    {
        id = Id;
        card_name = Card_name;
        card_description = Card_description;
        cost = Cost;
        type = Type;
        construction = Construction;
        card_sprite = Card_sprite;

    }

    public int getID()
    {
        return id;
    }

    public string getCardName()
    {
        return card_name;
    }

    public string getCardDescription()
    {
        return card_description;
    }
    public int getCost()
    {
        return cost;
    }

    public int getType()
    {
        return type;
    }
    public int getConstruction()
    {
        return construction;
    }

    public Sprite getCardSprite()
    {
        return card_sprite;
    }
}
