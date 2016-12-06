// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System;
using AOT;
using System.Runtime.InteropServices;

public class GLinkiOS : MonoBehaviour, IGLink
{
	#if UNITY_IPHONE
	[DllImport("__Internal")]
	public static extern void _InitGLink(string consumerKey, string consumerSecret, int cafeId);

	[DllImport("__Internal")]
	public static extern void _InitGLinkForGlobal(string neoIdConsumerKey, int globalCafeId, string language);

	[DllImport("__Internal")]
	public static extern void _ExecuteMain();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteArticlePost(int menuId, string subject, string content);
	
	[DllImport("__Internal")]
	public static extern void _ExecuteArticlePostWithImage(int menuId, string subject, string content, string filePath);
	
	[DllImport("__Internal")]
	public static extern void _ExecuteArticlePostWithVideo(int menuId, string subject, string content, string filePath);
	
	[DllImport("__Internal")]
	public static extern void _ExecuteNotice();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteEvent();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteMenu();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteProfile();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteArticle(int articleId);
	
	[DllImport("__Internal")]
	public static extern void _SyncGameUserId(string gameUserId);
		
	[DllImport("__Internal")]
	public static extern string _GetCafeLangCode();
	
	[DllImport("__Internal")]
	private static extern void _ShowMessageToast(string message);
	
	[DllImport("__Internal")]
	private static extern void _SaveCameraRoll(string path);
	
	[DllImport("__Internal")]
	private static extern void _SetSDKDidLoadDelegate(NCSDKDidLoadDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKDidUnLoadDelegate(NCSDKDidUnLoadDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKJoinedCafeDelegate(NCSDKJoinedCafeDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKPostedArticleAtMenuDelegate(NCSDKPostedArticleAtMenuDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKPostedCommentAtArticleDelegate(NCSDKPostedCommentAtArticleDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKWidgetPostAriticleWithImageCallback(NCSDKWidgetPostAriticleWithImageDelegate callback);
	[DllImport("__Internal")]
	private static extern void _SetSDKDidVoteAtArticleDelegate(NCSDKDidVoteAtArticleDelegate callback);
	
	[DllImport("__Internal")]
	private static extern void _StartWidget();
	[DllImport("__Internal")]
	private static extern void _StopWidget();
	[DllImport("__Internal")]
	private static extern void _SetUseWidgetVideoRecord(bool useVideoRecord);
	[DllImport("__Internal")]
	private static extern void _SetShowWidgetWhenUnloadSDK(bool useWidget);
	
	// imsi
	[DllImport("__Internal")]
	private static extern void _ExecuteCaptureScreenshopAndPostArticle();
	
	[DllImport("__Internal")]
	public static extern void _ExecuteEtc();
	
	#endif
	
	#if UNITY_IPHONE
	delegate void NCSDKDidLoadDelegate();
	[MonoPInvokeCallback(typeof(NCSDKDidLoadDelegate))]
	public static void _NCSDKDidLoadCallback () {
//		_ShowMessageToast ("Did Load sdk");
	}
	
	delegate void NCSDKDidUnLoadDelegate();
	[MonoPInvokeCallback(typeof(NCSDKDidUnLoadDelegate))]
	public static void _NCSDKDidUnLoadCallback () {
//		_ShowMessageToast ("Did UnLoad sdk");
	}
	
	delegate void NCSDKJoinedCafeDelegate();
	[MonoPInvokeCallback(typeof(NCSDKJoinedCafeDelegate))]
	public static void _NCSDKJoinedCafeCallback () {
//		_ShowMessageToast ("Joined Cafe");
	}

	delegate void NCSDKPostedArticleAtMenuDelegate(int menuId, int imageCount, int videoCount);
	[MonoPInvokeCallback(typeof(NCSDKPostedArticleAtMenuDelegate))]
	public static void _NCSDKPostedArticleAtMenuCallback (int menuId, int imageCount, int videoCount) {
//		String message = String.Format ("Posted Article at {0} image : {1} video : {2}", menuId, imageCount, videoCount);
//		_ShowMessageToast (message);
	}

	delegate void NCSDKPostedCommentAtArticleDelegate(int articleId);
	[MonoPInvokeCallback(typeof(NCSDKPostedCommentAtArticleDelegate))]
	public static void _NCSDKPostedCommentAtArticleCallback (int articleId) {
//		_ShowMessageToast ("Posted Comment at " + articleId);
	}

	delegate void NCSDKWidgetPostAriticleWithImageDelegate();
	[MonoPInvokeCallback(typeof(NCSDKWidgetPostAriticleWithImageDelegate))]
	public static void _NCSDKWidgetPostAriticleWithImageCallback () {
//		_ShowMessageToast ("Post Article With Image" );
		
		string name = "CafeSdkController";
		GameObject obj = GameObject.Find (name);
		if (obj == null) {
			obj = new GameObject ("CafeSdkController");
			obj.AddComponent<GLinkiOS> ();
		}
		
		_ExecuteCaptureScreenshopAndPostArticle ();
	}
	
	delegate void NCSDKDidVoteAtArticleDelegate(int articleId);
	[MonoPInvokeCallback(typeof(NCSDKDidVoteAtArticleDelegate))]
	public static void _NCSDKDidVoteAtArticleCallback (int articleId) {
//		_ShowMessageToast ("Did Vote at " + articleId);
	}
	
	
	IEnumerator CoFunction () {
		yield return new WaitForEndOfFrame();
	}
	
	public void executeCaptureScreenshopAndPostArticle(string dummy) {
		// For iOS , For Widget
		// Game ScreenShot Code
		StartCoroutine (this.CoFunction ());
		
		Texture2D image = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
		image.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0, true);
		image.Apply ();
		
		byte[] bytes = image.EncodeToPNG();
		string path = Application.persistentDataPath + "/GLShareImage.png";
		File.WriteAllBytes(path, bytes);		
		
		GLink.sharedInstance().executeArticlePostWithImage(5, "", "", path);
		
	}
	#endif
	
	public GLinkiOS() {
		#if UNITY_IPHONE
		_InitGLink(GLinkConfig.NaverLoginClientId, GLinkConfig.NaverLoginClientSecret, GLinkConfig.CafeId);
//		_InitGLinkForGlobal(GLinkConfig.NeoIdConsumerKey, GLinkConfig.GlobalCafeId, GLinkConfig.Language);

		//set callback funcs
		_SetSDKDidLoadDelegate(_NCSDKDidLoadCallback);
		_SetSDKDidUnLoadDelegate(_NCSDKDidUnLoadCallback);
		_SetSDKJoinedCafeDelegate(_NCSDKJoinedCafeCallback);
		_SetSDKPostedArticleAtMenuDelegate(_NCSDKPostedArticleAtMenuCallback);
		_SetSDKPostedCommentAtArticleDelegate(_NCSDKPostedCommentAtArticleCallback);
		_SetSDKWidgetPostAriticleWithImageCallback(_NCSDKWidgetPostAriticleWithImageCallback);
		_SetSDKDidVoteAtArticleDelegate(_NCSDKDidVoteAtArticleCallback);
		#endif
	}
	
	
	public void executeHome() {
		#if UNITY_IPHONE 
		_ExecuteMain ();
		#endif
	}
	
	public void executeNotice() {
		#if UNITY_IPHONE 
		_ExecuteNotice ();
		#endif
	}
	
	public void executeEvent() {
		#if UNITY_IPHONE 
		_ExecuteEvent ();
		#endif
	}
	
	public void executeMenu() {
		#if UNITY_IPHONE 
		_ExecuteMenu ();
		#endif
	}
	
	public void executeProfile() {
		#if UNITY_IPHONE 
		_ExecuteProfile ();
		#endif
	}
	
	public void executeArticle (int articleId) {
		#if UNITY_IPHONE 
		_ExecuteArticle (articleId);
		#endif
	}
	
	public void executeArticlePost(int menuId, string subject, string content) {
		#if UNITY_IPHONE
		_ExecuteArticlePost(menuId, subject, content);
		#endif
	}
	
	public void executeArticlePostWithImage(int menuId, string subject, string content, string filePath) {
		#if UNITY_IPHONE
		_ExecuteArticlePostWithImage(menuId, subject, content, filePath);
		#endif
	}
	
	public void executeArticlePostWithVideo(int menuId, string subject, string content, string filePath) {
		#if UNITY_IPHONE
		_ExecuteArticlePostWithVideo(menuId, subject, content, filePath);
		#endif
	}
	
	public void syncGameUserId (string gameUserId) {
		#if UNITY_IPHONE 
		_SyncGameUserId(gameUserId);
		#endif
	}
	public void executeMore() {
		#if UNITY_IPHONE 
		_ExecuteEtc ();
		#endif
	}
	
	public void startWidget () {
		#if UNITY_IPHONE 
		_StartWidget();
		#endif
	}
	
	public void stopWidget () {
		#if UNITY_IPHONE 
		_StopWidget();
		#endif
	}
	
	public void setUseWidgetVideoRecord (bool useVideoRecord) {
		#if UNITY_IPHONE 
		_SetUseWidgetVideoRecord(useVideoRecord);
		#endif
	}
	
	public void setShowWidgetWhenUnloadSDK (bool useWidget) {
		#if UNITY_IPHONE 
		_SetShowWidgetWhenUnloadSDK(useWidget);		
		#endif
	}

	public string getCafeLangCode () {
		string code = null;
		#if UNITY_IPHONE 
		code = _GetCafeLangCode();
		#endif
		return code;
	}

	public void setCafeLangCode (string cafeLangCode) {

	}
}