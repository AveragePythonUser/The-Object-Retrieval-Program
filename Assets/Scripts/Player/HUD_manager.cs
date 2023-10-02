using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject E_panel;

    [SerializeField]
    private GameObject computer;

    private bool keep_radar_true;

    [SerializeField]
    private GameObject End_Panel;

    [SerializeField]
    private GameObject Pause_Panel;

    [SerializeField]
    private GameObject Controls_Panel;

    [SerializeField]
    private GameObject Start_Panel;
    [SerializeField]
    private GameObject Start_Button;

    [SerializeField]
    private GameObject End_Button;

    private Voice_Lines voice;

    private Slider slider;
    private Text slider_text;

    [SerializeField]
    private GameObject drone;
    private AudioSource drone_source;
    [SerializeField]
    private GameObject drone2;
    private AudioSource drone_source2;

    private bool start_of_game;
    // Start is called before the first frame update
    void Start()
    {
        drone_source = drone.GetComponent<AudioSource>();
        drone_source2 = drone2.GetComponent<AudioSource>();

        voice = GameObject.FindGameObjectWithTag("Voice").GetComponent<Voice_Lines>();

        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider_text = GameObject.Find("Slider Text").GetComponent<Text>();

        turn_off_all();
        Start_Panel.SetActive(true);
        Start_Button.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        start_of_game = true;
        Invoke("activate_button", 3f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Pause_Panel.SetActive(true);
        }
        if (start_of_game)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void turn_off_all()
    {
        Press_E(false);
        computer.SetActive(false);
        End_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Controls_Panel.SetActive(false);
        Start_Panel.SetActive(false);
        start_of_game = false;
    }

    public void Press_E(bool state)
    {
        if (state == true)
            E_panel.SetActive(true);
        else
            E_panel.SetActive(false);
    }

    public void computer_initialize()
    {

        if (Game_Events.tutorial)
            voice.play_clip("2");

        computer.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Game_Events.at_computer = true;
    }

    public void computer_shutdown()
    {
        if(Radar.object_in_scanner)
            keep_radar_true = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        computer.SetActive(false);
        Game_Events.at_computer = false;

        if (keep_radar_true)
            Radar.object_in_scanner = true;
    }

    public void end_of_beta()
    {
        drone_source.mute = true;
        turn_off_all();
        End_Panel.SetActive(true);
        drone_source2.loop = true;
        drone_source2.Play();
        Invoke("return_button", 3f);
    }

    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Pause_Panel.SetActive(false);
    }

    public void controls(bool back)
    {
        if (back == false)
            Controls_Panel.SetActive(true);
        else
            Controls_Panel.SetActive(false);
    }

    public void main_menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void activate_button()
    {
        Start_Button.SetActive(true);
    }

    public void continue_button()
    {
        turn_off_all();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void return_button()
    {
        End_Button.SetActive(true);
    }

    public void slider_text_change()
    {
        slider_text.text = "Sensitivity: " + slider.value.ToString();
    }
}
