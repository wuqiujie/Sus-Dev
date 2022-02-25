using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Env env;
    private Image barImage;

   public Bar()
    {

    }
    private void Awake()
    {
        barImage = transform.Find("bar").GetComponent<Image>();
        env = new Env();
    }

    public void ChangeEnv(int amount)
    {
        env.ChangeEnv(amount);
    }

    private void Update()
    {
        barImage.fillAmount = env.GetEnvNormalized();
    }
}

public class Env
{
    public const int ENV_MAX = 10;
    public float envAmount;

    public Env()
    {
        envAmount = 1;
    }

    public void ChangeEnv(int amount)
    {
            envAmount += amount;
    }



    public float GetEnvNormalized()
    {
        return envAmount / ENV_MAX;
    }
}