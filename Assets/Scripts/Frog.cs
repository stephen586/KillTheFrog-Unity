using UnityEngine;
using TMPro;
using System.Collections;

public class Frog : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioSource hitSound;

    private int score = 0;

    public float appearTime = 2f;
    private float timer;

    private bool isHit = false;

    private void Start()
    {
        scoreText.text = "Score: 0";
        timer = appearTime;
        MoveFrog();
    }

    private void Update()
    {
        if (isHit)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            MoveFrog();
            timer = appearTime;
        }
    }

    private void OnMouseDown()
    {
        if (!isHit)
        {
            score++;

            scoreText.text = "Score: " + score;

            // Play the complete hit sound
            hitSound.Play();

            StartCoroutine(HitEffect());
        }
    }

    private IEnumerator HitEffect()
    {
        isHit = true;

        Vector3 originalScale = transform.localScale;

        // Shrink frog when hit
        transform.localScale = originalScale * 0.5f;

        yield return new WaitForSeconds(0.15f);

        // Restore normal size
        transform.localScale = originalScale;

        // Move to another random position
        MoveFrog();

        timer = appearTime;
        isHit = false;
    }

    private void MoveFrog()
    {
        float randomX = Random.Range(-6f, 6f);
        float randomY = Random.Range(-3f, 3f);

        transform.position = new Vector3(randomX, randomY, 0f);
    }
}