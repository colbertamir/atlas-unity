using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void OpenGitHub()
    {
        OpenURL("https://github.com/colbertamir");
    }

    public void OpenLinkedIn()
    {
        OpenURL("https://www.linkedin.com/in/colbertamir/");
    }

    public void CopyEmailToClipboard()
    {
        string email = "colbertamir1516@gmail.com";
        GUIUtility.systemCopyBuffer = email;
        Debug.Log("Email copied to clipboard: " + email);
    }

    private void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
