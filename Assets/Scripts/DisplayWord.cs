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
        word = w;
        word = word.ToUpper();
        Set_wordDict();
    }

    private void Set_wordDict()
    {
        int offset = 0;
        foreach (char c in this.word)
        {
            GameObject myObject = (LoadLetter.GetLetter(c));
            myObject.transform.SetParent(this.transform);
            Vector3 pos = initPosition.transform.position;
            pos[0] = pos[0] + 90 * offset;
            offset++;
            myObject.transform.position = pos;
            wordDict.Add(c, myObject);
        }
    }
}
