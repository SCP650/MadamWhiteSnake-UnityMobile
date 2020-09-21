using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService 
{   //get weather data
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Pittsburgh,us&mode=xml&APPID=<your api key>";
    //get image
    private const string webImage = "http://cliparts.co/cliparts/pTo/54E/pTo54Eenc.jpg";

    public IEnumerator DownloadImage(System.Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage);
        yield return request.Send();
        callback(DownloadHandlerTexture.GetContent(request));
    }

    private IEnumerator CallAPI(string url, System.Action<string> callback)
    {   //what does this using syntax mean?
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {   //what is .Send()??
            yield return request.Send();

            if (request.isNetworkError)
            {   //There is a problem with internet connection
                Debug.LogError("network problem" + request.error);
            } else if(request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {   //There is problem with API's respond.
                Debug.LogError("response error" + request.error);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }

    }
    public IEnumerator GetWeatherXML(System.Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }
}
