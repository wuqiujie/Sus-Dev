using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int total_social_stability;
    public int total_economics;

    public GameState state;

    public GameObject gameStartButton;
    public GameObject playCardButton;
    public enum GameState
    {
        GameStart,
        TurnStart,
        PlayCard,
        CollectCard,
        accident,
        interview,
        TurnEnd,
        GameEnd
    }

    public TurnController turnController;

     void Start()
    {
        state = GameState.GameStart;
        gameStartButton.SetActive(false);
    }

    void Update()
    {
        Debug.Log("State: " + state);

        if(state == GameState.GameStart)
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
        if (state == GameState.accident)
        {
           
           
        }

        if (state == GameState.interview)
        {

           
        }

        if (state == GameState.TurnEnd)
        {
            

        }

        if (state == GameState.GameEnd)
        {
           
        }



    }
    public void Game_Start()
    {
        total_environment = 1;
        total_life = 1;
        total_social_stability = 2;
        total_economics = 1;

        EnvBar.GetComponent<Bar>().env.envAmount = total_environment;
        LifeBar.GetComponent<Bar>().env.envAmount = total_life;
        StableBar.GetComponent<Bar>().env.envAmount = total_social_stability;
        EconomyBar.GetComponent<Bar>().env.envAmount = total_economics;

        turnController.StartGame();

    }
    public void Game_Start_Button()
    {
        state = GameState.TurnStart;
        gameStartButton.SetActive(false);
      
    }

    public void Start_Turn()
    {
        turnController.StartTurn(); 
        state = GameState.PlayCard;
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
        turnController.CollectCard();
        state = GameState.accident;
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
        total_economics = turnController.environment_change;
        total_environment = turnController.economics_change;
        total_life = turnController.life_change;
        total_social_stability = turnController.social_change;
    }


}
