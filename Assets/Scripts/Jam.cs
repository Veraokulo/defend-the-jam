using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jam : MonoBehaviour
{
    public static Jam Instance;
    private int _health = 321;
    public Image image;
    private AudioSource _audio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _audio = GetComponent<AudioSource>();
    }

    public void TakeDamage(int v)
    {
        _health -= v;
        image.rectTransform.sizeDelta = new Vector2(32 * _health, 32);
        _audio.Play();
        if (_health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
