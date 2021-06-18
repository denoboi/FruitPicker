using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse); //yukariya dogru random bolgeye force
        targetRb.AddTorque (RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 

        transform.position = RandomSpawnPos(); 
    }

    void Update()
    {
        
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
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //asagida bir game obje daha var. ona degdiginde yok oluyor..
    }
}
