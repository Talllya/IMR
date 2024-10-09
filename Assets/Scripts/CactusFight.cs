using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusFight : MonoBehaviour
{
    public GameObject firstCactus;
    public GameObject secondCactus;

    private Animator firstCactusAnimator;
    private Animator secondCactusAnimator;


    private AudioSource firstCactusAudioSource;
    private AudioSource secondCactusAudioSource;

    private float distance;
    private float minDistance = 0.4f;


    void Start()
    {
        firstCactusAnimator = firstCactus.GetComponent<Animator>();
        secondCactusAnimator = secondCactus.GetComponent<Animator>();

        firstCactusAudioSource = firstCactus.GetComponent<AudioSource>();
        secondCactusAudioSource = secondCactus.GetComponent<AudioSource>();

        Debug.Log("in the start function");
    }

    
    void Update()
    {
        Debug.Log("in the update function");

        distance = Vector3.Distance(firstCactus.transform.position, secondCactus.transform.position);
        Debug.Log(distance); 
        
        if (distance <= minDistance)
        {
            firstCactusAnimator.SetBool("isAttacking", true);
            secondCactusAnimator.SetBool("isAttacking", true);

                if (!firstCactusAudioSource.isPlaying)
                {
                    firstCactusAudioSource.Play();
                }
                if (!secondCactusAudioSource.isPlaying)
                {
                    secondCactusAudioSource.Play();
                }
        }
        else
        {
            firstCactusAnimator.SetBool("isAttacking", false);
            secondCactusAnimator.SetBool("isAttacking", false);

                if (firstCactusAudioSource.isPlaying)
                {
                    firstCactusAudioSource.Stop();
                }
                if (secondCactusAudioSource.isPlaying)
                {
                    secondCactusAudioSource.Stop();
                }
        }
    }
}


