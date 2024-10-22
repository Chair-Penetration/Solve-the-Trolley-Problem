using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationPopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpText;  
    [SerializeField] private float _fadeDuration = 2f;  // Duration of the fade-out effect

    public TextMeshProUGUI TmpText { get { return _tmpText; } }
    public float FadeDuration { get { return _fadeDuration; } }

    private void Start()
    {
        // Start the fade out coroutine after 5 seconds
        StartCoroutine(FadeOutText(3f));
    }

    // Coroutine to handle fading out the text
    public IEnumerator FadeOutText(float waitTime)
    {
        // Wait for the specified time before starting to fade
        yield return new WaitForSeconds(waitTime);

        // Get the original color of the text
        Color originalColor = TmpText.color;

        // Gradually fade out the text over the fadeDuration
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / FadeDuration)
        {
            // Update the alpha value of the text color
            TmpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        // Ensure the text is fully transparent at the end
        TmpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        this.gameObject.SetActive(false);
        TmpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 225); // In case I want to reload the location message
    }
}
