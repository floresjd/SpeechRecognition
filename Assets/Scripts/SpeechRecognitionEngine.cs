using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "right", "left", "stop", "application"};
    public ConfidenceLevel confidence = ConfidenceLevel.High;

    public Image target;

    public int time_delay = 5;

    public Image[] targets = new Image[26];
    public Word_RIGHT right;
    public Text results;
    //public Text instructions;
    
    public GameObject target_R;
    //public Image target_I;
    //public Image target_G;
    //public Image target_H;
    //public Image target_T;

    protected PhraseRecognizer recognizer;
    protected string word = "";

    ////to keep track of the words
    protected Dictionary<string, float> word_right = new Dictionary<string, float>(); //word #1
    protected Dictionary<string, float> word_left = new Dictionary<string, float>();  //word #2
    protected Dictionary<string, float> word_stop = new Dictionary<string, float>();  //word #3
    protected Dictionary<string, float> word_appliction = new Dictionary<string, float>();    //word #4

    protected int which_word = 1;

    private void Start()
    {

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            print("Recognizer Started");
        }
        //instructions.text = "Ready to begin with the word #" + which_word.ToString();
        StartCoroutine(Example());
        //instructions.gameObject.SetActive(false); // hide the intrunctions text box
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }   

    private void Update()
    {
        float target_x = target_R.transform.position.x;
        float target_y = target_R.transform.position.y;

        target_R.transform.position = new Vector3(target_x, target_y +1f, 0);

        //float R_x = Word_RIGHT.R.transform.position.x;
        //float I_x = RIGHT.I.transform.position.x;
        //float G_x = RIGHT.G.transform.position.x;
        //float H_x = RIGHT.H.transform.position.x;
        //float T_x = RIGHT.T.transform.position.x;

        switch (word)
        {
            case "right":
                //R_x = target_x;
                ////R_y = I_y;
                //I_x = R_x + 100;
                ////I_y = T_y;
                //G_x = I_x +100;
                ////G_y = H_y;
                //H_x = G_x + 100;
                ////H_y = G_y;
                //T_x = H_x + 100;
                //T_y = R_y;
                break;
        }

        //Word_RIGHT.R.transform.position = new Vector3(R_x, target_y, 0);
        //target_I.transform.position = new Vector3(I_x, target_y, 0);
        //target_G.transform.position = new Vector3(G_x, target_y, 0);
        //target_H.transform.position = new Vector3(H_x, target_y, 0);
        //target_T.transform.position = new Vector3(T_x, target_y, 0);

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

public class Word_RIGHT
{
    public void Initialize_position() {

    }
}