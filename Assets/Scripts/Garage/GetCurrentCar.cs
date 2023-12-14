using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCurrentCar : MonoBehaviour
{
    [SerializeField] private Podium _podium;

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void KeepCurrentCar()
    {
        int indexOfCurrentCar;
        indexOfCurrentCar = _podium._currentIndex;
        StaticData.valueToKeep = indexOfCurrentCar;
        MusicManager.Instance.Switch(indexOfCurrentCar + 1);
        MusicManager.Instance.PickCar();
        SceneManager.LoadScene(0);
    }
}
