using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice_Lines : MonoBehaviour
{
    [SerializeField] public AudioClip tut1_intro;
    [SerializeField] public AudioClip tut2_computer;
    [SerializeField] public AudioClip tut3_retrieval;
    [SerializeField] public AudioClip tut4_finished;
    [SerializeField] public AudioClip unknown;
    public AudioSource source;

    private bool voice_line;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        voice_line = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Events.unknown_entity && voice_line)
        {
            source.clip = unknown;
            source.loop = true;
            source.Play();
            voice_line = false;
        } 
    }

    public void play_clip(string clip)
    {
        source.loop = false;
        if (clip == "1")
        {
            Game_Events.tutorial = true;
            source.clip = tut1_intro;
        }
        else if (clip == "2")
            source.clip = tut2_computer;
        else if (clip == "3")
            source.clip = tut3_retrieval;
        else if (clip == "4")
        {
            Game_Events.tutorial = false;
            source.clip = tut4_finished;
        }
        source.Play();
    }
}
