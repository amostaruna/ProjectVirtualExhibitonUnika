using UnityEngine;
using System.Runtime.InteropServices;
public class Link : MonoBehaviour 
{

	//Parametrik Room
	public void OpenLinkPoster1ParametricRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://ths.li/MHwzbA");
#endif
	}

	public void OpenLinkPoster2ParametricRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://ths.li/yQMaUo");
#endif
	}

	public void OpenLinkPoster3ParametricRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://ths.li/I8X0k1");
#endif
	}

	public void OpenLinkPoster4ParametricRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://ths.li/3IsODj");
#endif
	}

	//Week'n Room
	public void OpenLinkItemWeekNRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.instagram.com/weekn_/");
#endif
	}

	//AAE Room
	public void OpenLinkAAEWeekNRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://drive.google.com/drive/folders/1IPcP2XwKoZie-Yh0f9131YbAED5_4JzH");
#endif
	}
	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}

