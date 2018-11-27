using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public static class letters
{
    public const int A = 0; public const int B = 1; public const int C = 2; public const int D = 3; public const int E = 4;
    public const int F = 5; public const int G = 6; public const int H = 7; public const int I = 8; public const int J = 9;
    public const int K = 10; public const int L = 11; public const int M = 12; public const int N = 13; public const int O = 14;
    public const int P = 15; public const int Q = 16; public const int R = 17; public const int S = 18; public const int T = 19;
    public const int Z = 25;
}


public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "right", "left", "stop", "application"};
    public ConfidenceLevel confidence = ConfidenceLevel.High;
    public float speed = 1;

    public Image target;
    public Image random;

    public Image[] targets = new Image[26];
    public Text results;
    public Image target_R;
    public Image target_I;
    public Image target_G;
    public Image target_H;
    public Image target_T;

    protected PhraseRecognizer recognizer;
    protected string word = "";

    ////to keep track of the words
    //protected Dictionary<string, string> word_right = new Dictionary<string, string>();
    //protected Dictionary<string, string> word_left = new Dictionary<string, string>();
    //protected Dictionary<string, string> word_stop = new Dictionary<string, string>();
    //protected Dictionary<string, string> word_appliction = new Dictionary<string, string>();

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            print("Recognizer Started");
        }
        //target_R.transform.position = new Vector3(target.transform.position.x target.transform.position.y, 0);
        //target_I.transform.position = new Vector3()
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;

        float R_x = target_R.transform.position.x;
        float I_x = target_I.transform.position.x;
        float G_x = target_G.transform.position.x;
        float H_x = target_H.transform.position.x;
        float T_x = target_T.transform.position.x;

        switch (word)
        {
            //case "up":
            //    R_y += speed;
            //    I_y += speed;
            //    break;
            //case "down":
            //    R_y -= speed;
            //    I_y -= speed;
            //    break;
            //case "left":
            //    R_x -= speed;
            //    I_x -= speed;
            //    break;

            //R->I
            //I->T
            //G->H
            //H->G
            //T->R
            case "right":
                R_x = target_x;
                //R_y = I_y;
                I_x = R_x + 100;
                //I_y = T_y;
                G_x = I_x +100;
                //G_y = H_y;
                H_x = G_x + 100;
                //H_y = G_y;
                T_x = H_x + 100;
                //T_y = R_y;
                break;
        }

        target_R.transform.position = new Vector3(R_x, target_y, 0);
        target_I.transform.position = new Vector3(I_x, target_y, 0);
        target_G.transform.position = new Vector3(G_x, target_y, 0);
        target_H.transform.position = new Vector3(H_x, target_y, 0);
        target_T.transform.position = new Vector3(T_x, target_y, 0);

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