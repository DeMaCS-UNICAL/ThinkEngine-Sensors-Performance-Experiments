using System;
using System.Collections.Generic;
using UnityEngine;
using ThinkEngine.Mappers;
using static ThinkEngine.Mappers.OperationContainer;

namespace ThinkEngine
{
    class GameObjectSensor2 : Sensor
    {
		private int counter;
        private object specificValue;
        private Operation operation;
		private BasicTypeMapper mapper;
		private List<List<int>> values = new List<List<int>>();
		private List<bool> isIndexActive = new List<bool>();
		private List<int> indicies = new List<int>();

		/*
		//Singleton
        protected static Sensor instance = null;

        internal static Sensor Instance
        {
            get
            {
                if (instance == null)
                {
					instance = new GameObjectSensor2();
                }
                return instance;
            }
        }*/

		internal override void Initialize(SensorConfiguration sensorConfiguration)
		{
            // Debug.Log("Initialize method called!");
			this.gameObject = sensorConfiguration.gameObject;
			ready = true;
			mapper = (BasicTypeMapper)MapperManager.GetMapper(typeof(int));
			operation = mapper.OperationList()[0];
			counter = 0;
			mappingTemplate = "gameObjectlist(gameObject,objectIndex(1),{0},{1})." + Environment.NewLine;			Example Example0 = gameObject.GetComponent<Example>();
			if(Example0 == null) return;
			List<int> list1 = Example0.list;
			if(list1 == null) return;

			for(int i = 0; i < list1.Count; i++)
			{
				indicies.Add((i));
				isIndexActive.Add(true);
				values.Add(new List<int>());
			}

		}

		internal override void Destroy()
		{
            // Debug.Log("Destroy method called!");
			//instance = null;
		}

		internal override void Update()
		{
            // Debug.Log("Update method called!");
			if(!ready)
			{
				return;
			}
			if(!invariant || first)
			{
				Example Example0 = gameObject.GetComponent<Example>();
				if(Example0 == null) return;
				List<int> list1 = Example0.list;
				if(list1 == null) return;

				if(list1.Count > isIndexActive.Count)
				{
					for(int i = isIndexActive.Count; i < list1.Count; i++)
					{
						indicies.Add(i);
						isIndexActive.Add(true);
						values.Add(new List<int>());
					}
				}
				else if(list1.Count < isIndexActive.Count)
				{
					for(int i = list1.Count; i < isIndexActive.Count; i++)
					{
						indicies.RemoveAt(isIndexActive.Count - 1);
						isIndexActive.RemoveAt(isIndexActive.Count - 1);
						values.RemoveAt(isIndexActive.Count - 1);
					}
				}
				for(int i = 0; i < values.Count; i++)
				{
					if (values[i].Count == 200)
					{
						values[i].RemoveAt(0);
					}
					values[i].Add(list1[indicies[i]]);
				}
			}
		}

		internal override string Map()
		{
            // Debug.Log("Map method called!");
			string mapping = string.Empty;
			for(int i = 0; i < values.Count; i++)
			{
				if(!isIndexActive[i]) continue;
				object operationResult = operation(values[i], specificValue, counter);
				mapping = string.Concat(mapping, string.Format(mappingTemplate, indicies[i], BasicTypeMapper.GetMapper(operationResult.GetType()).BasicMap(operationResult)));
			}
			return mapping;
		}
    }
}
