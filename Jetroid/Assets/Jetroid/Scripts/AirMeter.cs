using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirMeter : MonoBehaviour
{
    public float air = 10f;
    public float maxAir = 10f;
    public float airBurnRate = 0.5f;

    private Player player;
    private Slider slider;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (player == null)
            return;

        if (air > 0)
        {
            air -= Time.deltaTime * airBurnRate;
            slider.value = air / maxAir;
        }
        else
        {
            Explode script = player.GetComponent<Explode>();
            script.OnExplode();
        }
    }
}
