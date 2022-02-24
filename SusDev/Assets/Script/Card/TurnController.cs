using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public GameObject Zone;
    public GameObject TableArea;
    public GameObject HandArea;

    public PlayerDesk playerDesk;
    public GridTesting grid;



    void Start()
    {
        Zone.SetActive(true);
        TableArea.SetActive(false);
        HandArea.SetActive(true);

    }

    public void startT()
    {
        playerDesk.startTurn();
        StartCoroutine(randomT());
    }

    IEnumerator randomT()
    {

        yield return new WaitForSeconds(5);
        TableArea.SetActive(true);
        playerDesk.randomCardTurn();
    }


    public void EndTurn()
    {
        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {
           
             
        }
        grid.InstantiateHouse();

    }




}
