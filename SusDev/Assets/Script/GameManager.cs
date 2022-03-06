using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public enum GameState
    {
        GameStart,
        GameEnd
       
        
    }

    public TurnController turnController;


    void Start()
    {
        total_environment = 1;
        total_life = 1;
        total_social_stability = 2;
        total_economics = 1;

        EnvBar.GetComponent<Bar>().env.envAmount = total_environment;
        LifeBar.GetComponent<Bar>().env.envAmount = total_life;
        StableBar.GetComponent<Bar>().env.envAmount = total_social_stability;
        EconomyBar.GetComponent<Bar>().env.envAmount = total_economics;

    }
    void Update()
    {

        UI_Update();
        Data_Update();

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

    }
}
