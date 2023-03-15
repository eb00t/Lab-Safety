using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;

    private AudioSource RNGSource;
    // Start is called before the first frame update
    void Start()
    {
        AllSources = GetComponents<AudioSource>();
        RNGSource = null;
    }

    public void RNGSound()
    {
        RNGSource.Stop();
        RNGSource = AllSources[Random.Range(0, AllSources.Length)];
        RNGSource.Play();
    }
}
