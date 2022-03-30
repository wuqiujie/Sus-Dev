using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Start : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }
}
