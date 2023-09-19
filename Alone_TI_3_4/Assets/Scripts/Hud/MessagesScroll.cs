using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesScroll : MonoBehaviour
{
    [SerializeField] RectTransform rt;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    private void Start()
    {
        if(rt == null)
        {
            rt = GetComponent<RectTransform>();
        }
    }

    public void OnFocus()
    {
        rt.sizeDelta = new Vector2(rt.rect.width, maxHeight); 
    }

    public void OnDefocus()
    {
        rt.sizeDelta = new Vector2(rt.rect.width, minHeight);
    }
}
