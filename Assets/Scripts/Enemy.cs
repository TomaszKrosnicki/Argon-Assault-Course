using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;

    ScoreBoard scoreBoard;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        KillEnenmy();
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnenmy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}