using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestBubble : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _count;

    public void SetRequest(int count, int variantType)
    {
        _count.text = count.ToString();
        SetColor(variantType);
    }

    public void ChangeCount(int value)
    {
        _count.text = value.ToString();
    }

    private void SetColor(int variantType)
    {
        if (variantType == 1)
            _image.color = new Color(1, 0.75f, 0.33f);
        else
            _image.color = Color.red;

    }
}
