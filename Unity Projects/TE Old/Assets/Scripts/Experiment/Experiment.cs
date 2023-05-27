using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

// Run a performance experiment
public class Experiment : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private ExperimentTimer _experimentTimer;

    private float[] _memory;
    private int _indexOfMemory = 0;

    private int[] _numberOfEntities;
    private int _indexOfNumberOfEntities = 0;

    private const int NUMBER_OF_FRAMES = 1000;
    private const int NUMBER_OF_TRIES = 51;
    private const int ENTITIES_GROWTH_STEP = 10;
    private const int AVG_FRAMERATE_THREASHOLD_TO_STOP = 30;

    StreamWriter _sw;

    private void Awake()
    {
        _numberOfEntities = new int[NUMBER_OF_TRIES];

        for(int i = 0; i < _numberOfEntities.Length; i++)
        {
            _numberOfEntities[i] = i * ENTITIES_GROWTH_STEP;
        }

        _memory = new float[NUMBER_OF_FRAMES];

        _indexOfNumberOfEntities++;

        for (int i = _numberOfEntities[_indexOfNumberOfEntities - 1]; i < _numberOfEntities[_indexOfNumberOfEntities]; i++)
        {
            GameObject istance = Instantiate(_prefab, new Vector3(), Quaternion.identity);
        }

#if UNITY_EDITOR
        _sw = File.CreateText(string.Format("Assets/Benchmark.txt"));
#else
        _sw = File.CreateText(string.Format("Benchmark.txt"));
#endif

        enabled = false;
    }

    private void OnDisable()
    {
        _indexOfNumberOfEntities++;

        if (_indexOfNumberOfEntities == _numberOfEntities.Length)
        {
            _sw.Close();

#if UNITY_EDITOR
            AssetDatabase.Refresh();
            EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
        else
        {
            for (int i = _numberOfEntities[_indexOfNumberOfEntities - 1]; i < _numberOfEntities[_indexOfNumberOfEntities]; i++)
            {
                GameObject istance = Instantiate(_prefab, new Vector3(), Quaternion.identity);
            }

            _indexOfMemory = 0;
        }
    }

    private void LateUpdate()
    {
        if (_indexOfMemory >= NUMBER_OF_FRAMES)
        {
             WriteOnDisk();

            if(_memory.Length / Queryable.Sum(_memory.AsQueryable()) <= AVG_FRAMERATE_THREASHOLD_TO_STOP)
            {
                _sw.Close();

#if UNITY_EDITOR
                AssetDatabase.Refresh();
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
            else
            {
                enabled = false;
                _experimentTimer.enabled = true;
            }
        }
        else
        {
            _memory[_indexOfMemory] = Time.unscaledDeltaTime;
            _indexOfMemory++;
        }
    }

    private void WriteOnDisk()
    {
        for(int i = 0; i < _memory.Length; i++)
        {
            _sw.Write(string.Format("{0}\t", _memory[i]));
        }
        _sw.Write("\n");
    }
}
