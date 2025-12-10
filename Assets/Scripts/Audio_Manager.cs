using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Sources -------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Audio Clips -------")]
    public AudioClip background;
    public AudioClip damage;
    public AudioClip swordSlash;
    public AudioClip wallBump;
    public AudioClip bossRoom;
    //public AudioClip ;
    //public AudioClip ;
    //public AudioClip ;
    //public AudioClip ;

    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
};