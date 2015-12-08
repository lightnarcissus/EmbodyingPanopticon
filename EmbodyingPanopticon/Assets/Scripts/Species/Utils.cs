using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
	class Maybe<T>
	{
		public static Maybe<T> Just(T _data)
		{
			Maybe<T> m = new Maybe<T>();
			m.isset=true;
			m._data=_data;
			return m;
		}
		
		public static Maybe<T> Nothing()
		{
			Maybe<T> m = new Maybe<T>();
			m.isset=false;
			m._data=default(T);
			return m;
		}
		
		public bool isset;
		public T _data;
		
		//what happened to getters/setters?
	}
	
	class Utility
	{
		public static T RandomElement<T>(List<T> list)
		{
			return list[Random.Range(0,list.Count)];
		}
		
		public static void Shuffle<E>(IList<E> list)
	    {
	        if (list.Count > 1)
	        {
	            for (int i = list.Count - 1; i >= 0; i--)
	            {
	                E tmp = list[i];
	                int randomIndex = Random.Range(0,i + 1);
	
	                //Swap elements
	                list[i] = list[randomIndex];
	                list[randomIndex] = tmp;
	            }
	        }
	    }
		
		public static List<E> Shuffled<E>(List<E> inputList)
		{
		     List<E> randomList = new List<E>();
		
		     int randomIndex = 0;
		     while (inputList.Count > 0)
		     {
		          randomIndex = Random.Range(0, inputList.Count); //Choose a random object in the list
		          randomList.Add(inputList[randomIndex]); //add it to the new, random list
		          inputList.RemoveAt(randomIndex); //remove to avoid duplicates
		     }
		
		     return randomList; //return the new random list
		}
		
		public static float NoteToFreq(int n)
		{
			return Mathf.Pow(2.0f, (float)n / 12.0f);
		}
	}
	
}