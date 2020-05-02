using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Animation animate;
    [SerializeField] private GameController gameController;

    private void Start()
    {
        animate = GetComponent<Animation>();
        scoreText.text = PlayerPrefs.GetFloat("score", 0.0f).ToString();
    }

    public void OpenMainMenu()
    {
        scoreText.text = PlayerPrefs.GetFloat("score", 0.0f).ToString();
        animate.Play("ViewMenu");
    }

    public void CloseMainMenu()
    {
        animate.Play("HiddenMenu");
        gameController.StartGame();
    }

    
    public void OpenPauseMenu()
    {
        //animate.Play("ViewMenu");
        //gameController.StartGame();
    }
}
