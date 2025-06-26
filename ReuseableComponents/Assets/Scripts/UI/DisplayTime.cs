using TMPro;
using UnityEngine;

namespace UI
{
    public class DisplayTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TimeText;
        [SerializeField] private string prefix = "Time Left: ";

        private float currentTime = 0;

        private void Awake()
        {
            if (TimeText == null)
            {
                TimeText = GetComponent<TextMeshProUGUI>();
            }

            UpdateText();
        }
        public void SetTime(float time)
        {
            currentTime = time;
            UpdateText();
        }

        private void UpdateText()
        {
            if (TimeText != null)
            {
                TimeText.text = prefix + Mathf.Round(currentTime);
            }
        }
    }
}