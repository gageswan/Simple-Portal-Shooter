using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    RectTransform handle;

    public PlatformGameManager pgm;

    void Start() {
        handle = GetComponentInChildren<RectTransform>();
    }

    void Update() {

        float healthbarSize = 16 * (pgm.playerMaxHealth - (pgm.playerMaxHealth - pgm.playerHealth));
        handle.sizeDelta = new Vector2(healthbarSize, 20);
    }
}
