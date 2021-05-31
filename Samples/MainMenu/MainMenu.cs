using CustomPackages.Silicom.Player.CursorSystem;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject closing;

    private void Start()
    {
        CursorManager.Instance.SetLockState(false);
    }

    public void QuitApplication()
    {
        menu.SetActive(false);
        closing.SetActive(true);
        GameManager.QuitApplication();
    }

    public void PlayUIClip(AudioClip clip)
    {
        AudioManager.Instance.PlayUIClip(clip);
    }
    
}
