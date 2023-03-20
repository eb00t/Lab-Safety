using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;
    private AudioSource RNGSource;
    private AudioSource MultiSourceB;
    public int WhichFolder;
    public AudioClip[] ClipsToPlay;
    public AudioClip[] MultiClipA, MultiClipB;
    //public AudioClip prevClip;

    // Start is called before the first frame update
    void Start()
    {
        AllSources = GetComponents<AudioSource>();
        RNGSource = AllSources[0];
        if (AllSources.Length >= 2)
        {
            MultiSourceB = AllSources[1];
        }

        CheckFolder();
    }

    public void RNGSound()
    {
        RNGSource.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Length))];
        RNGSource.Play();
    }

    public void RNG2Sounds()
    {
        RNGSource.clip = MultiClipA[Random.Range(0, MultiClipA.Length)];
        MultiSourceB.clip = MultiClipB[Random.Range(0, MultiClipB.Length)];
        RNGSource.Play();
        MultiSourceB.PlayDelayed(RNGSource.clip.length);
        //prevClip = RNGSource.clip;
    }

    private void CheckFolder()
    {
        switch (WhichFolder) //Set this int manually.
        {
            case 1: //FOOTSTEPS
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sound/Sound Effects/footsteps");
                break;
            case 2: //RUNNING FOOTSTEPS
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sound/Sound Effects/runsteps");
                break;
            case 3: //GREEN OR PURPLE FOOTSTEPS
                MultiClipA = Resources.LoadAll<AudioClip>("Sound/Sound Effects/greenpurplefootsteps/A");
                MultiClipB = Resources.LoadAll<AudioClip>("Sound/Sound Effects/greenpurplefootsteps/B");
                break;
            case 4: //WIRE PULLING
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sound/Sound Effects/wirepull");
                break;
            default:
                ClipsToPlay = Resources.LoadAll<AudioClip>("Sound/Sound Effects/youshouldnthearthis");
                break;
        }
    }



}
    

