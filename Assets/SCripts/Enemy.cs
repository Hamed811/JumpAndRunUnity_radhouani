using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioSource squashAudioSource;
    [SerializeField] private float squashDuration = 0.15f;
    [SerializeField] private bool disappearAfterSquash = true;

    private bool isDefeated = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void DefeatEnemy()
    {
        if (isDefeated)
        {
            return;
        }

        StartCoroutine(SquashEnemy());
    }

    private IEnumerator SquashEnemy()
    {
        isDefeated = true;

        if (squashAudioSource != null)
        {
            squashAudioSource.Play();
        }

        Vector3 squashedScale = new Vector3(
            originalScale.x * 1.2f,
            originalScale.y * 0.3f,
            originalScale.z * 1.2f
        );

        float timer = 0f;

        while (timer < squashDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, squashedScale, timer / squashDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = squashedScale;

        if (disappearAfterSquash)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
        }
    }
}