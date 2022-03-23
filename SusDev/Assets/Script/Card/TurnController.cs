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
<<<<<<< Updated upstream
=======
        /*    for(int i=0;i< ZoneArea.transform.childCount; i++)
            {
                if (ZoneArea.transform.GetChild(i).tag != "Calculated")
                {
                    currentPlayCard = ZoneArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>();

                    Destroy(ZoneArea.transform.GetChild(i).gameObject.GetComponent<Animator>());
                    Destroy(ZoneArea.transform.GetChild(i).gameObject.GetComponent<Hover>());
                    break;
                }
            }
          */

        currentPlayCard = CurrentCard();
        //new
        DeckManager.UpdateDeck(currentPlayCard.GetComponent<ThisCard>().id);

        Destroy(currentPlayCard.gameObject.GetComponent<Animator>());
        Destroy(currentPlayCard.gameObject.GetComponent<Hover>());
        Destroy(currentPlayCard.gameObject.GetComponent<CardDrag>());

        environment_change = currentPlayCard.GetComponent<ThisCard>().environment_index;
        life_change = currentPlayCard.GetComponent<ThisCard>().life_expectancy_index;
        social_change = currentPlayCard.GetComponent<ThisCard>().social_stability_index;
        economics_change = currentPlayCard.GetComponent<ThisCard>().economics_index;
        budget_change = currentPlayCard.GetComponent<ThisCard>().cost;

        LTEnvironment += currentPlayCard.GetComponent<ThisCard>().LTEnvironment;
        LTLife += currentPlayCard.GetComponent<ThisCard>().LTLife;
        LTSocial += currentPlayCard.GetComponent<ThisCard>().LTSocial;
        LTeconomics += currentPlayCard.GetComponent<ThisCard>().LTeconomics;
        LTBudget += currentPlayCard.GetComponent<ThisCard>().LTBudget;

        currentPlayCard.tag = "Calculated";


        /*        MoveCard();*/
        StartCoroutine(MoveCard());
        StartCoroutine(DestroyCurrentCard());
>>>>>>> Stashed changes

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
