using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToTable : MonoBehaviour
{
    public GameObject Table;
    public GameObject randomCard;
    
    void Start()
    {
        Table = GameObject.Find("TableArea");
        randomCard.transform.SetParent(Table.transform);
        randomCard.transform.localScale = Vector3.one;
        randomCard.transform.position= new Vector3 (transform.position.x,transform.position.y,-48);
        randomCard.transform.eulerAngles = new Vector3(25, 0, 0);

    }
}
