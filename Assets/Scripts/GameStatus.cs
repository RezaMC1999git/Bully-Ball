using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range(.5f,5f)][SerializeField] float gameSpeed =1f;
    [SerializeField] int pointsPerBlockDerstroyed =83;
    [SerializeField] TextMeshProUGUI ScoreText;
    //states
    [SerializeField] int currentScore = 0;
    [SerializeField] bool isAutoPlayEnabled;


    private void Awake() 
    {
        int gameStatusCount =FindObjectsOfType<GameStatus>().Length;   
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    private void Start() {
        ScoreText.text=currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDerstroyed;
        ScoreText.text=currentScore.ToString();
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
