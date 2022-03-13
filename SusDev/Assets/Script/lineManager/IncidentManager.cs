using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class IncidentManager : MonoBehaviour
{
    public GameManager gameManager;
    private Queue<string> environmentQ;
    private Queue<string> environmentHQ;
    public TextAsset environment;
    private Queue<string> socialQ;
    private Queue<string> socialHQ;
    public TextAsset social;
    private Queue<string> economicQ;
    private Queue<string> economicHQ;
    public TextAsset economic;
    private Queue<string> lifeQ;
    private Queue<string> lifeHQ;
    public TextAsset life;

    private int min;
    private Index index;

    public Text header;
    public Text body;
    public GameObject incidentCanvas;
    public bool called;
    public bool anothercalled;
    // Start is called before the first frame update
    void Start()
    {
        environmentQ = new Queue<string>();
        environmentHQ = new Queue<string>();
        socialQ = new Queue<string>();
        socialHQ = new Queue<string>();
        economicQ = new Queue<string>();
        economicHQ = new Queue<string>();
        lifeQ = new Queue<string>();
        lifeHQ = new Queue<string>();
        PushLinesIntoQuene(environment, environmentQ, false);
        PushLinesIntoQuene(environment, environmentHQ, true);
        PushLinesIntoQuene(environment, socialQ, false);
        PushLinesIntoQuene(environment, socialHQ, true);
        PushLinesIntoQuene(environment, economicQ, false);
        PushLinesIntoQuene(environment, economicHQ, true);
        PushLinesIntoQuene(environment, lifeQ, false);
        PushLinesIntoQuene(environment, lifeHQ, true);
    }
    public void InitiateIncident()
    {
        called = false;
        anothercalled = false;
        FindMinIndex();
        FindMaxIndex();
        int i = Random.Range(1, 10);
        if(i >= 10 - min)
        {
            called = true;
            return;
        }
        else
        {
            incidentCanvas.SetActive(true);
            ChooseRandomIncident();
            DealingEffect();
            StartCoroutine(EndIncident());
        }

    }
    private void FindMinIndex()
    {
        min = gameManager.total_economics;
        min = Mathf.Min(min, gameManager.total_social_stability);
        min = Mathf.Min(min, gameManager.total_life);
        min = Mathf.Min(min, gameManager.total_environment);
    }
    private void FindMaxIndex()
    {
        int max = gameManager.total_environment;
        max = Mathf.Max(max, gameManager.total_economics);
        max = Mathf.Max(max, gameManager.total_life);
        max = Mathf.Max(max, gameManager.total_social_stability);
        if (max == gameManager.total_economics)
        {
            index = Index.EconomicProsperity;
        }
        if (max == gameManager.total_environment)
        {
            index = Index.Environment;
        }
        if (max == gameManager.total_social_stability)
        {
            index = Index.SocialStability;
        }
        if (max == gameManager.total_life)
        {
            index = Index.LifeExpectency;
        }
    }

    private void ChooseRandomIncident()
    {
        if (min == gameManager.total_economics)
        {
            header.text = economicHQ.Dequeue();
            body.text = economicQ.Dequeue();
        }
        if (min == gameManager.total_social_stability)
        {
            header.text = socialHQ.Dequeue();
            body.text = socialQ.Dequeue();
        }
        if (min == gameManager.total_life)
        {
            header.text = lifeHQ.Dequeue();
            body.text = lifeQ.Dequeue();
        }
        if (min == gameManager.total_environment)
        {
            header.text = environmentHQ.Dequeue();
            body.text = environmentQ.Dequeue();
        }
    }
    private void DealingEffect()
    {
        if(!called)
        {
            switch (index)
            {
                case Index.Environment:
                    body.text += "\n" + "Your environment index -1";
                    gameManager.total_environment -= 1;
                   // EndIncident();
                    /*called = true;*/
                    break;
                case Index.LifeExpectency:
                    body.text += "\n" + "Your life expectancy index -1";
                    gameManager.total_life -= 1;
                   // EndIncident();
                    /*called = true;*/
                    break;
                case Index.EconomicProsperity:
                    body.text += "\n" + "Your economic prosperity index -1";
                    gameManager.total_economics -= 1;
                    /*called = true;*/
                   // EndIncident();
                    break;
                case Index.SocialStability:
                    body.text += "\n" + "Your social stability index -1";
                    gameManager.total_social_stability -= 1;
                  //  EndIncident();
                    /*called = true;*/
                    break;
            }
        }
    }
    IEnumerator EndIncident()
    {
        yield return new WaitForSeconds(1);
        called = true;
        incidentCanvas.SetActive(false);
      
    }
    private void PushLinesIntoQuene(TextAsset textAsset, Queue<string> linesQueue, bool isHead)
    {
        StringReader stringreader = new StringReader(textAsset.text);
        if(isHead)
        {
            string line = stringreader.ReadLine();
            while (line != null)
            {
                linesQueue.Enqueue(line);
                stringreader.ReadLine();
                line = stringreader.ReadLine();
            }
        }
        else
        {
            stringreader.ReadLine();
            string line = stringreader.ReadLine();
            while (line != null)
            {
                linesQueue.Enqueue(line);
                stringreader.ReadLine();
                line = stringreader.ReadLine();
            }
        }
    }
    enum Index
    {
        Environment,
        LifeExpectency,
        EconomicProsperity,
        SocialStability
    }
}
