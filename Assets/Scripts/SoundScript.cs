using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundScript : MonoBehaviour {

    static SoundScript music = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource sound;
    
    void OnEnable () {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
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
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        sound.Stop();
        if (scene.buildIndex == 0)
            sound.clip = startClip;
        if (scene.buildIndex == 1)
            sound.clip = gameClip;
        if (scene.buildIndex == 2)
            sound.clip = endClip;
        sound.loop = true;
        sound.Play();
    }
}
