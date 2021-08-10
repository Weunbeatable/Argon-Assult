using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] ParticleSystem DeathParticles;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + " collidedd with" + collision.gameObject.name); //this specifies that the thing that the script is on

        StartCrashSequence();
        
    }

    private void StartCrashSequence()
    {
        DeathParticles.Play();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);
        
    }

   
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}"); //string interpolation
        
        
    }



    private void ReloadLevel() // handl level switching
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
        
    }
}

