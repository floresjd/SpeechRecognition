using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public HandleWordDisplay HandleWordDisplay;

    public string[] keywords = { "" };
    public ConfidenceLevel confidence = ConfidenceLevel.High;

    protected PhraseRecognizer recognizer;
    protected string word = "";

    private void Start()
    {
        keywords[0] = WordList.WordList_[0];
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            print("Recognizer Started");
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        HandleWordDisplay.ResetWordDisplay();
    }   

    private void Update()
    {

    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
            print("Recognizer Stopped");
        }
    }
}