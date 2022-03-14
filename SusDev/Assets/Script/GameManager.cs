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
    public Text turnText;
    public IncidentManager incidentManager;
    public InterviewManager interviewManager;

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

    public TurnController turnController;

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
        Debug.Log("state: " + state);

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

        if (state == GameState.CollectCard)
        {
            Collect_Card();
        }
        
        if (state == GameState.interview && !interview_called)
        {
            Interview();
            interview_called = true;
        }

        if (state == GameState.incident)
        {
            Incident();
        }

  

        if (state == GameState.TurnEnd)
        {
            Turn_End();
        }

        if (state == GameState.GameEnd)
        {
            Game_End();
        }

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
     
        turnNum++;
        interview_called = false;
        incident_called = false;
        turnController.StartTurn(); 
        state = GameState.PlayCard;
        incidentManager.called = false;
      
    }
    public void Play_Card()
    {
       
    }
    public void Play_Card_Button()
    {
        turnController.CalculateCard();
        state = GameState.CollectCard;
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
         state = GameState.incident;
        /*        if (interviewManager.called)
                {
                    state = GameState.incident;
                }*/

    }
    public void Incident()
    {
/*        incidentManager.InitiateIncident();*/
        if (incidentManager.called)
        {
            state = GameState.TurnEnd;
        }
     
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
        EnvBar.GetComponent<Bar>().env.ChangeEnv(turnController.environment_change);
        LifeBar.GetComponent<Bar>().env.ChangeEnv(turnController.life_change);
        StableBar.GetComponent<Bar>().env.ChangeEnv(turnController.social_change);
        EconomyBar.GetComponent<Bar>().env.ChangeEnv(turnController.economics_change);
    }
    public void Data_Update()
    {
        total_economics += turnController.economics_change;
        total_environment += turnController.environment_change;
        total_life += turnController.life_change;
        total_social_stability += turnController.social_change;
    }


}
