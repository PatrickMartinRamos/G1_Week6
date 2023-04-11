using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    public Transform FirePoint_2;
    public GameObject bulletprefab;
    public GameObject powerbulletprefab;
    public float Shootinginterval;
    public float startTimeshots;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float powerUpDuration = 5f;
    private float powerUpTimeLeft = 0f;
    private bool usingPowerUP = false;


    private void Start()
    {

    }

    public void AddScore(int Score)
    {
        score += Score;
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
            Instantiate(powerbulletprefab, FirePoint_2.position, FirePoint_2.rotation);
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
