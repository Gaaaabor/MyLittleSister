using UnityEngine;

public class HorrorCitySingleton<T> : MonoBehaviour where T : HorrorCitySingleton<T>
{
	/// <summary>
	/// The instance.
	/// </summary>
	static T instance;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();

				if (instance == null)
					Debug.LogWarningFormat("Trying to access {0}, which not exists in the scene!", typeof(T).Name);
			}

			return instance;
		}
	}

	public static bool HasInstance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<T>();

			return instance != null;
		}
	}

	public virtual void Awake()
	{
		if (instance != null && instance != this)
		{
			Debug.LogWarningFormat("Only one {0} instance is allowed in the scene!", typeof(T).Name);
			gameObject.SetActive(false);
			return;
		}

		instance = this as T;
	}
}