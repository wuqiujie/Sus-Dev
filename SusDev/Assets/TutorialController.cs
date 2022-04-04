using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Sprite[] tutorial_sprites;
   // public GameObject NextButton;
    public Image image;
    public int index = 0;


    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite  = tutorial_sprites[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (index < tutorial_sprites.Length)
            {
                image.sprite = tutorial_sprites[++index];
             
            }
        }
        if(index >= 17)
        {

        }

    }

}
