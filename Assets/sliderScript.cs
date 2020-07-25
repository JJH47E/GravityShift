using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    private Slider slider; // slider.value: max - 1; min - 0.

    void awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        Debug.Log(gameObject.GetComponent<Transform>().position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addProgress(float toAdd){
        slider.value += toAdd;
    }

    public float getValue(){
        return slider.value;
    }

    public void resetAndHide(){
        gameObject.GetComponent<Transform>().position = new Vector3(0f, -377.75f, 0f);
        Debug.Log(gameObject.GetComponent<Transform>().position);
        slider.value = 0f;
    }

    public void appear(){
        gameObject.GetComponent<Transform>().position = new Vector3(345.5f, 19.9f, 4.3f);
        Debug.Log(gameObject.GetComponent<Transform>().position);
    }
}
