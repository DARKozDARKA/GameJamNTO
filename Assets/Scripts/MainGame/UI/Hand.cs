using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] private Sprite _avalibleSprite;
    [SerializeField] private Sprite _notAvalibleSprite;
    [SerializeField] private Image _image;


    public void SetAvalible(bool isAvalible)
    {
        if (isAvalible)
            _image.sprite = _avalibleSprite;
        else
            _image.sprite = _notAvalibleSprite;
    }
}
