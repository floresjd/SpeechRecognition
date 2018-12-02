using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWordDisplay : MonoBehaviour {


    public DisplayWord DisplayWord;

	// Use this for initialization
	void Start () {
        DisplayWord.SetWord(WordList.WordList_[0]);
	}

    public void ResetWordDisplay()
    {
        DisplayWord.ResetWord();
    }

}
