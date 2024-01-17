using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_count : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] TextMeshProUGUI _text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = $"Score {score}";
    }
}
