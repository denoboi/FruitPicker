using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    //public GameObject[] targets2;

    private float spawnRate = 2;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject titleScreen;
    public bool isGameActive;
    public int score;
    public Button restartButton;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget() // once boyle bir method olusturuyoruz
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate); //to control the length of time between each spawn
            int index = Random.Range(0, targets.Count); //random obje seciyor listeden
            Instantiate(targets[index]); //random objeyi listeden instantiate ediyor

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
    }

    public void GameOver() //diger scriptte cagiracagiz o yuzden public
    {
        gameOverText.gameObject.SetActive(true); //inspector'da kapadigimizi aciyor
        isGameActive = false;
        restartButton.gameObject.SetActive(true); //inspector'da kapadigimizi aciyor
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty; //spawnRate = spawnRate / difficulty

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }  
    
    public void Win()
    {
        winText.gameObject.SetActive(true);
        isGameActive = false;
    }    
}
