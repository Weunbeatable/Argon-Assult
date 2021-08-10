using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitvfx;
    GameObject SpawnatRuntime;
    [SerializeField] int ScorePerHit = 15;
    [SerializeField] int Hitpoints = 4; //TODO temporarily serialized to match block breaker program, will remove later.

  
  

    
    ScoreBoard scoreBoard;
    GameObject parentGameobject; // when we intantiate our deathvfx we want to instantiate it within our particular method
   
    
    void Start()
    {

        scoreBoard = FindObjectOfType<ScoreBoard>(); // looks through our project and uses very first scoreboard it finds
        AddRigidBody();
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
    }

     void AddRigidBody()
    {
        Rigidbody EnemyBody = gameObject.AddComponent<Rigidbody>();
        EnemyBody.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (Hitpoints < 1)
        {        
            KillEnemy();
        }
       
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(ScorePerHit);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // instantiate death particles, at current location and quaternion identity says no rotation leave as is.
        vfx.transform.parent = parentGameobject.transform; // transform is going to be the parent we pointed to
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitvfx, transform.position, Quaternion.identity); // instantiate death particles, at current location and quaternion identity says no rotation leave as is.
        vfx.transform.parent = parentGameobject.transform; // transform is going to be the parent we pointed to
        Hitpoints--;
        
    }
}
