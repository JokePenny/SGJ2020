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
}
