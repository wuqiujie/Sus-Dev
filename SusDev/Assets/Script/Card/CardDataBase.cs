using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
   // int Id, string Card_name, string Card_description, int Cost, int Type, int Construction, Sprite Card_sprite, int Environment, int Life_expectancy,  int Social_stability, int Economics
    //0:environment 1:life 2:social 3:economics
    private void Awake()
    {
        cardList.Add(new Card(0, "advance_gas_treatment", "0", 1, 0, -1, Resources.Load<Sprite>("advance_gas_treatment"), 1, 0, 0, 0));
        cardList.Add(new Card(1, "bike_network", "1", 1, 0, -1, Resources.Load<Sprite>("bike_network"), 1, 0, 0, 0));
        cardList.Add(new Card(2, "compulsory_education", "2", 2, 2, -1, Resources.Load<Sprite>("compulsory_education"), 0, 0, 2, 0));
        cardList.Add(new Card(3, "equal_payment", "3", 0, 2, -1, Resources.Load<Sprite>("equal_payment"), 0, 0, 1, 0));
        cardList.Add(new Card(4, "food_stamps", "4", 1, 2, -1, Resources.Load<Sprite>("food_stamps"), 0, 0, 1, 0));
        cardList.Add(new Card(5, "free_vaccine", "5", 1, 1, -1, Resources.Load<Sprite>("free_vaccine"), 0, 1, 0, 0));
        cardList.Add(new Card(6, "heart_disease", "6", 1, 1, -1, Resources.Load<Sprite>("heart_disease"), 0, 1, 0, 0));
        cardList.Add(new Card(7, "highway_construction", "7", 2, 3, -1, Resources.Load<Sprite>("highway_construction"), 0, 0, 1, 1));
        cardList.Add(new Card(8, "mental_therapy", "8", 1, 1, -1, Resources.Load<Sprite>("mental_therapy"), 0, 1, 0, 0));
        cardList.Add(new Card(9, "minimum_wage", "9", 2, 2, -1, Resources.Load<Sprite>("mental_therapy"), 0, 0, 1, 1));
        cardList.Add(new Card(10, "more_university", "10", 2, 3, -1, Resources.Load<Sprite>("more_university"), 0, 0, 0, 2));
        cardList.Add(new Card(11, "paid_maternity", "11", 1, 2, -1, Resources.Load<Sprite>("paid_maternity"), 0, 0, 1, -1));
        cardList.Add(new Card(12, "public_hospital", "12", 2, 1, -1, Resources.Load<Sprite>("paid_maternity"), 0, 1, 1, 0));
        cardList.Add(new Card(13, "public_nursing", "13", 1, 1, -1, Resources.Load<Sprite>("public_nursing"), 0, 1, 0, 0));
        cardList.Add(new Card(14, "public_school", "14", 2, 2, -1, Resources.Load<Sprite>("public_school"), 0, 0, 2, 1));
        cardList.Add(new Card(15, "railway_station", "15", 2, 3, -1, Resources.Load<Sprite>("railway_station"), 0, 0, 1, 1));
        cardList.Add(new Card(16, "sewage_treament", "16", 3, 0, -1, Resources.Load<Sprite>("sewage_treament"), 1, 2, 0, 0));
        cardList.Add(new Card(17, "small_business", "17", 1, 3, -1, Resources.Load<Sprite>("small_business"), 0, 0, 0, 1));
        cardList.Add(new Card(18, "social_securities", "18", 0, 2, -1, Resources.Load<Sprite>("social_securities"), 0, 0, 1, 0));
        cardList.Add(new Card(19, "solar_energy_power_plant", "19", 3, 0, -1, Resources.Load<Sprite>("solar_energy_power_plant"), 1, 1, 0, 0));
        cardList.Add(new Card(20, "subway", "20", 4, 2, -1, Resources.Load<Sprite>("subway"), 1, 0, 1, 1));
        cardList.Add(new Card(21, "support_women_entrepreneurs", "21", 1, 2, -1, Resources.Load<Sprite>("support_women_entrepreneurs"), 0, 0, 1, 1));
        cardList.Add(new Card(22, "tech_sector", "22", 2, 3, -1, Resources.Load<Sprite>("tech_sector"), 0, 0, 0, 2));
        cardList.Add(new Card(23, "tech_talent", "23", 2, 3, -1, Resources.Load<Sprite>("tech_talent"), 0, 0, 0, 2));
        cardList.Add(new Card(24, "unemployment_benefits_scheme", "24", 1, 2, -1, Resources.Load<Sprite>("unemployment_benefits_scheme"), 0, 0, 1, 0));
        cardList.Add(new Card(25, "wind_energy_power_plants", "25", 3, 0, -1, Resources.Load<Sprite>("wind_energy_power_plants"), 2, 1, 0, 0));
        cardList.Add(new Card(26, "working_condition", "26", 2, 0, -1, Resources.Load<Sprite>("working_condition"), 0, 0, 1, -1));
    }
    public Card getCard(int i)
    {
        return cardList[i];
    }

}
