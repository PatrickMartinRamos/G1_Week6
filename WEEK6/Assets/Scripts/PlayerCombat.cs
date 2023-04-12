using UnityEngine;
using TMPro;
using System.Collections;


public class PlayerCombat : MonoBehaviour
{
    public Transform FirePoint_1;
    public Transform FirePoint_2;
    public Transform FirePoint_3;
    public GameObject bulletprefab;
    public GameObject powerbulletprefab;
    public float Shootinginterval;
    public float startTimeshots;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float powerUpDuration = 5f;
    private float powerUpTimeLeft = 0f;
    private bool usingPowerUP = false;

    public float ScoreIncrease = 1f;



    public void AddScore(int scoreAmount)
    {
        StartCoroutine(IncrementScore(scoreAmount));
    }

    public IEnumerator IncrementScore(int scoreAmount)
    {
        float elapsedTime = 0f;
        int startingScore = score;
        int targetScore = startingScore + scoreAmount;

        while (elapsedTime < ScoreIncrease)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / ScoreIncrease);
            int newScore = Mathf.RoundToInt(Mathf.Lerp(startingScore, targetScore, t));
            scoreText.text = "Score: " + newScore;
            yield return null;
        }

        score += scoreAmount;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("LastScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        if (usingPowerUP)
        {
            powerUpTimeLeft -= Time.deltaTime;

            if (powerUpTimeLeft <= 0f)
            {
                usingPowerUP = false;
            }
        }

        if (!usingPowerUP && Shootinginterval <= 0)
        {
            Instantiate(bulletprefab, FirePoint_2.position, FirePoint_2.rotation);
            Shootinginterval = startTimeshots;
        }
        else if (usingPowerUP && Shootinginterval <= 0)
        {
            Instantiate(powerbulletprefab, FirePoint_1.position, FirePoint_1.rotation);

            Instantiate(powerbulletprefab, FirePoint_2.position, FirePoint_2.rotation);
            
            Instantiate(powerbulletprefab, FirePoint_3.position, FirePoint_3.rotation);
            Shootinginterval = startTimeshots;
        }
        else
        {
            Shootinginterval -= Time.deltaTime;
        }
    
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUP"))
        {
            usingPowerUP = true;
            powerUpTimeLeft = powerUpDuration;
        }
    }

}
