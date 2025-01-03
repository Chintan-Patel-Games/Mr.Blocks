using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Audio source
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip levelCompleteAudio;
    public AudioClip gameOverAudio;
    public AudioClip buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayBackgroundMusic();
    }

    //Playing the background music
    public void PlayBackgroundMusic()
    {
        if (bgmAudioSource != null && bgmAudioSource.clip != null && !bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Play();
        }
    }

    public void PlayLevelCompleteAudio()
    {
        if (sfxAudioSource != null && levelCompleteAudio != null)
        {
            sfxAudioSource.PlayOneShot(levelCompleteAudio);
        }
    }

    public void PlayGameOverAudio()
    {
        if (sfxAudioSource != null && gameOverAudio != null)
        {
            sfxAudioSource.PlayOneShot(gameOverAudio);
        }
    }

    public void PlayButtonClickAudio()
    {
        if (sfxAudioSource != null && buttonClick != null)
        {
            sfxAudioSource.PlayOneShot(buttonClick);
        }
    }

    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
}