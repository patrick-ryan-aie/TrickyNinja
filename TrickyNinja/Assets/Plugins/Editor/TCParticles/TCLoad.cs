using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class TCLoad
{
	static TCLoad()
	{
		if (!SystemInfo.supportsComputeShaders)
		{
			Debug.Log("Compute shaders not supported! Did you not turn on DX11 in player settings?");
		}
	}
}