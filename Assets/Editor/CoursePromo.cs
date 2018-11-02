using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CoursePromo : EditorWindow
{
    private static Texture _courseTexture;

    private static Texture _vk;
    private static Texture _telegram;
    private static Texture _Insta;
    private static Texture _YouTube;
    private static GUIStyle _titleStyle;

    [MenuItem("Sakutin / Cousrse Promo")]
    public static void Init()
    {
        return;
        _courseTexture = Resources.Load<Texture>("Courses");
        _vk = Resources.Load<Texture>("VK");
        _telegram = Resources.Load<Texture>("Telega");
        _Insta = Resources.Load<Texture>("Instagram");
        _YouTube = Resources.Load<Texture>("YouTube");
        _titleStyle = new GUIStyle()
        {
            padding = new RectOffset(15, 15, 15, 15),
            fontSize = 25,
            alignment = TextAnchor.MiddleCenter
        };
        CoursePromo window = (CoursePromo)GetWindow(typeof(CoursePromo));
        window.Show();
    }

    public void OnGUI()
    {
        GUILayout.Label("Мои курсы на Udemy", _titleStyle);
        if (GUILayout.Button(_courseTexture))
        {
            Application.OpenURL("https://www.udemy.com/user/roman-sakutin/");
        }

        GUILayout.Label("Я в соц. сетях:", _titleStyle);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(_vk, GUILayout.Width(100), GUILayout.Height(100)))
        {
            Application.OpenURL("https://vk.com/rsakutin");
        }
        if (GUILayout.Button(_telegram, GUILayout.Width(100), GUILayout.Height(100)))
        {
            Application.OpenURL("https://t.me/csharp_faggots_fan_club");
        }
        if (GUILayout.Button(_Insta, GUILayout.Width(100), GUILayout.Height(100)))
        {
            Application.OpenURL("http://instagram.com/sakutinhuytin");
        }
        if (GUILayout.Button(_YouTube, GUILayout.Width(100), GUILayout.Height(100)))
        {
            Application.OpenURL("https://www.youtube.com/channel/UCUEQBzSZx65-FcVwce8HYNQ");
        }
        GUILayout.EndHorizontal();
    }
}


[InitializeOnLoad]
public class Startup
{
    static Startup()
    {
        CoursePromo.Init();
    }
}