using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{

    public static int pinCount;

    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        pinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = pinCount.ToString();
    }
}
