using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TurnController : MonoBehaviour
{
    /**Zone**/
    public GameObject ZoneArea;
    public GameObject TableArea;
    public GameObject HandArea;
    public GameObject Collection;

    public PlayerDesk playerDesk;
    public GridTesting grid;

    /**index change**/
    public int environment_change;
    public int life_change;
    public int social_change;
    public int economics_change;
    public int budget_change;

    //long-term change
    public int LTEnvironment;
    public int LTLife;
    public int LTSocial;
    public int LTeconomics;
    public int LTBudget;

    public bool isMoved = false;
    public GameObject goalPanel;


    /**Collection**/
    public int[] CollectionID;
    public GameObject collectionItem;
    public GameObject currentPlayCard;
    public bool[] goalCollect;

    public void StartTurn()
    {
        ZoneArea.SetActive(true);
        TableArea.SetActive(false);
        HandArea.SetActive(true);

        /***if there are not 0 will be long term**/
        environment_change = 0;
        life_change = 0;
        social_change = 0;
        economics_change = 0;
        budget_change = 0;

        CollectionID = new int[10];
        goalCollect = new bool[17];
      
        playerDesk.StartTurn();
        collectionItem.gameObject.GetComponent<CollectionItem>().setcollectionNum(0);

        isMoved = false;

        for (int i = 0; i < goalPanel.transform.childCount; i++)
        {
            goalPanel.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

  
    public void ShowGoal()
    {
        currentPlayCard = ZoneArea.transform.GetChild(0).gameObject;
       
        int[] goals = currentPlayCard.GetComponent<ThisCard>().goals;

        for(int i = 0; i < goals.Length; i++)
        {
            goalPanel.transform.GetChild(goals[i]).gameObject.SetActive(true);
            goalCollect[goals[i]] = true;
        }
     

    }
    public void DestroyGoal()
    {
        for (int i = 0; i < goalPanel.transform.childCount; i++)
        {
            goalPanel.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    public void CalculateCard()
    {
      
            currentPlayCard = ZoneArea.transform.GetChild(0).gameObject;
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

            ZoneArea.transform.GetChild(0).gameObject.tag = "Calculated";

            StartCoroutine(MoveCard());
            StartCoroutine(DestroyCurrentCard(currentPlayCard));
        
    }

    IEnumerator DestroyCurrentCard(GameObject currentPlayCard)
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(currentPlayCard);
    }

    public int ZoneCount()
    {
        return ZoneArea.transform.childCount;
    }
    IEnumerator MoveCard()
    {
        float time = 0;
        Vector3 startPosition = ZoneArea.transform.GetChild(0).gameObject.transform.position; 
        Vector3 collectionPosition = Collection.transform.position;
        while (time < 1.3f)
        {
            ZoneArea.transform.GetChild(0).gameObject.transform.position = Vector3.Lerp(startPosition, collectionPosition, time / 1.3f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = collectionPosition;
        DestroyGoal();
    }

    public void CityChange()
    {
        grid.InstantiateHouse();
    }
  

    public void DestoryHandCard()
    {
        /**Destory**/
        foreach (Transform child in HandArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
   
    
    public bool CollectCard()
    {
        Vector3 collectionPosition = Collection.transform.position;
        
        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {
            Vector3 startPos = playerDesk.currentZone[i].transform.position;
            playerDesk.currentZone[i].transform.position = Vector3.Lerp(startPos, collectionPosition, Time.deltaTime*2f);
           
        }
      
        return collectionItem.gameObject.GetComponent<CollectionItem>().collectionNum == playerDesk.currentZone.Length;
       
    }
    
    


    
    public void DestroyCard()
    {
        /* for (int i = 0; i < playerDesk.currentZone.Length; i++)
         {
             Destroy(playerDesk.currentZone[i]);
         }
        */
        Destroy(ZoneArea.transform.GetChild(0));
    }

    





}
