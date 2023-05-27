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

    private int _iterationsNumber = 0;

    private const int NUMBER_OF_FRAMES = 1000;
    private const int MAX_TRIES = int.MaxValue;
    private const int ENTITIES_GROWTH_STEP = 20;
    private const int AVG_FRAMERATE_THREASHOLD_TO_STOP = 60;

    StreamWriter _sw;

    private void Awake()
    {
        _memory = new float[NUMBER_OF_FRAMES];

        _iterationsNumber++;

        for (int i = 0; i < ENTITIES_GROWTH_STEP; i++)
        {
            Instantiate(_prefab, new Vector3(), Quaternion.identity);
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
        _iterationsNumber++;

        if (_iterationsNumber == MAX_TRIES)
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
            for (int i = 0; i < ENTITIES_GROWTH_STEP; i++)
            {
                Instantiate(_prefab, new Vector3(), Quaternion.identity);
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
