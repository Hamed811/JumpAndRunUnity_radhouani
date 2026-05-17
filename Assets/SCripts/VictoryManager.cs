using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup victoryCanvas;
    [SerializeField] private MageController mageController;

    public void ShowVictory()
    {
        victoryCanvas.alpha = 1f;
        victoryCanvas.interactable = true;
        victoryCanvas.blocksRaycasts = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (mageController != null)
        {
            mageController.enabled = false;
        }
    }
}