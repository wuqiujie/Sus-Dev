using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /**
     * UI Bar
     */
    public GameObject EnvBar;
    public GameObject LifeBar;
    public GameObject StableBar;
    public GameObject EconomyBar;
    public GameObject TurnBar;
    public GameObject BudgetBar;

    /**
     * Index
     */
    [SerializeField]

    public int total_environment;
    public int total_life;
    public int total_economics;
    public int total_social_stability;

    public GameState state;

    public GameObject gameStartButton;
    public GameObject playCardButton;

    /**Turn Info**/
    public int turnNum=0;
    public int budgetNum = 0;
    public Text turnText;
    public IncidentManager incidentManager;
    public InterviewManager interviewManager;
    public TurnController turnController;

    public bool interview_called;
    public bool incident_called;


    public enum GameState
    {
        GameStart,
        TurnStart,
        PlayCard,
        CollectCard,
        interview,
        incident,
        TurnEnd,
        GameEnd
    }

    

     void Start()
    {
        state = GameState.GameStart;
        gameStartButton.SetActive(false);
        total_environment = 1;
        total_life = 1;
        total_economics = 1;
        total_social_stability = 2;
    }

    void Update()
    {
/*        Debug.Log("state: " + state);*/

        turnText.text = "Turn: " + turnNum;

        if (state == GameState.GameStart)
        {
            Game_Start();
            gameStartButton.SetActive(true);
        }
        if (state == GameState.TurnStart)
        {
            Start_Turn();
        }
        
        if (state == GameState.PlayCard)
        {
            Play_Card();
            playCardButton.SetActive(true);
        }
/*
        if(state == GameState.PlayCard && turnController.playerDesk.currentZone.Length > 0)
        {
            CalculateCard();
        }
*/
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
        

        EnvBar.GetComponent<Bar>().env.envAmount = total_environment;
        LifeBar.GetComponent<Bar>().env.envAmount = total_life;
        EconomyBar.GetComponent<Bar>().env.envAmount = total_economics;
        StableBar.GetComponent<Bar>().env.envAmount = total_social_stability;
    
        turnText.text = "New Game";
        


    }
    public void Game_Start_Button()
    {
        state = GameState.TurnStart;
        gameStartButton.SetActive(false);
        turnController.ZoneArea.SetActive(true);
        turnController.HandArea.SetActive(true);
        turnController.TableArea.SetActive(true);

    }

    public void Start_Turn()
    {
        budgetNum += 3;
        turnNum++;
        TurnBar.GetComponent<Bar>().env.ChangeEnv(turnNum);
        interview_called = false;
        incident_called = false;
        turnController.StartTurn(); 
        state = GameState.PlayCard;
        incidentManager.called = false;
      
    }
    public void Play_Card()
    {
       
    }
    public void CalculateCard()
    {
        turnController.CalculateCard();
    }
    public void Play_Card_Button()
    {
        CalculateCard();
        turnController.CityChange();
        turnController.DestoryHandCard();
        state = GameState.CollectCard;
    }
    public void EndInterviewButton()
    {
        interviewManager.EndInterview();
        state = GameState.incident;
    }
    public void EndIncidentButton()
    {
        incidentManager.EndIncident();
        state = GameState.TurnEnd;
    }

    public void Collect_Card()
    {
        playCardButton.SetActive(false);

       if(turnController.CollectCard())
        {
            turnController.DestroyCard();
            UI_Update();
            Data_Update();

            state = GameState.interview;

        }
      
       
    }

    

    public void Interview()
    {
       
        interviewManager.InitiateInterview();
/*         state = GameState.incident;*/
        /*        if (interviewManager.called)
                {
                    state = GameState.incident;
                }*/

    }
    public void Incident()
    {
        incidentManager.InitiateIncident();
        /*        if (incidentManager.called)
                {
                    state = GameState.TurnEnd;
                }*/

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


}
