using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignettePulse : MonoBehaviour
{
    [SerializeField] PostProcessVolume m_Volume;
    [SerializeField]Vignette m_Vignette;
    [SerializeField] Color vignetteColor;
    public float maxValue = 0.4f;
    void Start()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);
        m_Vignette.color.Override(vignetteColor);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        GameManager.instance.updateVignette = UpdateMaxValue;
    }
    void Update()
    {
        m_Vignette.intensity.value = Mathf.PingPong(Time.time/2, maxValue);
    }
    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }

    public void UpdateMaxValue(int life)
    {
        if(life <= 10)
        {
            maxValue *= 2;
        }
    }
}
