using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Camera_shaker : MonoBehaviour
{
    /// <summary>
    ///  credits https://www.youtube.com/watch?v=lq7y0thMN1M&t=13s
    /// </summary>
    // Start is called before the first frame update

    // Update is called once per frame

    private IEnumerator Camera_Shake_Coroutine(float duration, float offset_strength)
    {
        float elapsed = 0.0f;
        float current_magnitude = 1f;

        while (elapsed < duration)
        {

            float x = (Random.value - 0.5f) * current_magnitude * offset_strength;
            float y = (Random.value - 0.5f) * current_magnitude * offset_strength;

            transform.localPosition = new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            current_magnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));
            yield return null;
        }
        transform.localPosition = Vector3.zero;
    }
}
