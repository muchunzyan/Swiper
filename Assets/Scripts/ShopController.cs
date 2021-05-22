using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text Money;
    public GameObject PowerUpsLay, ColorsLay;

    public GameObject More_points_per_swipe, Bigger_additional_points, Higher_probability_of_getting_additional_points, Slower_time;

    Image[] More_points_per_swipe_Children, Bigger_additional_points_Children, Higher_probability_of_getting_additional_points_Children, Slower_time_Children;

    private void Start()
    {
        //PlayerPrefs.SetInt("Money", 1000);
        //PlayerPrefs.SetInt("More_points_perswipe", 0);
        //PlayerPrefs.SetInt("Bigger_additional_points", 0);
        //PlayerPrefs.SetInt("Higher_probability_of_getting_additional_points", 0);
        //PlayerPrefs.SetInt("Slower_time", 0);

        Money.text = PlayerPrefs.GetInt("Money").ToString() + "¢";
        More_points_per_swipe_Children = More_points_per_swipe.transform.Find("Load").GetComponentsInChildren<Image>();
        for (int i = 0; i < PlayerPrefs.GetInt("More_points_perswipe"); i++)
        {
            More_points_per_swipe_Children[i].color = new Color32(0, 0, 0, 100);
        }

        Bigger_additional_points_Children = Bigger_additional_points.transform.Find("Load").GetComponentsInChildren<Image>();
        for (int i = 0; i < PlayerPrefs.GetInt("Bigger_additional_points"); i++)
        {
            Bigger_additional_points_Children[i].color = new Color32(0, 0, 0, 100);
        }

        Higher_probability_of_getting_additional_points_Children = Higher_probability_of_getting_additional_points.transform.Find("Load").GetComponentsInChildren<Image>();
        for (int i = 0; i < PlayerPrefs.GetInt("Higher_probability_of_getting_additional_points"); i++)
        {
            Higher_probability_of_getting_additional_points_Children[i].color = new Color32(0, 0, 0, 100);
        }

        Slower_time_Children = Slower_time.transform.Find("Load").GetComponentsInChildren<Image>();
        for (int i = 0; i < PlayerPrefs.GetInt("Slower_time"); i++)
        {
            Slower_time_Children[i].color = new Color32(0, 0, 0, 100);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PowerUps()
    {
        PowerUpsLay.SetActive(true);
        ColorsLay.SetActive(false);
    }

    public void Colors()
    {
        PowerUpsLay.SetActive(false);
        ColorsLay.SetActive(true);
    }

    public void More_points_perswipe()
    {
        int bought = PlayerPrefs.GetInt("More_points_perswipe");
        if (bought <= 9)
        {
            int price = System.Convert.ToInt32(More_points_per_swipe.transform.Find("AllText").Find("Price").GetComponent<Text>().text.Split('¢')[0]);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            Money.text = PlayerPrefs.GetInt("Money").ToString() + "¢";

            PlayerPrefs.SetInt("More_points_perswipe", bought + 1);

            for (int i = 0; i < PlayerPrefs.GetInt("More_points_perswipe"); i++)
            {
                More_points_per_swipe_Children[i].color = new Color32(0, 0, 0, 100);
            }
        }
    }

    public void Bigger_additionalpoints()
    {
        int bought = PlayerPrefs.GetInt("Bigger_additional_points");
        if (bought <= 9)
        {
            int price = System.Convert.ToInt32(Bigger_additional_points.transform.Find("AllText").Find("Price").GetComponent<Text>().text.Split('¢')[0]);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            Money.text = PlayerPrefs.GetInt("Money").ToString() + "¢";

            PlayerPrefs.SetInt("Bigger_additional_points", bought + 1);

            for (int i = 0; i < PlayerPrefs.GetInt("Bigger_additional_points"); i++)
            {
                Bigger_additional_points_Children[i].color = new Color32(0, 0, 0, 100);
            }
        }
    }

    public void Higher_probability_of_getting_additionalpoints()
    {
        int bought = PlayerPrefs.GetInt("Higher_probability_of_getting_additional_points");
        if (bought <= 9)
        {
            int price = System.Convert.ToInt32(Higher_probability_of_getting_additional_points.transform.Find("AllText").Find("Price").GetComponent<Text>().text.Split('¢')[0]);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            Money.text = PlayerPrefs.GetInt("Money").ToString() + "¢";

            PlayerPrefs.SetInt("Higher_probability_of_getting_additional_points", bought + 1);

            for (int i = 0; i < PlayerPrefs.GetInt("Higher_probability_of_getting_additional_points"); i++)
            {
                Higher_probability_of_getting_additional_points_Children[i].color = new Color32(0, 0, 0, 100);
            }
        }
    }

    public void Slowertime()
    {
        int bought = PlayerPrefs.GetInt("Slower_time");
        if (bought <= 9)
        {
            int price = System.Convert.ToInt32(Slower_time.transform.Find("AllText").Find("Price").GetComponent<Text>().text.Split('¢')[0]);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            Money.text = PlayerPrefs.GetInt("Money").ToString() + "¢";

            PlayerPrefs.SetInt("Slower_time", bought + 1);

            for (int i = 0; i < PlayerPrefs.GetInt("Slower_time"); i++)
            {
                Slower_time_Children[i].color = new Color32(0, 0, 0, 100);
            }
        }
    }
}
