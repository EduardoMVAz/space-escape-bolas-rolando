using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerifyStars : MonoBehaviour
{
    public GameObject starsTime;
    public GameObject starsDeath;
    public GameObject starsCubes;

    public TextMeshProUGUI cubesCounter;
    public TextMeshProUGUI deathCounter;
    public TextMeshProUGUI timeCounter;

    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip oneOrTwoStarsClip;
    [SerializeField] private AudioClip threeStarsClip;

    private int time;
    private int deaths;
    private int cubes;
    private int starsCount = 3;

    void Start()
    {
        time = PlayerPrefs.GetInt("Time");
        deaths = PlayerPrefs.GetInt("Deaths");
        cubes = PlayerPrefs.GetInt("Cubes");

        if (time > 180) {
            starsTime.SetActive(false);
            starsCount--;
        }
        if (deaths > 5) {
            starsDeath.SetActive(false);
            starsCount--;
        }
        if (cubes < 12) {
            starsCubes.SetActive(false);
            starsCount--;
        }

        if (starsCount == 0) SoundFXManagerEndgame.instance.PlaySoundFXClip(loseClip, transform, 1f);
        else if (starsCount < 3) SoundFXManagerEndgame.instance.PlaySoundFXClip(oneOrTwoStarsClip, transform, 1f);
        else SoundFXManagerEndgame.instance.PlaySoundFXClip(threeStarsClip, transform, 1f);

        deathCounter.text = "Deaths: " + deaths.ToString() + " / 5";
        cubesCounter.text = "Cubes: " + cubes.ToString() + " / 12";
        timeCounter.text = "Time: " + time.ToString() + " / 180";
    }
}
