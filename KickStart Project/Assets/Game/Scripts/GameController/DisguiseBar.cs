using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisguiseBar : MonoBehaviour
{
  
    public float disguiseLevel;
    public Image bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = disguiseLevel / 100;
    }
}
