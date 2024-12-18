using UnityEngine;

public class LevelObjectsPosManager : MonoBehaviour
{
    [SerializeField] private Transform[] enemiesPos;
    [SerializeField] private Transform heroPos;

    public Transform[] GetEnemiesPos()
    {
        return enemiesPos;
    }

    public Transform GetHeroPos()
    {
        return heroPos;
    }
}
