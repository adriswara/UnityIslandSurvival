using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public static int score;
    TMP_Text text;

        void Awake()
    {

        text = GetComponent <TMP_Text>();

        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        text.SetText("Diamonds: {0}",score);

    }
}
