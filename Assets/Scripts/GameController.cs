using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public GameObject secretMessage;

    public Vector3 spawnValues;

    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float speed;
    public int multiply;
    public float decrease;
 
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private int wavesCount;

    void Start()
    {
        Cursor.visible = false;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = ""; 
        score = 0;
        speed = 1;
        wavesCount = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
                Application.LoadLevel(Application.loadedLevel);
        }

        if (score >= 800)
        {
            Time.timeScale = 0.0F;
            secretMessage.SetActive(true);
            Cursor.visible = true;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            wavesCount++;
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(speed * spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                Cursor.visible = true;
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
            if (wavesCount % multiply == 0) { 
              speed = speed * decrease;
              hazardCount += 2;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    
    public void GameOver()
    {
        gameOverText.text = "Game over";
        gameOver = true;
    }
}