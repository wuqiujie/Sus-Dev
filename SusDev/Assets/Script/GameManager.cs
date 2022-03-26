using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /**UI Bar**/
    public GameObject EnvBar;
    public GameObject LifeBar;
    public GameObject StableBar;
    public GameObject EconomyBar;
    public GameObject TurnBar;
    public GameObject BudgetBar;
   
    /**GameArea**/
    public GameObject HandArea;
    public GameObject IndexPanel;
    public GameObject IndicatorPanel;
    public GameObject CollectionButton;
    public GameObject gameStartButton;
    public GameObject playCardButton;

    /** Index **/
    [SerializeField]
    public static int total_environment;
    public static int total_life;
    public static int total_economics;
    public static int total_social_stability;

    /**Turn Info**/
    public int turnNum = 0;
    public static int budgetNum = 0;
    //public Text turnText;
    public TurnController turnController;

    /**incident and interview**/
    public IncidentManager incidentManager;
    public InterviewManager interviewManager;
    public bool interview_called;
    public bool incident_called;

    /**Tutorial**/
    public GameObject TutorialArea;
    public TutorialController tutorial;
    public GameObject tutorialButton;

    public GameState state;




    public enum GameState
    {
        GameStart,
        Tutorial,
        TurnStart,
        PlayCard,
        JudgeBudget,
        Calculate,
        CollectCard,
        interview,
        incident,
        TurnEnd,
        GameEnd
    }



    void Start()
    {
        state = GameState.GameStart;
        HandArea = GameObject.Find("HandArea");
        gameStartButton.SetActive(false);
        total_environment = 1;
        total_life = 1;
        total_economics = 1;
        total_social_stability = 2;
    }

    void Update()
    {
       Debug.Log("state: " + state);

       // turnText.text = "Turn: " + turnNum;

        if (state == GameState.GameStart)
        {
            Game_Start();
            gameStartButton.SetActive(true);
        }
        if(state == GameState.Tutorial)
        {
            Tutorial();
        }
        if (state == GameState.TurnStart)
        {
            Start_Turn();
        }

        if (state == GameState.PlayCard)
        {
            Play_Card();
         
        }

        if (state == GameState.JudgeBudget)
        {
            JudgeBudgetCard();
        }
        
        if (state == GameState.Calculate)
        {
      
            CalculateCard();
        }
        
     
        if (state == GameState.CollectCard)
        {
            Collect_Card();
        }

        if (state == GameState.interview && !interview_called)
        {
            Interview();
            interview_called = true;
        }

        if (state == GameState.incident && !incident_called)
        {
            Incident();
            incident_called = true;
        }

        if (state == GameState.TurnEnd)
        {
            Turn_End();
        }

        if (state == GameState.GameEnd)
        {
            Game_End();
        }

        UI_Update();
       

    }


    public void Game_Start()
    {

      //  turnText.text = "New Game";

    }
    public void Game_Start_Button()
    {
       
        gameStartButton.SetActive(false);
        state = GameState.Tutorial;
        
        /*
        state = GameState.TurnStart;
        turnController.ZoneArea.SetActive(true);
        turnController.HandArea.SetActive(true);
        */

}
public void Tutorial()
    {
       // turnText.text = "Tutorial Time";
        IndexPanel.SetActive(false);
        IndicatorPanel.SetActive(false);
        CollectionButton.SetActive(false);
        HandArea.SetActive(false);

        TutorialArea.SetActive(true);
        tutorialButton.SetActive(false);
        if(tutorial.index == 11)
        {
           // HandArea.SetActive(true);
        }
        if (tutorial.index >= 17)
        {
            tutorialButton.SetActive(true);
        }
    }

    public void Tutorial_Button()
    {
        state = GameState.TurnStart;
        
        turnController.ZoneArea.SetActive(true);
        turnController.HandArea.SetActive(true);

    }

    public void Start_Turn()
    {
        IndexPanel.SetActive(true);
        IndicatorPanel.SetActive(true);
        CollectionButton.SetActive(true);
        HandArea.SetActive(true);
        TutorialArea.SetActive(false);


        LT_Update();

        turnNum++;
        TurnBar.GetComponent<Bar>().env.ChangeEnv(turnNum);
       
        interview_called = false;
        incident_called = false;
        incidentManager.called = false;

        turnController.StartTurn();
        state = GameState.PlayCard;
    }
    public void Play_Card()
    {


        if (turnController.ZoneCount() > 0)
        {
            state = GameState.JudgeBudget;
        }
        else
        {
            state = GameState.PlayCard;
        }
    }

    public void JudgeBudgetCard()
    {
        // if (turnController.playerDesk.currentZone.Length > 0)
      
        if(turnController.ZoneCount() > 0 && turnController.ZoneArea.transform.GetChild(0).gameObject.tag!="Calculated")
        {
            if (budgetNum >= turnController.ZoneArea.transform.GetChild(0).gameObject.GetComponent<ThisCard>().cost)
            {
                state = GameState.Calculate;
            }
            else
            {
                HandArea = GameObject.Find("HandArea");
                turnController.ZoneArea.transform.GetChild(0).gameObject.transform.SetParent(HandArea.transform);
                state = GameState.PlayCard;
            }

        }
    }
    public void CalculateCard()
    {
        playCardButton.SetActive(true);

        turnController.ShowGoal();
        turnController.CalculateCard();
        UI_Update();
        Data_Update();
        turnController.CityChange();
        state = GameState.PlayCard;
      
    }
    
  
    public void Play_Card_Button()
    {
        state = GameState.CollectCard;
    }

    
    
    public void Collect_Card()
    {
        playCardButton.SetActive(false);
        turnController.DestoryHandCard();
        state = GameState.interview;
    }
   


    public void Interview()
    {   
        interviewManager.InitiateInterview();
    }
    public void EndInterviewButton()
    {
        interviewManager.EndInterview();
        state = GameState.incident;
    }
    public void Incident()
    {
        incidentManager.InitiateIncident();
    }
    
    public void EndIncidentButton()
    {
        incidentManager.EndIncident();
        state = GameState.TurnEnd;
    }

    public void Turn_End()
    {
        state = GameState.TurnStart;
    }

    public void Game_End()
    {

    }

    public void UI_Update()
    {
        EnvBar.GetComponent<Bar>().env.envAmount = total_environment;
        LifeBar.GetComponent<Bar>().env.envAmount = total_life;
        StableBar.GetComponent<Bar>().env.envAmount = total_social_stability;
        EconomyBar.GetComponent<Bar>().env.envAmount = total_economics;

        BudgetBar.GetComponent<Bar>().env.envAmount = budgetNum;
    }
    public void Data_Update()
    {
        total_economics += turnController.economics_change;
        total_environment += turnController.environment_change;
        total_life += turnController.life_change;
        total_social_stability += turnController.social_change;

        budgetNum -= turnController.budget_change;
    }

    public void LT_Update()
    {
        budgetNum += 3 + turnController.LTBudget;
        total_economics += turnController.LTeconomics;
        total_environment += turnController.LTEnvironment;
        total_life += turnController.LTLife;
        total_social_stability += turnController.LTSocial;

    }


}
