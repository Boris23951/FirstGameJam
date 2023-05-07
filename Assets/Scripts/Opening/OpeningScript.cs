using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    public GameObject choiceHelper;
    private void Start()
    {
        choiceHelper.SetActive(false);
    }
    public void RightButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void LeftButton()
    {
        choiceHelper.SetActive(true); 
    }
}
