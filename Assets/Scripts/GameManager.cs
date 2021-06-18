using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    //public GameObject[] targets2;
    private float spawnRate = 1;
    public TextMeshProUGUI textScore;
    private int score;
    
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        textScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget() // once boyle bir method olusturuyoruz
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate); //to control the length of time between each spawn
            int index = Random.Range(0, targets.Count); //random obje seciyor listeden
            Instantiate(targets[index]); //random objeyi listeden instantiate ediyor
        }
    }    
}
