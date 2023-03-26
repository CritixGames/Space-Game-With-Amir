using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;

    

    [SerializeField] int scorePerHit = 10;

    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;
    GameObject parentGameObject; //parent of all vfx to make sure we can delete them all after runtime

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); //Find Scoreboard in project
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        //add rigid body component to all enemies in runtime
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        //VFX SECTION
        //Instantiate Explosion on Enemy at position with no rotation (IDENTITY)
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform; //Parent of this vfx will be our initiated parent variable
        
        hitPoints--; // - life
        scoreBoard.increaseScore(scorePerHit); //increase score
    }
    private void KillEnemy()
    {
        //VFX SECTION
        //Instantiate Explosion on Enemy at position with no rotation (IDENTITY)
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform; //Parent of this vfx will be our initiated parent variable
        
        //Death Section
        Destroy(this.gameObject);
    }
}
