using System;
using TMPro;
using UnityEngine;

public class ShowPointsWorth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PointsText;
    private BaseTarget target;

    private void Awake()
    {
        target = this.GetComponent<BaseTarget>();
    }

    private void Start()
    {
        PointsText.text = $"+{target.PointsWorth.ToString()} ";
    }
}