using UnityEngine;

public enum PlayerModes
{
    Plataforma, TopDown
}
public class PlayerStats : MonoBehaviour
{
    public PlayerModes modes;
    PlayerMovement playMov;

    private void Start()
    {
        playMov = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        switch (modes)
        {
            case PlayerModes.Plataforma:
                playMov.SetPlataformMode();
                break;

            case PlayerModes.TopDown:
                playMov.SetTopDownMode();
                break;
        }
    }

    
}
