using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_manager : MonoBehaviour
{
    public GameObject credits_panel;
    public GameObject black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void play()
    {
        SceneManager.LoadScene("SampleScene");
        credits_panel.SetActive(false);
    }
    public void credits()
    {
        credits_panel.SetActive(true);
        black.SetActive(false);
    }
    public void stop_credits()
    {
        credits_panel.SetActive(false);
        black.SetActive(true);
    }
}
