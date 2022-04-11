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
    public CityManager grid;

/*    Camera zoom effect*/
    public CameraController cc;

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

    public GameObject hangtag_go;
    /**Collection**/
    public List<int> collectID;

    //public GameObject collectionItem;
    public GameObject currentPlayCard;
    public bool[] goalCollect;

    public void StartTurn()
    {
        cc.LookAtPos();
        ZoneArea.SetActive(true);
        TableArea.SetActive(false);
        HandArea.SetActive(true);

        /***if there are not 0 will be long term**/
        environment_change = 0;
        life_change = 0;
        social_change = 0;
        economics_change = 0;
        budget_change = 0;

        collectID = new List<int>();
        goalCollect = new bool[17];
      
        playerDesk.StartTurn();
        // collectionItem.gameObject.GetComponent<CollectionItem>().setcollectionNum(0);
        currentPlayCard = new GameObject();
        isMoved = false;

        for (int i = 0; i < goalPanel.transform.childCount; i++)
        {
            goalPanel.transform.GetChild(i).gameObject.SetActive(false);

        }
        StartCoroutine(HangtagDown());
    }

  
    public void ShowGoal()
    {
        currentPlayCard = ZoneArea.transform.GetChild(0).gameObject;
        if (currentPlayCard.GetComponent<ThisCard>().goals[0] != -1)
        {
            int[] goals = currentPlayCard.GetComponent<ThisCard>().goals;

            for (int i = 0; i < goals.Length; i++)
            {
                goalPanel.transform.GetChild(goals[i] - 1).gameObject.SetActive(true);
                goalCollect[goals[i] - 1] = true;
            }

        }
    }
    public void DestroyGoal()
    {
        for (int i = 0; i < goalPanel.transform.childCount; i++)
        {
            goalPanel.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    IEnumerator HangtagDown()
    {
        float time = 0;
        
        Vector3 startPosition = new Vector3(1120, 2760, 0);
        Vector3 endPosition = new Vector3(1120, 1570, 0);
        while (time < 2f)
        {
            hangtag_go.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(HangtagUp());
    }

    IEnumerator HangtagUp()
    {
        float time = 0;
        Vector3 endPosition = new Vector3(1120, 2760, 0);
        Vector3 startPosition = new Vector3(1120, 1570, 0);
        while (time < 2f)
        {
            hangtag_go.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
    }
    public void CalculateCard()
    {

            currentPlayCard = CurrentCard();
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

            collectID.Add(currentPlayCard.GetComponent<ThisCard>().id);
            StartCoroutine(MoveCard(currentPlayCard));
            StartCoroutine(DestroyCurrentCard(currentPlayCard));
        
    }
    public GameObject CurrentCard()
    {
       
        if (ZoneArea.transform.GetChild(0).tag != "Calculated")
        {
            return ZoneArea.transform.GetChild(0).gameObject;

        }
        return null;

    }
    IEnumerator DestroyCurrentCard(GameObject currentPlayCard)
    {
        yield return new WaitForSeconds(1f);
        Destroy(currentPlayCard);
    }

    public int ZoneCount()
    {
        return ZoneArea.transform.childCount;
    }
    IEnumerator MoveCard(GameObject cg)
    {
        float time = 0;
        Vector3 startPosition = cg.transform.position; 
        Vector3 collectionPosition = Collection.transform.position;
        while (time < 1f)
        {
            cg.gameObject.transform.position = Vector3.Lerp(startPosition, collectionPosition, time / 1f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = collectionPosition;
        DestroyGoal();
    }

    public void CityChange()
    {
        grid.InstantiateConstruction(1, 1, 1);
        grid.InstantiateConstruction(0, 0, 3);
        cc.LookAtPos();
    }
  

    public void DestoryHandCard()
    {
        /**Destory**/
        foreach (Transform child in HandArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    
  
    public void DestroyCard()
    {
      
        Destroy(ZoneArea.transform.GetChild(0));
    }

    





}
