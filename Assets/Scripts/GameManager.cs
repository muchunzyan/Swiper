using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject EndGameScreen;

    public GameObject AddCoinsBtn;

    public GameObject AddedScore;
    Animator AddedScoreAnim;
    Text AddedScoreText;

    public GameObject BigFlare, LilFlare, DirectionalFlare;
    List<GameObject> newParticles = new List<GameObject>();
    float particlesTimer;

    public Image TimeLine;

    public Text ScoreText, MoneyText;
    int money = 0;

    public AudioSource mainSound, bonusSound;

    int direction = 0;
    string directionStr;

    public float lengthDecreaseCoeff = 0.8f;

    public bool isPlaying = true;

    int score = 0;

    void Start()
    {
        AddedScoreAnim = AddedScore.GetComponent<Animator>();
        AddedScoreText = AddedScore.GetComponent<Text>();

        ChangeDirection();
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (TimeLine.rectTransform.sizeDelta.x < 0f)
                EndGame();
            else
            {
                TimeLine.rectTransform.sizeDelta = new Vector2(
                        TimeLine.rectTransform.sizeDelta.x - lengthDecreaseCoeff,
                        TimeLine.rectTransform.sizeDelta.y);
            }

            if (particlesTimer < 0 && newParticles.Count != 0)
            {
                newParticles.RemoveAt(0);
            }
            particlesTimer -= Time.deltaTime;
        }
    }

    public void HandleSwipe(string dir)
    {
        if (dir == directionStr)
        {
            Win();
        }
        else
            EndGame();
    }

    void Win()
    {
        int rnd = Random.Range(0, 10);
        if (rnd == 0)
        {
            int rndScore = Random.Range(2, 6);
            score += rndScore;
            AddedScoreText.text = "+" + rndScore.ToString();
            AddedScoreAnim.SetTrigger("StartAddedScore");
            bonusSound.Play();

            newParticles.Add(Instantiate(BigFlare, new Vector3(0, -0.25f, 1), Quaternion.identity));
            particlesTimer = 3.2f;
        }
        else
        {
            score += 1;
            AddedScoreText.text = "+1";
            AddedScoreAnim.SetTrigger("StartAddedScore");
            mainSound.Play();

            newParticles.Add(Instantiate(LilFlare, new Vector3(0, -0.25f, 1), Quaternion.identity));
            particlesTimer = 3.2f;
        }

        ScoreText.text = score.ToString();
        if (score != 0 && score % 10 == 0)
            lengthDecreaseCoeff += 0.5f;

        money = score / 10;
        MoneyText.text = money.ToString() + "¢";

        ResetTimeLine();
        ChangeDirection();
    }

    void EndGame()
    {
        isPlaying = false;

        if (PlayerPrefs.GetInt("HighScore") < score)
            PlayerPrefs.SetInt("HighScore", score);

        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + money);

        EndGameScreen.SetActive(true);
    }

    void ChangeDirection()
    {
        Arrow.transform.Rotate(0, 0, -direction * 90);

        direction = Random.Range(0, 4);
        Arrow.transform.Rotate(0, 0, direction * 90);
        if (direction == 0)
            directionStr = "Up";
        else if (direction == 1)
            directionStr = "Left";
        else if (direction == 2)
            directionStr = "Down";
        else if (direction == 3)
            directionStr = "Right";
    }

    void ResetTimeLine()
    {
        TimeLine.rectTransform.sizeDelta = new Vector2(Screen.width, TimeLine.rectTransform.sizeDelta.y);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddCoins()
    {
        MoneyText.text = (money * 2).ToString() + "¢";
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + money);
        AddCoinsBtn.SetActive(false);
    }
}
