using TMPro;
using UnityEngine;

public class TextGUICOntroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGUI;
    public void ChangeText(object text)
    {
        _textGUI.text = text.ToString();
    }
}
