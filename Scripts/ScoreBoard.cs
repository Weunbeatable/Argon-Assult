using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI GameScoreText; // So  we can live update our score

    private void Start()
    {
        GameScoreText.text = "START"; // At the very start replace our placeholder string with the current game score which is set to 0
    }
    public void IncreaseScore(int amountToIncrease) // This will allow us to affect the score dependant on enemy
    {
        score += amountToIncrease;
        GameScoreText.text = score.ToString(); // as our score updates in our game we want to update our score text
    }
}
