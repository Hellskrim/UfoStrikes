using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadNextLevel()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(Application.loadedLevel + 1);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
