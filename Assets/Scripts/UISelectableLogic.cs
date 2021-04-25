using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Visual indicator and thin logic on selectable components
public class UISelectableLogic : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float startTime = 0f;

    [Range(0,1)]
    public float XAnimationIntensity;
    [Range(0,1)]
    public float YAnimationIntensity;
    [Range(0,1)]
    public float YAnimationMovementIntensity = 0.5f;
    [Range(0, 2000)]
    public int AnimationSpeed;

    private Vector3 originalScale;
    private Vector3 originalPosition;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;
        startTime = Time.time;
    }

    void Update() {
        if(spriteRenderer.enabled) {
            var timeDiff = (Time.time - startTime) * 1000;
            float value = Mathf.Sin(((timeDiff % AnimationSpeed) / AnimationSpeed) * Mathf.PI * 2);
            Vector2 modifier = new Vector2(value * (XAnimationIntensity/2f), value * (YAnimationIntensity/2));
            Vector2 temp = (Vector2)originalScale + modifier;
            transform.localScale = new Vector3(temp.x, temp.y, 1);
            modifier = new Vector2(0, value * (YAnimationMovementIntensity/2));
            temp = (Vector2)originalPosition + modifier;
            transform.localPosition = temp;
        } else {
            // Make sure the original scale is reset so we don't get funny bugs
            transform.localScale = originalScale;
            transform.localPosition = originalPosition;
        }
    }

    public void ToggleSelectable(bool value) {
        spriteRenderer.enabled = value;
    }
}
