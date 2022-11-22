using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerField;
    [SerializeField] private TextMeshProUGUI _contentField;
    [SerializeField] private LayoutElement _layoutElement;
    [SerializeField] private int characterWrapLimit;

    private void Update()
    {
        int headerLenght = _headerField.text.Length;
        int contentLenght = _contentField.text.Length;

        _layoutElement.enabled =
            (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            
        }
    }
}
