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
	public void OpenLinkDokumentasiAAERoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://drive.google.com/drive/folders/1IPcP2XwKoZie-Yh0f9131YbAED5_4JzH?usp=sharing");
#endif
	}
	//seminar Room
	public void OpenLinkSeminarBOSRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://youtu.be/GvxbjcJJMSQ");
#endif
	}
	public void OpenLinkSeminarAAERoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://youtu.be/AUgPacVTWhY");
#endif
	}

	//Hall of Fame
	public void OpenLinkEEHallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114642729/EXTERNAL-EXAMINATION-77-78");
#endif
	}
	public void OpenLinkSayembaraHallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://youtu.be/AUgPacVTWhY");
#endif
	}
	public void OpenLinkSPA1HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114641205/BEST-OF-STUDIO-2021-SEMESTER-1");
#endif
	}
	public void OpenLinkSPA2HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114641357/BEST-OF-STUDIO-2021-SEMESTER-2");
#endif
	}
	public void OpenLinkSPA3HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114641637/BEST-OF-STUDO-2021-SEMESTER-3");
#endif
	}
	public void OpenLinkSPA4HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114641709/BEST-OF-STUDO-2021-SEMESTER-4");
#endif
	}
	public void OpenLinkSPA5HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114641967/BEST-OF-STUDIO-2021-SEMESTER-5");
#endif
	}
	public void OpenLinkSPA6HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114642209/BEST-OF-STUDIO-2021-SEMESTER-6");
#endif
	}
	public void OpenLinkSPA7HallOfFameRoom()
	{
#if (!UNITY_EDITOR)
		openWindow("https://www.behance.net/gallery/114642637/BEST-OF-SYUDIO-2021-SEMESTER-7");
#endif
	}
	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}

