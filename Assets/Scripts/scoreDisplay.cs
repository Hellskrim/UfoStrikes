using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text text = GetComponent<Text>();
        text.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
	}
	
}
