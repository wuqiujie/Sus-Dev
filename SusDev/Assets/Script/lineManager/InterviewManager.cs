using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class InterviewManager : MonoBehaviour
{
    /*public string[] lines;*/
    public GameManager gameManager;
    private Queue<string> ssg;
    public TextAsset socialStabilityGood;
    private Queue<string> ssb;
    public TextAsset socialStabilityBad;
    private Queue<string> leg;
    public TextAsset lifeExpectencyGood;
    private Queue<string> leb;
    public TextAsset lifeExpectencyBad;
    private Queue<string> epg;
    public TextAsset ecnomicProsperityGood;
    private Queue<string> epb;
    public TextAsset ecnomicProsperityBad;
    private Queue<string> eg;
    public TextAsset environmentGood;
    private Queue<string> eb;
    public TextAsset environmentBad;

    public Text goodlines;
    public Text badlines;
    public GameObject interviewCanvas;
    // Start is called before the first frame update
    void Start()
    {
        ssg = new Queue<string>();
        ssb = new Queue<string>();
        leg = new Queue<string>();
        leb = new Queue<string>();
        epg = new Queue<string>();
        epb = new Queue<string>();
        eg = new Queue<string>();
        eb = new Queue<string>();
        PushLinesIntoQuene(socialStabilityGood, ssg);
        PushLinesIntoQuene(socialStabilityBad, ssb);
        PushLinesIntoQuene(lifeExpectencyGood, leg);
        PushLinesIntoQuene(lifeExpectencyBad, leb);
        PushLinesIntoQuene(ecnomicProsperityGood, epg);
        PushLinesIntoQuene(ecnomicProsperityBad, epb);
        PushLinesIntoQuene(environmentGood, eg);
        PushLinesIntoQuene(environmentBad, eb);
    }

    public void InitiateInterview()
    {
        interviewCanvas.SetActive(true);
        DisplayTextOnCanvas();
        EndInterview();
    }

    IEnumerator EndInterview()
    {
        yield return new WaitForSeconds(10);
        //call random incidents
        interviewCanvas.SetActive(false);
    }
    public void DisplayTextOnCanvas()
    {
        goodlines.text =  ChooseGoodLineToDisplay();
        badlines.text = ChooseBadLineToDisplay();
    }
    public string ChooseGoodLineToDisplay()
    {
        int i = Random.Range(0, 1);
        if(i == 0)
        {
            int max = gameManager.turnController.environment_change;
            max = Mathf.Max(max, gameManager.turnController.environment_change);
            max = Mathf.Max(max, gameManager.turnController.social_change);
            max = Mathf.Max(max, gameManager.turnController.life_change);
            if (max == gameManager.turnController.economics_change)
            {
                return epg.Dequeue();
            }
            if (max == gameManager.turnController.environment_change)
            {
                return eg.Dequeue();
            }
            if (max == gameManager.turnController.social_change)
            {
                return ssg.Dequeue();
            }
            if (max == gameManager.turnController.life_change)
            {
                return leg.Dequeue();
            }
            return "";
        }
        else
        {
            return "";
        }
    }
    public string ChooseBadLineToDisplay()
    {
        int min = gameManager.total_economics;
        min = Mathf.Min(min, gameManager.total_social_stability);
        min = Mathf.Min(min, gameManager.total_life);
        min = Mathf.Min(min, gameManager.total_environment);
        if(min == gameManager.total_economics)
        {
            return epb.Dequeue();
        }
        if(min == gameManager.total_social_stability)
        {
            return ssb.Dequeue();
        }
        if(min == gameManager.total_life)
        {
            return leb.Dequeue();
        }
        if(min == gameManager.total_environment)
        {
            return eb.Dequeue();
        }
        return "";
    }
    public void PushLinesIntoQuene(TextAsset textAsset, Queue<string> linesQueue)
    {
        StringReader stringreader = new StringReader(textAsset.text);
        string line = stringreader.ReadLine();
        while(line != null)
        {
            linesQueue.Enqueue(line);
            line = stringreader.ReadLine();
        }
    }
}
