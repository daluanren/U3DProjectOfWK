﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FadeSprite : MonoBehaviour
{

    [SerializeField]
    private bool m_startsVisible = false;
    [SerializeField]
    private bool m_fadeOnAwake = false;
    [SerializeField]
    private bool m_continuous = false;
    [SerializeField]
    private float m_fadeSpeed = 1.0f;
    [SerializeField]
    private float m_minAlpha = 0;
    [SerializeField]
    private float m_maxAlpha = 1.0f;



    private SpriteRenderer m_sprite = null;


    public bool isVisible
    {
        get
        {
            if (m_sprite.color.a == m_maxAlpha)
                return true;
            else return false;
        }
    }
    public bool isHidden
    {
        get
        {
            if (m_sprite.color.a == m_minAlpha)
                return true;
            else return false;
        }
    }
    public float fadeSpeed
    {
        get { return m_fadeSpeed; }
        set { m_fadeSpeed = value; }
    }
    public float minAlpha
    {
        get { return m_minAlpha; }
        set { m_minAlpha = value; }
    }
    public float maxAlpha
    {
        get { return m_maxAlpha; }
        set { m_maxAlpha = value; }
    }
    public bool continuous
    {
        get { return m_continuous; }
        set { m_continuous = value; }
    }

    void Start()
    {
        m_sprite = this.transform.GetComponent<SpriteRenderer>();
        Debug.Log("!!!sprite renderer:"+m_sprite);
        if (m_sprite == null)
        {
            Debug.LogError("FadeSprite: No SpriteRenderer found!");
            return;
        }


        if (m_startsVisible)
        {
            Color spriteColor = m_sprite.color;
            spriteColor.a = m_maxAlpha;
            m_sprite.color = spriteColor;
            if (m_fadeOnAwake)
                StartCoroutine(FadeOut());
        }
        else
        {
            Color spriteColor = m_sprite.color;
            spriteColor.a = m_minAlpha;
            m_sprite.color = spriteColor;
            if (m_fadeOnAwake)
                StartCoroutine(FadeIn());
        }
    }


    public IEnumerator FadeIn()
    {
        this.gameObject.SetActive(true);
        Debug.Log("黑屏淡入！");

        Color spriteColor = m_sprite.color;

        while (spriteColor.a < m_maxAlpha)
        {
            yield return null;
            spriteColor.a += m_fadeSpeed * Time.deltaTime;
            m_sprite.color = spriteColor;
        }

        spriteColor.a = m_maxAlpha;
        m_sprite.color = spriteColor;

        if (m_continuous)
            StartCoroutine(FadeOut());
    }


    public IEnumerator FadeOut()
    {
        Debug.Log("黑屏淡出！");
        Color spriteColor = m_sprite.color;

        while (spriteColor.a > m_minAlpha)
        {
            yield return null;
            spriteColor.a -= m_fadeSpeed * Time.deltaTime;
            m_sprite.color = spriteColor;
        }
        spriteColor.a = m_minAlpha;
        m_sprite.color = spriteColor;

        if (m_continuous)
            StartCoroutine(FadeIn());
    }

}