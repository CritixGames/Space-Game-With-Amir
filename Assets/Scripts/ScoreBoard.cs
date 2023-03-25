using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText; //Reference to Text

    private void Start()
    {
        //Find Text Component in GameObject
        scoreText = GetComponent<TMP_Text>(); 
        scoreText.text = "Let's Do It";
    }

    public void increaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString(); //change score to Sring
    }
}
