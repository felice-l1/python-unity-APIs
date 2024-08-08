////using System.Collections;
////using System.Collections.Generic;
////using System.Net;
////using System.Net.Sockets;
////using System.Text;
////using UnityEngine;
////using System.Threading;
////using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;
////using UnityEngine.UI;
////using static UnityEngine.GraphicsBuffer;
////using System;
////using System.Data.SqlTypes;

////public class receive : MonoBehaviour
////{
////    Thread mThread;
////    public string connectionIP = "127.0.0.1";
////    public int connectionPort = 5005;
////    public Image image;

////    IPAddress localAdd;
////    TcpListener listener;
////    TcpClient client;
////    Texture2D tex;

////    byte[] imageByte;

////    bool running;

////    List<byte[]> allBytes;

////    private void Start()
////    {
////        image = GetComponent<Image>();
////        tex = new Texture2D(10, 10);
////        allBytes = new List<byte[]>();
////        ThreadStart ts = new ThreadStart(GetInfo);
////        mThread = new Thread(ts);
////        mThread.Start();
////        Debug.Log("start");
////    }

////    void GetInfo()
////    {
////        //Debug.Log("getInfo");
////        localAdd = IPAddress.Parse(connectionIP);
////        listener = new TcpListener(localAdd, connectionPort);
////        Debug.Log(localAdd.ToString());
////        listener.Start();

////        client = listener.AcceptTcpClient();

////        running = true;
////        while (running)
////        {
////            SendAndReceiveData();
////        }
////        listener.Stop();
////    }

////    void SendAndReceiveData()
////    {

////        NetworkStream nwStream = client.GetStream();
////        byte[] buffer = new byte[client.ReceiveBufferSize];

////        //---receiving Data from the Host----
////        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
////        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string

////        if (dataReceived != null)
////        {
////            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
////            allBytes.Add(buffer);
////            //---Using received data---


////            //bool loaded = ImageConversion.LoadImage(tex, buffer);
////            //Debug.Log(loaded);
////            print(allBytes.Count);

////            //---Sending Data to Host----
////            //byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Converting string to byte data
////            //nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Sending the data in Bytes to Python
////        }
////    }

////    //public Sprite getSprite(byte[] buffer, Texture2D tex)
////    //{
////    //    tex.LoadImage(buffer);
////    //    Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
////    //    return sprite;
////    //}

////    private void Update()
////    {
////        print("starting");
////        for (int i = 0; i < allBytes.Count; i++)
////        {
////            tex.LoadImage(allBytes[i]);
////            GetComponent<RawImage>().texture = tex;
////        }
////        //Sprite newSprite = getSprite(imageByte, tex);
////        //image.sprite = newSprite;
////    }

////    //private void Update()
////    //{
////    //    tex.loadimage(
////    //    var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

////    //    GetComponent<Renderer>().material.mainTexture = tex; //assigning receivedPos in SendAndReceiveData()
////    //}
////}


/////*
////public static string GetLocalIPAddress()
////{
////    var host = Dns.GetHostEntry(Dns.GetHostName());
////    foreach (var ip in host.AddressList)
////    {
////        if (ip.AddressFamily == AddressFamily.InterNetwork)
////        {
////            return ip.ToString();
////        }
////    }
////    throw new System.Exception("No network adapters with an IPv4 address in the system!");
////}
////*/




//using System;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using Google.Protobuf.WellKnownTypes;
//using System.Security.Cryptography;
//using System.Net.Http;

//public class ServerScript : MonoBehaviour
//{
//    TcpListener server = null;

//    //NetworkStream s;
//    TcpClient client = null;
//    NetworkStream stream = null;
//    Thread thread;
//    bool done;
//    List<byte[]> bytes;
//    Texture2D tex;
//    bool one;
//    private void Start()
//    {
//        tex = new Texture2D(1280, 640);
//        //tex = (Texture2D)GetComponent<RawImage>().texture; 
//        bytes = new List<byte[]>();
//        done = false;
//        thread = new Thread(new ThreadStart(SetupServer));
//        thread.Start();
//        one = true;
//    }

//    //private Texture2D GetTex()
//    //{
//    //    return tex;
//    //}

//    private void Update()
//    {
//        if (done)
//        {
//            //if (one)
//            //{
//            //    //print(Encoding.Default.GetString(bytes[0]));
//            //    one = false;
//            //}
//            for (int i = 0; i < bytes.Count; i++)
//            {
//                tex.LoadImage(bytes[i]);
//                //print(BitConverter.ToString(bytes[i]));
//                //Debug.Log(yes);
//                //GameObject playerObject = GameObject.FindWithTag("Player");
//                //if (playerObject == null)
//                //{
//                //    Debug.Log("FindWithTag returned null for Player tag");
//                //}
//                //if (playerObject.TryGetComponent<RawImage>(out RawImage component));
//                //{
//                //}
//                //if (!playerObject.TryGetComponent<RawImage>(out RawImage component1)) ;
//                //{
//                //    Debug.Log("playerObject.GetComponent returned null");
//                //}
//                GetComponent<RawImage>().texture = tex;
//            }


//            //Debug.Log("????");
//        }

//    }

//    private void SetupServer()
//    {
//        try
//        {
//            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
//            server = new TcpListener(localAddr, 5005);
//            server.Start();

//            byte[] buffer = new byte[1024];
//            string data = null;

//            while (true)
//            {
//                Debug.Log("Waiting for connection...");
//                client = server.AcceptTcpClient();
//                Debug.Log("Connected!");

//                //data = null;
//                //stream = client.GetStream();
//                //var header = new byte[5];
//                //s.Read(header, 0, header.Length);
//                //var size = Int32.Parse(Encoding.Default.GetString(header));
//                //var datad = new byte[size];
//                //s.Read(datad, 0, size);

//                int i;

//                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
//                {
//                    data = Encoding.UTF8.GetString(buffer, 0, i);
//                    Debug.Log("Received: " + data);
//                    Debug.Log(bytes.Count);
//                    bytes.Add(buffer);

//                    //string response = "Server response: " + data.ToString();
//                    //SendMessageToClient(message: response);
//                }
//                done = true;
//                client.Close();
//                break;
//            }
//        }
//        catch (SocketException e)
//        {
//            //done = true;
//            Debug.Log("SocketException: " + e);
//        }
//        finally
//        {

//            server.Stop();
//            done = true;
//        }
//    }

//    private void OnApplicationQuit()
//    {
//        stream.Close();
//        client.Close();
//        server.Stop();
//        thread.Abort();
//    }

//    //public void SendMessageToClient(string message)
//    //{
//    //    byte[] msg = Encoding.UTF8.GetBytes(message);
//    //    stream.Write(msg, 0, msg.Length);
//    //    Debug.Log("Sent: " + message);
//    //}
//}




//using System;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;
////using UnityEngine.ImageConversionModule;

//public class ServerScript : MonoBehaviour
//{
//    TcpListener server = null;
//    TcpClient client = null;
//    NetworkStream stream = null;
//    Thread thread;
//    bool done;
//    Texture2D tex;
//    List<byte[]> bytes;
//    int i;
//    private void Start()
//    {
//        tex = new Texture2D(1280, 640);
//        bytes = new List<byte[]>();
//        done = false;
//        i = 0;
//        thread = new Thread(new ThreadStart(SetupServer));
//        thread.Start();
//    }

//    private void Update()
//    {
//        if (done && i < bytes.Count)
//        {

//            bool yes = UnityEngine.ImageConversion.LoadImage(tex, bytes[i]);
//            GetComponent<RawImage>().texture = tex;
//            Debug.Log(yes + "UPDATE");
//            i++;

//        }
//    }

//    private void SetupServer()
//    {
//        try
//        {
//            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
//            server = new TcpListener(localAddr, 5005);
//            server.Start();

//            byte[] buffer = new byte[1024];

//            string data = null;

//            while (true)
//            {
//                Debug.Log("Waiting for connection...");
//                client = server.AcceptTcpClient();
//                Debug.Log("Connected!");

//                data = null;
//                stream = client.GetStream();

//                int i;

//                while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
//                {

//                    data = Encoding.UTF8.GetString(buffer, 0, i);
//                    Debug.Log("Received: " + data);
//                    bytes.Add(buffer);
//                    Debug.Log(bytes.Count);

//                    //string response = "Server response: " + data.ToString();
//                    //SendMessageToClient(message: response);
//                }
//                done = true;
//                client.Close();
//            }
//        }
//        catch (SocketException e)
//        {
//            Debug.Log("SocketException: " + e);
//        }
//        finally
//        {
//            server.Stop();
//        }
//    }

//    //private void OnApplicationQuit()
//    //{
//    //    stream.Close();
//    //    client.Close();
//    //    server.Stop();
//    //    thread.Abort();
//    //}

//    //public void SendMessageToClient(string message)
//    //{
//    //    byte[] msg = Encoding.UTF8.GetBytes(message);
//    //    stream.Write(msg, 0, msg.Length);
//    //    Debug.Log("Sent: " + message);
//    //}
//}



using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.UIElements;
using Google.Protobuf;
//using UnityEngine.ImageConversionModule;

public class ServerScript : MonoBehaviour
{
    TcpListener server = null;
    TcpClient client = null;
    NetworkStream stream = null;
    Thread thread;
    bool done;
    Texture2D tex;
    List<byte[]> bytes;
    int i;
    private void Start()
    {
        tex = new Texture2D(1280, 640);
        bytes = new List<byte[]>();
        done = false;
        i = 0;

        //string[] files = System.IO.Directory.GetFiles("C://Users//Arise_student//Downloads//cameraToPort//vid1.mp4");
        //Debug.Log(files.Length);


        thread = new Thread(new ThreadStart(SetupServer));
        thread.Start();
    }

    private void Update()
    {
        if (done && i < bytes.Count)
        {
            byte[] currByte = bytes[i];
            bool huh = tex.LoadImage(currByte);
            Debug.Log(huh);
            //byte[] bytes = tex.EncodeToJPG(); // i dont think this works, it repeats connecting and disconnecting
            //bool yes = tex.EncodeToPNG();
            // bool yes = UnityEngine.ImageConversion.LoadImage(tex, bytes[i]);
            GetComponent<RawImage>().texture = tex;
            Debug.Log(bytes + "update");
            i++;

        }
    }

    private void SetupServer()
    {
        try
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, 5005);
            server.Start();

            byte[] buffer = new byte[2457600];

            while (true)
            {
                Debug.Log("Waiting for connection...");
                client = server.AcceptTcpClient();
                Debug.Log("Connected!");

                stream = client.GetStream();

                int i;

                while ((i = stream.Read(buffer, 0, 2457600)) != 0)
                {
                    string buffer1 = BitConverter.ToString(buffer);
                    string[] hexValuesSplit = buffer1.Split('-');

                    byte[] byteArray = new byte[2457600];

                    for (int j = 0; j < hexValuesSplit.Length; j += 4)
                    {
                        string hex = hexValuesSplit[j];
                        // Convert the number expressed in base-16 to an integer.
                        int value = Convert.ToInt32(hex, 16);
                        byte[] byteValue = BitConverter.GetBytes(value);
                        byteArray[j] = byteValue[0];
                        byteArray[j+1] = byteValue[1];
                        byteArray[j+2] = byteValue[2];
                        byteArray[j+3] = byteValue[3];
                        //Debug.Log("HAHAHAH" + (BitConverter.GetBytes(value)).Length);

                    }


                    //data = Encoding.UTF8.GetString(buffer, 0, i);
                    //Debug.Log("Received: " + data);
                    bytes.Add(byteArray);
                    Debug.Log(bytes.Count);

                    //string response = "Server response: " + data.ToString();
                    //SendMessageToClient(message: response);
                }
                done = true;
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }
        finally
        {
            done = true;
            server.Stop();
        }
    }

  

    //private void OnApplicationQuit()
    //{
    //    stream.Close();
    //    client.Close();
    //    server.Stop();
    //    thread.Abort();
    //}

    //public void SendMessageToClient(string message)
    //{
    //    byte[] msg = Encoding.UTF8.GetBytes(message);
    //    stream.Write(msg, 0, msg.Length);
    //    Debug.Log("Sent: " + message);
    //}
}
