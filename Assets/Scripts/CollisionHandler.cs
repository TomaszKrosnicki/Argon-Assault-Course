using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] AudioClip explosionSFX;
    AudioSource sfx;

    public void Start() 
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        sfx.PlayOneShot(explosionSFX, 1f);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
