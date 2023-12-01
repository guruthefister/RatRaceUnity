using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RatRace;

public class Login : MonoBehaviour
{
    [Header("SignIn")]
    public InputField SignInName;
    public InputField SignInPwd;
    public Text Error; 
    public GameObject SignIn;

    [Header("SignUp")]
    public InputField SignUpName;
    public InputField SignUpPwd;
    public InputField SignUpConPwd;
    public GameObject SignUp;

    public static Player CurrentPlayer;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            CurrentPlayer = ServiceManager.Instance.raceManager.PlayerLogin(SignInName.text, SignInPwd.text);
            if (CurrentPlayer == null)
            {
                Error.enabled = true;
                return;
            }
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        { 
            if (SignIn.active)
            {
                if (SignInName.isFocused)
                {
                    SignInPwd.Select();
                    return;
                }
                SignInName.Select();
                return;
            }

            if (SignUp.active)
            {
                if (SignUpName.isFocused)
                {
                    SignUpPwd.Select();
                    return;
                }
                if (SignUpPwd.isFocused)
                {
                    SignUpConPwd.Select();
                    return;
                }
                SignUpName.Select();
                return;
            }
        }
    }
}
