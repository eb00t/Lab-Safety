using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioSource[] AllSources;
    private AudioSource RNGSource;
    private AudioSource MultiSourceB;
    public int WhichFolder;
    public List<AudioClip> ClipsToPlay, MultiClipB;
    //public AudioClip prevClip;
    
    void Start()
    {
        AllSources = GetComponents<AudioSource>();
        RNGSource = AllSources[0];
        ClipsToPlay = new List<AudioClip>();
        if (AllSources.Length >= 2)
        {
            MultiSourceB = AllSources[1];
        }

        CheckFolder();
    }

    public void RNGSound()
    {
        CheckFolder();
        RNGSource.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Count))];
        RNGSource.Play();
        Debug.Log(gameObject.name + " is now playing: " + RNGSource.clip.name);
    }
    
    public void RNGSoundClose() //USE THIS IF PLAYING TWO DIFFERENT SOUND EFFECTS CLOSE TO ONE ANOTHER
    {
        CheckFolder();
        MultiSourceB.clip = ClipsToPlay[Random.Range(0, (ClipsToPlay.Count))];
        MultiSourceB.Play();
        Debug.Log(gameObject.name + " is now playing, closely behind: " + MultiSourceB.clip.name);
    }

    public void RNGInOrder()
    {
        CheckFolder();
        RNGSource.clip = ClipsToPlay[Random.Range(0, ClipsToPlay.Count)];
        MultiSourceB.clip = MultiClipB[Random.Range(0, MultiClipB.Count)];
        RNGSource.Play();
        Debug.Log(gameObject.name + " is now playing: " + RNGSource.clip.name);
        MultiSourceB.PlayDelayed(RNGSource.clip.length);
        Debug.Log("and also: " + MultiSourceB.clip.name);
        //prevClip = RNGSource.clip;
    }

    private void CheckFolder()
    {
        ClipsToPlay = new List<AudioClip>();
        switch (WhichFolder) //Set this int manually.
        {
            case 1: //FOOTSTEPS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/footsteps"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 2: //RUNNING FOOTSTEPS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/runsteps"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 3: //GREEN OR PURPLE FOOTSTEPS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/greenpurplefootsteps/a"))
                {
                    ClipsToPlay.Add(Clips);
                }
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/greenpurplefootsteps/b"))
                {
                    MultiClipB.Add(Clips);
                }
                break;
            case 4: //WIRE PULLING
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/wirepull"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 5: //FIRE
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/burn/a"))
                {
                    MultiClipB.Add(Clips);
                }
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/burn/b"))
                {
                    MultiClipB.Add(Clips);
                }
                break;
            case 6: //PURPLE SQUELCHING
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/purpleactivate"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 7: //MACHINE HUMMING
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/machinehum"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            case 8: //SHATTERING GLASS
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/shatter"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
            default:
                foreach (AudioClip Clips in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/youshouldnthearthis"))
                {
                    ClipsToPlay.Add(Clips);
                }
                break;
        }
    }

    public void Silence()
    {
        RNGSource.Stop();
        MultiSourceB.Stop();
    }


    public void LoopSwapSecond()
    {
        MultiSourceB.loop = MultiSourceB.loop != true;
    }

}
    

