using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollpanel : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void arrangeButtons(int n){
        Debug.Log(Panel.GetComponent<RectTransform>().position);
        Panel.GetComponent<RectTransform>().position = new Vector3(Panel.GetComponent<RectTransform>().position.x, Panel.GetComponent<RectTransform>().position.y - (50 * (n - 5)), Panel.GetComponent<RectTransform>().position.z);
        Debug.Log(Panel.GetComponent<RectTransform>().sizeDelta);
        Panel.GetComponent<RectTransform>().sizeDelta = new Vector2(Panel.GetComponent<RectTransform>().sizeDelta.x, 500 + ((n - 5) * 100));
    }
}
