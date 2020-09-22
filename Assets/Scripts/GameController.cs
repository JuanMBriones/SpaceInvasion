using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] enemy;
    
    public Vector3 spawnLimit;
    public float spawnTime;
    public int enemyWaveCount;
    public float waveDelay;

    private int score;
    public Text scoreTxt;
    public int enemiesToKill;
    private int killedEnemies;

    public Text restartTxt;
    public Text gameOverTxt;
    public Text enemiesTxt;
    private bool restart;
    private bool gameOver;

    //private bool displayLabel = false;

    // Start is called before the first frame update
    void Start()
    {
        restart = gameOver = false;
        restartTxt.gameObject.SetActive(false);
        gameOverTxt.gameObject.SetActive(false);
        score = 0;
        UpdateLabels();
       StartCoroutine(SpawnEnemy());    
    }

    public void increaseKilledEnemies()
    {
        killedEnemies++;
        UpdateLabels();
    }

    // Update is called once per frame
    void UpdateLabels()
    {
        enemiesTxt.text = "Enemies left: " + (enemiesToKill-killedEnemies);
        scoreTxt.text = "Score: " + score;
    }

    public void IncrementScore(int value)
    {
        score += value;
        UpdateLabels();
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnTime);
        while (!gameOver && (killedEnemies-enemiesToKill)!=0)
        {
            for (int i = 0; i < enemyWaveCount; i++)
            {
                if ((enemiesToKill - killedEnemies) == 0 && gameOver==false)
                {
                    gameOverTxt.text = "YOU WIN!";
                    GameOver();
                    break;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnLimit.x, spawnLimit.x), spawnLimit.y, spawnLimit.z);
                int index = Random.Range(0, enemy.Length);
                Instantiate(enemy[index], spawnPosition, new Quaternion(0, 180, 0, 0));
                
                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(waveDelay);

        }
        if ((enemiesToKill - killedEnemies) == 0 && gameOver==false)
        {
            gameOverTxt.text = "YOU WIN!";
            GameOver();
        }


    }

    public void GameOver()
    {
        gameOver = restart = true;
        //FlashLabel();
        scoreTxt.gameObject.SetActive(true);
        restartTxt.gameObject.SetActive(true);
        gameOverTxt.gameObject.SetActive(true);

    }

    private void Update()
    {
        
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
