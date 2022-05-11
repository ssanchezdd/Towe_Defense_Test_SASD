using UnityEngine;
using TMPro;

public class LivesUI_S : MonoBehaviour
{

    public TextMeshProUGUI livesText;

    private void Update()
    {
        livesText.text = "Lives: " + PlayerStats_S.lives.ToString();
    }
}
