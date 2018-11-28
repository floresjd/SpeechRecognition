using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWord : MonoBehaviour {

    private string word;
    private Dictionary<char, GameObject> wordDict = new Dictionary<char, GameObject>();

    public GameObject initPosition;

    public void SetWord(string w)
    {
        this.word = w;
    }

    private void Set_wordDict()
    {
        foreach (char c in this.word)
        {
            GameObject myOject = (LoadLetter.GetLetter(c));
            
            myOject.transform.SetParent(this.transform);
            this.wordDict.Add(c, myOject);
        }
    }
}
