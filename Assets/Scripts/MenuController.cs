using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text HighScore, Money;

    private void Start()
    {
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        Money.text = "Coins: " + PlayerPrefs.GetInt("Money").ToString() + "¢";
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
}
