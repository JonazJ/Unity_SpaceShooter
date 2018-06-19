using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float startWait;
    public float spawnWait;


    //ScoreText
    public Text scoreText;
    private int score = 0;

    void Start () {

        StartCoroutine (SpawnWaves());
        
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < asteroidCount; i++) {
                Vector3 spawnAt = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    spawnValues.y,
                    spawnValues.z);
                Instantiate(asteroid, spawnAt, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
    void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score:" + points;
    }
}
