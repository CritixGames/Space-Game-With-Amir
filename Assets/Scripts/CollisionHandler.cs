using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem CrashVFX;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        CrashVFX.Play(); //Play Explosion
        GetComponent<MeshRenderer>().enabled = false; //Turn off ship Mesh
        GetComponent<BoxCollider>().enabled = false; //Turn off Collider so no double collision happens
        //Stop Controls when Collision Occurs (trigger in our case)
        GetComponent<PlayerControls>().enabled = false; 
        Invoke("ReloadLevel", loadDelay); //using invoke to give some time before reload
    }

    void ReloadLevel()
    {
        //getting current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); //reloading current scene (RESTART)

    }
}
