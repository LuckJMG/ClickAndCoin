using UnityEngine;

namespace ClickAndCoin
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip grabCoinAudioClip;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            DestroyOnClick.OnDestroy += playSound;
        }

        private void playSound()
        {
            _audioSource.PlayOneShot(grabCoinAudioClip);
        }
    }
}
