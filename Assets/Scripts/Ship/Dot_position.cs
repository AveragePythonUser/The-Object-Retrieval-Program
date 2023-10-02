using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot_position : MonoBehaviour
{
    private Text Dot_X;
    private Text Dot_Y;
    [SerializeField] private GameObject Dot;
    // Start is called before the first frame update
    void Start()
    {
        Dot_X = GameObject.Find("X").GetComponent<Text>();
        Dot_Y = GameObject.Find("Y").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Dot_X.text = "X: " + (Dot.transform.position.x - 325.85f).ToString();
        Dot_Y.text = "Y: " + (Dot.transform.position.y - 205.69f).ToString();
    }
}
