using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Sonidos Entrar;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image image;
    [SerializeField] private Color currentColor;
    [SerializeField] private Color startColor;
    [SerializeField] private Color targetColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeInWait());
        }
            if (_audioSource != null && Entrar != null && Entrar.SoundClip != null)
        {
            _audioSource.clip = Entrar.SoundClip;
            _audioSource.Play();
        }
        _audioSource.Stop();
    }

    private void OnTriggerExit(Collider other)
    {

        if (_audioSource != null && Entrar != null && Entrar.SoundClip != null)
        {
            _audioSource.clip = Entrar.SoundClip;
            _audioSource.Play();
        }
    }

    IEnumerator FadeInNull()
    {
        currentColor = image.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return null;
        }
    }

    IEnumerator FadeInWait()
    {
        currentColor = image.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
