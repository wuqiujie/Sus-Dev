using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public Material fogMat;
    private Color FogColor;
    private Color fogColorVariant;
    private float fogDensity;
    public int fogCancelNum = 4;
    // Start is called before the first frame update
    void Start()
    {
        fogDensity = 0.7f;
        FogColor = new Color(1f, 1f, 0.4f, 0.6f);
        fogColorVariant = new Color((1-FogColor.r) / fogCancelNum, (1 - FogColor.g) / fogCancelNum, (1 - FogColor.b) / fogCancelNum, -1* FogColor.a / fogCancelNum);
        fogMat.SetColor("_FogColor", FogColor);
        fogMat.SetFloat("_FogDenisty", fogDensity);
    }
    public void CancelFog(int i)
    {
        if(FogColor.a > 0f)
        {
            Vector4 targetFog = FogColor + i*fogColorVariant;
            Color targetFogColor = new Color(targetFog.x, targetFog.y, targetFog.z, targetFog.w);
            fogDensity -= 0.1f;
            StartCoroutine(FogFade(targetFogColor, 1f));
        }
    }
    private IEnumerator FogFade(Color target, float duration)
    {
        float time = 0;
        Color startValue = FogColor;
        while (time < duration)
        {
            FogColor = Color.Lerp(startValue, target, time / duration);
            fogMat.SetColor("_FogColor", FogColor);
            time += Time.deltaTime / duration;
            yield return null;
        }
        FogColor = target;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CancelFog(1);
        }
    }
}
