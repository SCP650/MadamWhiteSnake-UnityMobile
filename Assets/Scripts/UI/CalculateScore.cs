using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateScore : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject addTextPrefab;
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.SCORE_UPDATED, UpdateScore);
    }
    private void Start()
    {
        score.text = $"积分: {Managers.Player.score}";
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.SCORE_UPDATED, UpdateScore);
    }

    private void UpdateScore(int temp)
    {
        score.text = $"积分: {Managers.Player.score}";
        GameObject gb = Instantiate(addTextPrefab);
        gb.transform.SetParent(gameObject.transform);
        gb.transform.localPosition = new Vector3(0, 22, 0);
        gb.GetComponent<Text>().text = temp>0 ? $"+{temp}" : $"{temp}";

    }
}
