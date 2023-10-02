using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unknown_entity : MonoBehaviour
{
    public bool sound_bool = true;
    private bool voice_line = true;
    private AudioSource woosh;
    private AudioSource boom;
    [SerializeField]
    private float woosh_delay;
    [SerializeField]
    private float boom_delay;
    [SerializeField]
    private GameObject hud;
    private HUD_manager hud_manager;
    private GameObject Disabler;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        woosh = GameObject.Find("Woosh Audio").GetComponent<AudioSource>();
        boom = GameObject.Find("Boom Audio").GetComponent<AudioSource>();
        hud_manager = hud.GetComponent<HUD_manager>();
        Disabler = GameObject.Find("Disabler");
        Disabler.SetActive(false);
        source = GetComponent<AudioSource>();

        //Game_Events.unknown_entity = true;
        Debug.Log(Game_Events.unknown_entity);
        Debug.Log(Game_Events.at_computer);
        sound_bool = true;
    }

    void FixedUpdate()
    {
        /*if (Game_Events.unknown_entity && voice_line)
        {
            source.Play();
            source.loop = true;
            voice_line = false;
        } */
        if (Game_Events.unknown_entity && Game_Events.at_computer)
        {
            Disabler.SetActive(true);
            if (sound_bool)
            {
                //sounds
                woosh.PlayDelayed(woosh_delay);
                boom.PlayDelayed(boom_delay);
                Invoke("crash", boom_delay + 0.7f);
                sound_bool = false;
            }
            gameObject.transform.position += new Vector3(-1, 0, 0);
        }
    }


    void crash()
    {
        source.Stop();
        hud_manager.end_of_beta();
    }
}
