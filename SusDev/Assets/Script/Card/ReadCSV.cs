using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReadCSV : MonoBehaviour
{
    public TextAsset _cardDB;
    public TextAsset _scardDB;
    public static List<Card> _cardList = new List<Card>();
    private void Awake()
    {
        _cardDB = Resources.Load<TextAsset>("CardDatabase");
        _scardDB = Resources.Load<TextAsset>("CardDatabaseSpecial");
    }
    // Start is called before the first frame update
    void Start()
    {
        Read();
        ReadSpecial();
    }
    public void Read()
    {
        string[] data = _cardDB.text.Split(new string[] { ",", "\n" },StringSplitOptions.None);
        int rows = data.Length / 11 - 1;
        for(int i = 0; i < rows; i++)
        {
            int id = int.Parse(data[11 * (i + 1)]);
            string Card_name = data[11 * (i + 1) + 1];
            string Card_description = data[11 * (i + 1) + 2];
            int Cost = int.Parse(data[11 * (i + 1) + 3]);
            int Type = int.Parse(data[11 * (i + 1) + 4]);
            int Construction = int.Parse(data[11 * (i + 1) + 5]);
            string Card_sprite = data[11 * (i + 1) + 6];
            int Environment = int.Parse(data[11 * (i + 1) + 7]);
            int Life_expectancy = int.Parse(data[11 * (i + 1) + 8]);
            int Social_stability = int.Parse(data[11 * (i + 1) + 9]);
            int Economics = int.Parse(data[11 * (i + 1) + 10]);
            _cardList.Add(new Card(id, Card_name, Card_description, Cost, Type, Construction, Resources.Load<Sprite>(Card_sprite), Environment, Life_expectancy, Social_stability, Economics));
        }
    }
    public void ReadSpecial()
    {
        string[] data = _scardDB.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int rows = data.Length / 21 - 1;
        for (int i = 0; i < rows; i++)
        {
            int id = int.Parse(data[21 * (i + 1)]);
            string Card_name = data[21 * (i + 1) + 1];
            string Card_description = data[21 * (i + 1) + 2];
            int Cost = int.Parse(data[21 * (i + 1) + 3]);
            int Type = int.Parse(data[21 * (i + 1) + 4]);
            int Construction = int.Parse(data[21 * (i + 1) + 5]);
            string Card_sprite = data[21 * (i + 1) + 6];
            int Environment = int.Parse(data[21 * (i + 1) + 7]);
            int Life_expectancy = int.Parse(data[21 * (i + 1) + 8]);
            int Social_stability = int.Parse(data[21 * (i + 1) + 9]);
            int Economics = int.Parse(data[21 * (i + 1) + 10]);

            int conditionIndex = int.Parse(data[21 * (i + 1) + 11]);
            int conditionThresh = int.Parse(data[21 * (i + 1) + 12]);
            int changeIndex = int.Parse(data[21 * (i + 1) + 13]);
            int conditionTrue = int.Parse(data[21 * (i + 1) + 14]);
            int conditionFalse = int.Parse(data[21 * (i + 1) + 15]);

            int LTenvironment = int.Parse(data[21 * (i + 1) + 16]);
            int LTlife = int.Parse(data[21 * (i + 1) + 17]);
            int LTsocial = int.Parse(data[21 * (i + 1) + 18]);
            int LTeconomic = int.Parse(data[21 * (i + 1) + 19]);
            int LTcost = int.Parse(data[21 * (i + 1) + 20]);
            SpecialCard sCard = new SpecialCard(id, Card_name, Card_description, Cost, Type, Construction, Resources.Load<Sprite>(Card_sprite), Environment, Life_expectancy, Social_stability, Economics
                , conditionIndex,  conditionThresh, changeIndex, conditionTrue, conditionFalse, LTenvironment, LTlife, LTsocial, LTeconomic, LTcost);
            _cardList.Add(sCard);
        }
    }
}
