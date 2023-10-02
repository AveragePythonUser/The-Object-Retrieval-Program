using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Engine_fail : MonoBehaviour
{
    public AudioSource voice_line;
    // Start is called before the first frame update
    void Start()
    {
        voice_line = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Events.engine_failure && Game_Events.engine_progress)
        {
            Game_Events.engine_progress = false;
            Invoke("engine_fail", 5f);
        }
    }

    public void engine_fail()
    {
        voice_line.Play(0);
        voice_line.loop = true;
    }
    public void Stop_engine()
    {
        voice_line.Stop();
        voice_line.loop = false;
        Game_Events.engine_progress = true;
        Game_Events.engine_failure = false;
        Game_Events.can_move = true;
    }
}
