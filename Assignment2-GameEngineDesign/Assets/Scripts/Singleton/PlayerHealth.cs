using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    private int _health = 100;
    private Text _text;
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        _text = GetComponent<Text>();
        Instance = this;
    }
    public void SubHealth(int value)
    {
        _health -= value;
        _text.text = _health.ToString();
    }
    public int GetHealth()
    {
        return _health;
    }
}
