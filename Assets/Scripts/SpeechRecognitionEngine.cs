﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;


public class SpeechRecognitionEngine : MonoBehaviour
{
    public HandleWordDisplay HandleWordDisplay;

    public ConfidenceLevel confidence = ConfidenceLevel.High;
    protected PhraseRecognizer recognizer;

    protected string word = "";
    public string[] keywords = { "" };

    public Text results;

    //This will update the keywords that the speech recognizer will recognize
    //For the list of avaiable words see WordList.cs

    //To select which word
    public void WhichWord(int i)
    {
        keywords[0] = WordList.WordList_[i];
        HandleWordDisplay.WhichWord(keywords[0]);
    }

    //To randomize which word
    public void ChooseRandWord()
    {
        System.Random rnd = new System.Random();
        keywords[0] = WordList.WordList_[rnd.Next(WordList.WordList_.Length)];
        print(keywords[0]);
        HandleWordDisplay.WhichWord(keywords[0]);
    }

    //Can maybe use enable/disable
    private void Start()
    {
        //WhichWord(2);
        ChooseRandWord();
        HandleWordDisplay.Display();
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
        StartCoroutine(Reset());
        results.text = "You said: <b>" + word + "</b>";
    }

    IEnumerator Reset()
    {
        HandleWordDisplay.ResetDisplay();
        //Think we can display the word for a few second then remove it from the display
        yield return new WaitForSeconds(2);
        //To remove the word from the display
        HandleWordDisplay.RemoveDisplay();

        //to stop the PhraseRecognizer
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
            print("Recognizer Stopped");
        }
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