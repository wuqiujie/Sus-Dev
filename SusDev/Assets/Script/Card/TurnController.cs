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

  


    /**Collection**/
    public int[] CollectionID;
    public GameObject collectionItem;
    


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

        CollectionID = new int[10];

        playerDesk.StartTurn();
       // StartCoroutine(RandomTurn());
        collectionItem.gameObject.GetComponent<CollectionItem>().setcollectionNum(0);
    }

    IEnumerator RandomTurn()
    {
        yield return new WaitForSeconds(2.5f);
        TableArea.SetActive(true);
        playerDesk.RandomCard();
    }

    
    public void CalculateCard()
    {
     
        
        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {
         
            environment_change += playerDesk.currentZone[i].GetComponent<ThisCard>().environment_index;
            life_change += playerDesk.currentZone[i].GetComponent<ThisCard>().life_expectancy_index;
            social_change += playerDesk.currentZone[i].GetComponent<ThisCard>().social_stability_index;
            economics_change += playerDesk.currentZone[i].GetComponent<ThisCard>().economics_index;

            budget_change += playerDesk.currentZone[i].GetComponent<ThisCard>().cost;

            CollectionID[i] = playerDesk.currentZone[i].GetComponent<ThisCard>().id;
            
        }

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
        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {
            Destroy(playerDesk.currentZone[i]);
        }

    }







}
