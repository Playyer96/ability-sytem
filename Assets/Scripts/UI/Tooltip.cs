using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerField;
    [SerializeField] private TextMeshProUGUI _contentField;
    [SerializeField] private LayoutElement _layoutElement;
    [SerializeField] private int characterWrapLimit;

    [SerializeField] private RectTransform _rectTransform;

    private Vector2 position;
    private Vector2 pivotPosition;
    private float pivotX;
    private float pivotY;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _layoutElement = GetComponent<LayoutElement>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            SetLenght();
        }

        position = Input.mousePosition;

        pivotX = position.x / Screen.width;
        pivotY = position.y / Screen.height;

        pivotPosition.x = pivotX;
        pivotPosition.y = pivotY;

        _rectTransform.pivot = pivotPosition;
        transform.position = position;
    }

    public void SetText(string name, string description = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            _headerField.gameObject.SetActive(false);
        }
        else
        {
            _headerField.gameObject.SetActive(true);
            _headerField.text = name;
        }

        _contentField.text = description;
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
