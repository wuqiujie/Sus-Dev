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

    /**Turn Info**/
    public bool isYourTurn;
    public int yourTurn;
    public Text turnText;

    /**Mana**/
    public int maxMana;
    public int currentMana;
    public Text manaText;
    public static bool startTurn;

    /**Collection**/
    public int[] CollectionID;

    void Start()
    {

        ZoneArea.SetActive(true);
        TableArea.SetActive(false);
        HandArea.SetActive(true);

        isYourTurn = true;
        yourTurn = 1;

        maxMana = 1;
        currentMana = 1;
        startTurn = false;
        CollectionID = new int[10];

    }

    

    public void StartGame()
    {
        turnText.text = "New Game";
    }

    public void StartTurn()
    {
        turnText.text = "Turn: " + yourTurn;
        playerDesk.StartTurn();
        StartCoroutine(RandomTurn());
    }

    IEnumerator RandomTurn()
    {
        yield return new WaitForSeconds(2.5f);
        TableArea.SetActive(true);
        playerDesk.RrandomCard();
    }


    public void CalculateCard()
    {
        turnText.text = "Turn: " + yourTurn;
        /** Index Change **/
        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {
            
            environment_change += playerDesk.currentZone[i].GetComponent<ThisCard>().environment_index;
            life_change += playerDesk.currentZone[i].GetComponent<ThisCard>().life_expectancy_index;
            social_change += playerDesk.currentZone[i].GetComponent<ThisCard>().social_stability_index;
            economics_change += playerDesk.currentZone[i].GetComponent<ThisCard>().social_stability_index;

            
            CollectionID[i] = playerDesk.currentZone[i].GetComponent<ThisCard>().id;

        }

        /** City Change **/
        grid.InstantiateHouse();

        /** Turn info **/
        isYourTurn = false;
        yourTurn++;


        /**Destory**/
        foreach (Transform child in HandArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }


    public void CollectCard()
    {
      //  int size = playerDesk.currentZone.Length;
     //   Vector3[] cardPostion =new Vector3[size];
        Vector3 collectionPosition = Collection.transform.position;

        for (int i = 0; i < playerDesk.currentZone.Length; i++)
        {

         
        }
           
    }

    void MoveToCollection(GameObject gameObject)   
    {
        float step = 0.5f * Time.deltaTime;
        gameObject.transform.localPosition =
            new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 10, step), 
            Mathf.Lerp(gameObject.transform.localPosition.y, Collection.transform.localPosition.y, step),
            Mathf.Lerp(gameObject.transform.localPosition.z, Collection.transform.localPosition.z, step));

    }




}
