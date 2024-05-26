using Firebase.Auth;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public TMP_InputField email;
    public TMP_InputField password;
    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void SignUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("회원가입 취소");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("회원가입 실패");
            }
            else if (task.IsCompleted)
            {
                Debug.LogFormat("회원가입 성공");
                AuthResult newUser = task.Result;
            }
        });
    }

    public void SignIn()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("로그인 실패");
            }
            else if (task.IsCompleted)
            {
                Debug.LogFormat("로그인 성공");
                AuthResult newUser = task.Result;
                SceneManager.LoadScene("Dashboard");
            }
        });
    }

    // public void SignOut()
    // {
    //     auth.SignOut();
    //     Debug.LogFormat("로그아웃");
    // }

}
