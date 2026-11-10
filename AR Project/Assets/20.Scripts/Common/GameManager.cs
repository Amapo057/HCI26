using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public TextMeshProUGUI messageText;
    public bool isDrawing = false;
    public Camera arCamera;
    Vector3 prevPosition = new Vector3(0, 0, 0);
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    static GameManager m_instance;

    public void GameOver()
    {
        Application.Quit();
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }

    private void Update()
    {
        DrawSpheres();
    }
    void DrawSpheres()
    {
        if (isDrawing == false) return;

        Vector3 currentPosition = arCamera.ScreenToWorldPoint(
            new Vector3(Screen.width/2, Screen.height/2, 0.5f));
        
        float distance = Vector3.Distance(currentPosition, prevPosition);
        if(distance < 0.3) return;

        GameObject go = Instantiate(spherePrefab, currentPosition, Quaternion.identity);
        go.transform.parent = transform;
        prevPosition = go.transform.position;
    }
}
