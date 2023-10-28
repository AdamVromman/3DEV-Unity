using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"{GameControl.roundTime.ToString("0.00")}s\n{(GameControl.previousRecord == 0f ? "-:--" : GameControl.previousRecord.ToString("0.00"))}s";
    }
}
