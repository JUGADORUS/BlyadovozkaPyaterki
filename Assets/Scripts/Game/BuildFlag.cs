using UnityEngine;

public class BuildFlag : MonoBehaviour
{
    [SerializeField] private int _buildValue;

    public static int BuildValue = 0;

    void Start()
    {
        if (BuildValue == 0)
        {
            BuildValue = _buildValue;
        }
    }
}
