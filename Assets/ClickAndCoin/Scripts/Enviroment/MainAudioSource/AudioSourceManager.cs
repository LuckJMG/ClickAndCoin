using System;
using UnityEngine;

namespace ClickAndCoin
{
    public class AudioSourceManager : MonoBehaviour
    {
        [SerializeField] private AudioClip grabCoinAudio;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            InputHandler.OnDestroy += OnCoinDestroy;
        }

        private void OnDestroy()
        {
            InputHandler.OnDestroy -= OnCoinDestroy;
        }

        private void OnCoinDestroy()
        {
            _audioSource.PlayOneShot(grabCoinAudio);
        }
    }
}
