using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeacilSubtitle : Subtitle {

    private void Awake()
    {
        SubtitleSystem.specialSub = this;
    }
}
