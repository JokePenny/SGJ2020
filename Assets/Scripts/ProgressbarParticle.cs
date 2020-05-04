using UnityEngine.UI;
using UnityEngine;

public class ProgressbarParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Slider progress;

    private bool isAnimated = false;
    
    void Update()
    {
        if(progress.value != 1)
        {
            if(!isAnimated)
            {
                particle.Play();
                isAnimated = true;
            }
        }
        else if(isAnimated)
        {
            isAnimated = false;
            particle.Stop();
        }
    }
}
