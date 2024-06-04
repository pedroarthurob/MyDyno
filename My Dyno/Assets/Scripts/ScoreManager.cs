using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text score_Text;
    float score = 0f;
    [SerializeField]
    float speed = 10f;
    private void Update()
    {
        score += speed *Time.deltaTime;
        score_Text.text = Mathf.FloorToInt(score).ToString();
    }

    public void UpdateScore(float newScore)
    {
        score = newScore;
    }
}
