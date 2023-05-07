using UnityEngine;

public class Bank : MonoBehaviour
{
    public static int PlayerMaxHealth = 60;
    public static int PlayerHealth = 60;
    public static bool GoBase = false;

    public void MakePlayerFullHP()
    {
        PlayerHealth = PlayerMaxHealth;
    }
}
