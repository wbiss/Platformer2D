using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCounterUI : MonoBehaviour
{
    private Text counterText;
    public Font counterFont;

    // Start is called before the first frame update
    void Awake()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.font = counterFont;
        counterText.text = "Collected: " + GameMaster.CollectedItems.ToString();
    }
}
