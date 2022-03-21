using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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


    /**Collection**/
    public int[] CollectionID;
    public GameObject collectionItem;
    public GameObject currentPlayCard;

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

        playerDesk.StartTurn();
       // StartCoroutine(RandomTurn());
        collectionItem.gameObject.GetComponent<CollectionItem>().setcollectionNum(0);

        isMoved = false;
    }

    IEnumerator RandomTurn()
    {
        yield return new WaitForSeconds(2.5f);
        TableArea.SetActive(true);
        playerDesk.RandomCard();
    }

    public void CalculateCard()
    {
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

    }

    IEnumerator DestroyCurrentCard()
    {
        yield return new WaitForSeconds(2f);
        Destroy(currentPlayCard);
/*        Destroy(ZoneArea.transform.GetChild(0).gameObject);*/
    }

    public GameObject CurrentCard()
    {
        /*
        for (int i = 0; i < ZoneArea.transform.childCount; i++)
        {
           if (ZoneArea.transform.GetChild(i).tag != "Calculated")
            {
                currentPlayCard = ZoneArea.transform.GetChild(i).gameObject.GetComponent<ThisCard>();

            }
        }
        return currentPlayCard;
        */
        if (ZoneArea.transform.GetChild(0).tag != "Calculated")
        {
            return ZoneArea.transform.GetChild(0).gameObject;

        }
        return null;
       
    }
    public int ZoneCount()
    {
        return ZoneArea.transform.childCount;
    }
    IEnumerator MoveCard()
    {
        float time = 0;
        Vector3 startPosition = ZoneArea.transform.GetChild(0).gameObject.transform.position; ;
        Vector3 collectionPosition = Collection.transform.position;
        while (time < 1.0f)
        {
            ZoneArea.transform.GetChild(0).gameObject.transform.position = Vector3.Lerp(startPosition, collectionPosition, time / 1.0f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = collectionPosition;
    }
/*    public void MoveCard()
    {
        Debug.Log("fly");
        Vector3 collectionPosition = Collection.transform.position;
        Vector3 startPos = ZoneArea.transform.GetChild(0).gameObject.transform.position;
        ZoneArea.transform.GetChild(0).gameObject.transform.position = Vector3.Lerp(startPos, collectionPosition, Time.deltaTime * 5f);
       
    }*/
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
