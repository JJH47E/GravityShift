using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class infoHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LvlCounter counter = GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>();
        GameObject.Find("Title").GetComponent<TextMeshProUGUI>().text = "Level " + counter.curLvl.ToString() + " Completed";
        GameObject.Find("PB").GetComponent<TextMeshProUGUI>().text = "Your best score: " + PlayerPrefs.GetInt("pb" + counter.minusLevel());
        GameObject.Find("DEV").GetComponent<TextMeshProUGUI>().text = "Best score for level: " + counter.devScore[counter.curLvl - 1];
    }

    // Update is called once per frame
    void Update()
    {
        LvlCounter counter = GameObject.FindWithTag("levelCounter").GetComponent<LvlCounter>();
        GameObject.Find("PB").GetComponent<TextMeshProUGUI>().text = "Your best score: " + PlayerPrefs.GetInt("pb" + counter.minusLevel());
    }
}
