using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateScore : MonoBehaviour
{
    [SerializeField] Text score;
    private void Awake()
    {
        Messenger.AddListener(GameEvent.SCORE_UPDATED, UpdateScore);
    }
    private void Start()
    {
        UpdateScore();
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SCORE_UPDATED, UpdateScore);
    }

    private void UpdateScore()
    {
        score.text = $"积分: {Managers.Player.score}";
    }
}
