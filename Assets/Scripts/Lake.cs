
using UnityEngine;

public class Lake : MonoBehaviour
{
    public GameObject waterSplashPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Frog>() != null)
        {
            // Create a splash where the frog enters the lake.
            if (waterSplashPrefab != null)
            {
                Vector3 splashPosition = new Vector3(
                    other.transform.position.x,
                    transform.position.y + 0.75f,
                    0f
                );

                GameObject splash = Instantiate(
                    waterSplashPrefab,
                    splashPosition,
                    Quaternion.identity
                );

                ParticleSystem particles = splash.GetComponent<ParticleSystem>();

                if (particles != null)
                {
                    particles.Play();
                }

                // Remove the splash after the particles finish.
                Destroy(splash, 2f);
            }

            // Remove the frog after it enters the lake.
            Destroy(other.gameObject);
        }
    }
}
