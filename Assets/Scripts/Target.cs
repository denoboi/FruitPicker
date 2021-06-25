using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int scoreValue;
    public ParticleSystem particleEffect;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //diger scripti cagiriyoruz.
        targetRb = GetComponent<Rigidbody>();
        
        

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); //yukariya dogru random bolgeye force
        targetRb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 

        transform.position = RandomSpawnPos(); 
    }

    void Update()
    {
        NegativeScore();
        WinCondition();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12, 15); //yukariya dogru random bolgeye force
        
    }
    float RandomTorque()
    {
        return Random.Range(-10, 10); //3 farkli yone objenin donusu
    }    
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -2); //objenin baslama pozisyonu
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scoreValue); //diger scriptten cagirdik
            Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);
         }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //asagida bir game obje daha var. ona degdiginde yok oluyor(sensor)
        if(!gameObject.CompareTag("Bad")) //good objeler sensore degerse game over olsun.
        {
            gameManager.GameOver();
        }
        Physics.IgnoreLayerCollision(0,0,true);
       
    }
    void NegativeScore()
    {
        if (gameManager.score < 0)
        {
            gameManager.GameOver();
        }            
    }
    void WinCondition()
    {
        if(gameManager.score > 14)
        {
            gameManager.Win();

        }    
    }
    
}
