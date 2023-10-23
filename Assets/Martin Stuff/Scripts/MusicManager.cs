using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] songs;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (!_audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = volume;

        if (!_audioSource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    public void ChangeSong(int songPicked)
    {
            _audioSource.clip = songs[songPicked];
            _audioSource.Play();
    }

}
