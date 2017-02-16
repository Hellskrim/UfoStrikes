using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour {

    static SoundScript music = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource sound;

    // Use this for initialization
    void Start () {
        if (music != null && music != this)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            music = this;
            GameObject.DontDestroyOnLoad(gameObject);
            sound = GetComponent<AudioSource>();
            sound.clip = startClip;
            sound.loop = true;
            sound.Play();
        }
	}
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("loaded music level" + level);
        sound.Stop();
        if (level == 0)
            sound.clip = startClip;
        if (level == 1)
            sound.clip = gameClip;
        if (level == 2)
            sound.clip = endClip;
        sound.loop = true;
        sound.Play();
    }
}
