using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball"))
        {
            return;
        }

        score += 1;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
