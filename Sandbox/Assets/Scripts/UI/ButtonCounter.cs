using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCounter : MonoBehaviour
{
    public int _counter;
    // Start is called before the first frame update
    void Start()
    {
        _counter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        ++_counter;
    }
}
