using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public static Master Instance;
    [SerializeField]
    private GameObject player = null;
    private float nextPosition = 450f;
    private float posToInsert = 490f;
    private float increaseAmount = 500f;
    [SerializeField]
    private GameObject groundParent = null;
    [SerializeField]
    private GameObject ground = null;
    [SerializeField]
    private GameObject skyParent = null;
    [SerializeField]
    private GameObject sky = null;
    [SerializeField]
    private TextMeshProUGUI score = null;
    [SerializeField]
    private GameObject deathPanel = null;
    [SerializeField]
    private TextMeshProUGUI deathScore = null;
    [SerializeField]
    private TextMeshProUGUI deathHighScore = null;
    public int BiomeSelected = 0;
    //0 Desert / 1 City / 2 Forest
    
    private void Awake()
    {
        Instance = this;
        BiomeSelected = Random.Range(0, 3);
    }
    

    private void FixedUpdate()
    {
        if (player.transform.position.x > nextPosition)
        {
            nextPosition += increaseAmount;
            Instantiate(sky, new Vector3(posToInsert, 0f, 0f), Quaternion.identity, skyParent.transform);
            Instantiate(ground, new Vector3(posToInsert, 0.02f, 0f), Quaternion.identity, groundParent.transform);
            posToInsert += increaseAmount;
        }
    }
    private void Update()
    {
        score.text = player.transform.position.x.ToString("N0");
    }

    public void OpenDeathPanel()
    {
        deathScore.text = score.text;
        int hs = PlayerPrefs.GetInt("highscore", 0);
        int sc = int.Parse(deathScore.text);
        if (sc > hs)
        {
            PlayerPrefs.SetInt("highscore", sc);
            deathHighScore.text = sc.ToString();
        }
        else
        {
            deathHighScore.text = hs.ToString();
        }

        deathPanel.SetActive(true);

    }
    public void onClickRetry()
    {
        SceneManager.LoadScene("Game");
    }
    public void onClickExit()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
