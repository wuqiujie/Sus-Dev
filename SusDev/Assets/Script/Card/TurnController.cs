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
    public int environment_change;
    public int life_change;
    public int social_change;
    public int economics_change;

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
            
            environment_change += playerDesk.currentZone[i].GetComponent<ThisCard>().environment_index;
            life_change += playerDesk.currentZone[i].GetComponent<ThisCard>().life_expectancy_index;
            social_change += playerDesk.currentZone[i].GetComponent<ThisCard>().social_stability_index;
            economics_change += playerDesk.currentZone[i].GetComponent<ThisCard>().social_stability_index;
   
        }
        grid.InstantiateHouse();

    }




}
