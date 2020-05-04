using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animation animate;
    [SerializeField] private GameController gameController;

    private void Start()
    {
        animate = GetComponent<Animation>();
    }

    public void OpenMainMenu()
    {
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
