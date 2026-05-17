using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LocalizedSign : MonoBehaviour
{
    [SerializeField] private LocalizedString signText;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private GameObject dialogBox;

    private void Start()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
        }

        if (dialogText != null)
        {
            dialogText.text = signText.GetLocalizedString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
    }
}