using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class DisplayScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private string prefix = "Score: ";

        private int currentPoints = 0;

        private void Awake()
        {
            if (scoreText == null)
            {
                scoreText = GetComponent<TextMeshProUGUI>();
            }

            UpdateText();
        }
        public void SetPoints(int points)
        {
            currentPoints = points;
            UpdateText();
        }
        private void UpdateText()
        {
            if (scoreText != null)
            {
                scoreText.text = prefix + currentPoints;
            }
        }
    }
}