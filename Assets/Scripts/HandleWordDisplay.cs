using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWordDisplay : MonoBehaviour {


    public DisplayWord DisplayWord;

    public void WhichWord(string w)
    {
        DisplayWord.SetWord(w);
    }

    // Use this for initialization
    public void Display()
    {
        DisplayWord.LoadWord(WordList.WordList_[0]);
    }
        
    public void ResetDisplay()
    {
        DisplayWord.ResetWord();
    }

    public void RemoveDisplay()
    {
        DisplayWord.DeleteWord();
    }

}
