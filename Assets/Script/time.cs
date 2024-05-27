using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class time : MonoBehaviour
{
    public TMP_Text currentTime;
    // Update is called once per frame
    void Update()
    {
        current();
    }

    public void current()
    {
        DateTime time = DateTime.Now;
        CultureInfo culture = new CultureInfo("en-US");
        currentTime.text = time.ToString("t", culture);
    }

}
