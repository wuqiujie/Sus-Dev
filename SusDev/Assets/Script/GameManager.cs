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
    public int total_social_stability;
    public int total_economics;

    public GameState state;

    public GameObject gameStartButton;
    public GameObject playCardButton;

    /**Turn Info**/
    public int turnNum=0;
    public Text turnText;


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
        if (state == GameState.accident)
        {
            Accident();      
        }

        if (state == GameState.interview)
        {
            Interview();
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
        total_environment = 1;
        total_life = 1;
        total_social_stability = 2;
        total_economics = 1;

        EnvBar.GetComponent<Bar>().env.envAmount = total_environment;
        LifeBar.GetComponent<Bar>().env.envAmount = total_life;
        StableBar.GetComponent<Bar>().env.envAmount = total_social_stability;
        EconomyBar.GetComponent<Bar>().env.envAmount = total_economics;

        // turnController.StartGame();
        turnText.text = "New Game";

    }
    public void Game_Start_Button()
    {
        state = GameState.TurnStart;
        gameStartButton.SetActive(false);
      
    }

    public void Start_Turn()
    {
        turnNum++;
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
       if(turnController.CollectCard())
        {
            turnController.DestroyCard();
            UI_Update();
            Data_Update();

            //todo
            //   state = GameState.accident;

            state = GameState.TurnEnd;
          
        }
      
       
    }

    public void Accident()
    {
     
    }

    public void Interview()
    {

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
        total_economics = turnController.environment_change;
        total_environment = turnController.economics_change;
        total_life = turnController.life_change;
        total_social_stability = turnController.social_change;
    }


}
