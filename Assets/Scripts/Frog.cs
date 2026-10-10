
using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour
{
    public AudioSource hitSound;

    public float disappearY = -5f;

    private GameManager gameManager;
    private bool isHit = false;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        // Remove frogs that have fallen below the screen.
        if (transform.position.y < disappearY)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (isHit || gameManager == null)
            return;

        isHit = true;

        // Increase the shared score.
        gameManager.AddScore();

        // Play the existing hit sound.
        if (hitSound != null)
        {
            hitSound.Play();
        }

        StartCoroutine(HitEffect());
    }

    private IEnumerator HitEffect()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Stop the frog falling while the hit effect plays.
        if (rb != null)
        {
            rb.simulated = false;
        }

        // Prevent repeated clicks.
        Collider2D frogCollider = GetComponent<Collider2D>();
        if (frogCollider != null)
        {
            frogCollider.enabled = false;
        }

        transform.localScale *= 0.5f;

        yield return new WaitForSeconds(0.15f);

        Destroy(gameObject);
    }
}
