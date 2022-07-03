using UnityEngine;

namespace ClickAndCoin
{
    public class CoinAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip grabCoinAudio;
        private AudioSource _audioSource;

        private void Start()
        {
            InputHandler.OnDestroy += OnCoinDestroy;

            var mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioSource");
            _audioSource = mainAudioSource.GetComponent<AudioSource>();
        }

        private void OnDestroy()
        {
            InputHandler.OnDestroy -= OnCoinDestroy;
        }

        private void OnCoinDestroy()
        {
            if (_audioSource != null) _audioSource.PlayOneShot(grabCoinAudio);
        }
    }
}
