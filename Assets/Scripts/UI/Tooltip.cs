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

    [SerializeField] private RectTransform _rectTransform;
    
    //private InputSystemUIInputModule _inputSystemUIInputModule;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            SetLenght();
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        _rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            _headerField.gameObject.SetActive(false);
        }
        else
        {
            _headerField.gameObject.SetActive(true);
            _headerField.text = header;
        }

        _contentField.text = content;
        SetLenght();
    }
    
    public void SetLenght()
    {
        int headerLenght = _headerField.text.Length;
        int contentLenght = _contentField.text.Length;

        _layoutElement.enabled =
            (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;
    }
}
