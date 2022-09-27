﻿using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TmWinForms.Standard
{
  public class TJConvert
  {
    public const string Empty = "";

    public static string StringSeparatorStandard { get; } = "|";

    public static char CharSeparatorStandard { get; } = '|';

    public static JsonSerializerSettings jsonSerializerSettings { get; } = null;

    static TJConvert()
    {
      StringSeparatorStandard = CharSeparatorStandard.ToString();
      if (StringSeparatorStandard != CharSeparatorStandard.ToString()) throw new Exception("Ошибка в данных класса TTConvert. StringSeparatorStandard должен быть равен CharSeparatorStandard");
      jsonSerializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
    }

    public static int BytesInMegabyte { get; } = 1048576;

    public static string DateTimeFormat { get; } = "yyyy-MM-dd HH:mm:ss";

    public static string HttpContentJson { get; } = "application/json";

    public static string Time { get => DateTime.Now.ToString(DateTimeFormat); }

    public static string ToString(DateTime dt) => dt.ToString(DateTimeFormat);

    public static string ToString(object InputObject)
    {
      if (InputObject != null) { return InputObject.ToString(); }
      else { return string.Empty; }
    }

    public static string StringYyyyMmDd(DateTime dt, string Separator = Empty)
    {
      return $"{(dt.Year)}{Separator}{(dt.Month).ToString("D2")}{Separator}{(dt.Day).ToString("D2")}";
    }

    public static int IntYyyyMmDd(DateTime dt)
    {
      return dt.Year * 10000 + dt.Month * 100 + dt.Day;
    }

    public static string TryConvertToString(object InputObject)
    {
      string result = string.Empty;
      if (InputObject != null)
        try { result = InputObject.ToString(); } catch { }
      return result;
    }

    public static int ToInt32(string value, int Default)
    {
      int f = Default;
      if (int.TryParse(value, out int x)) f = x;
      return f;
    }

    public static int ToInt32(object value, int Default)
    {
      int f = Default;
      if (int.TryParse(value == null ? Default.ToString() : value.ToString(), out int x)) f = x;
      return f;
    }

    public static long BytesToMegabytes(long bytesCount) => bytesCount / BytesInMegabyte;

    public static string ObjectToJson(object value) => JsonConvert.SerializeObject (value, Formatting.Indented, jsonSerializerSettings);

    //public static StringContent ObjectToJsonStringContent(object value) => new StringContent(ObjectToJson(value), Encoding.UTF8, HttpContentJson);

    //public static StringContent CreateStringContent(string json) => new StringContent(json, Encoding.UTF8, HttpContentJson);

    public static T JsonToObject<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    public static T ByteArrayFirstToJsonThenToObject<T>(byte[] array) => JsonToObject<T>(ByteArrayToString(array));

    public static byte[] ObjectToByteArray(object MyObject)
    {
      if (MyObject == null)
        return null;
      BinaryFormatter bf = new BinaryFormatter();
      using (MemoryStream ms = new MemoryStream())
      {
        bf.Serialize(ms, MyObject);
        return ms.ToArray();
      }
    }

    public static object ByteArrayToObject(byte[] array)
    {
      MemoryStream memStream = new MemoryStream();
      BinaryFormatter binForm = new BinaryFormatter();
      memStream.Write(array, 0, array.Length);
      memStream.Seek(0, SeekOrigin.Begin);
      object obj = binForm.Deserialize(memStream);
      return obj;
    }

    public static string ByteArrayToString(byte[] array) => System.Text.Encoding.UTF8.GetString(array, 0, array.Length);


    /*
    public static ByteArrayContent ObjectToByteArrayContent(object MyObject)
    {
      if (MyObject == null) return null;
      byte[] data = ObjectToByteArray(MyObject);
      ByteArrayContent byteContent = new ByteArrayContent(data);
      return byteContent;
    }

    public static async Task<string> ReadContentAsString(HttpResponseMessage message)
    {
      Stream receiveStream = await message.Content.ReadAsStreamAsync();
      StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
      return readStream.ReadToEnd();
    }
    */

    public static int ValueInRange(int Value, int RangeMin, int RangeMax) => Math.Max(RangeMin, Math.Min(RangeMax, Value));

    public static byte[] ZipStringToArray(string str)
    {
      var bytes = Encoding.UTF8.GetBytes(str);
      using (var msi = new MemoryStream(bytes))
      using (var mso = new MemoryStream())
      {
        using (var gs = new GZipStream(mso, CompressionMode.Compress)) { msi.CopyTo(gs); }
        return mso.ToArray();
      }
    }

    public static string UnzipArrayFromString(byte[] bytes)
    {
      using (var msi = new MemoryStream(bytes))
      using (var mso = new MemoryStream())
      {
        using (var gs = new GZipStream(msi, CompressionMode.Decompress)) { gs.CopyTo(mso); }
        return Encoding.UTF8.GetString(mso.ToArray());
      }
    }

    public static byte[] CompressArray(byte[] data)
    {
      using (var compressedStream = new MemoryStream())
      using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
      {
        zipStream.Write(data, 0, data.Length);
        zipStream.Close();
        return compressedStream.ToArray();
      }
    }

    public static byte[] DecompressArray(byte[] data)
    {
      using (var compressedStream = new MemoryStream(data))
      using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
      using (var resultStream = new MemoryStream())
      {
        zipStream.CopyTo(resultStream);
        return resultStream.ToArray();
      }
    }

    public static byte[] ObjectToCompressedByteArray(object MyObject) => CompressArray(ObjectToByteArray(MyObject));

    public static object CompressedByteArrayToObject(byte[] array) => ByteArrayToObject(DecompressArray(array));

    public static byte[] ObjectToByteArray(object MyObject, bool Compress)
    {
      if (Compress)
      {
        return ObjectToCompressedByteArray(MyObject);
      }
      else
      {
        return ObjectToByteArray(MyObject);
      }
    }

    public static object ByteArrayToObject(byte[] array, bool Decompress)
    {
      if (Decompress)
      {
        return CompressedByteArrayToObject(array);
      }
      else
      {
        return ByteArrayToObject(array);
      }
    }

    private static object DeserializeFromStream(Stream stream)
    {
      IFormatter formatter = new BinaryFormatter();
      stream.Seek(0, SeekOrigin.Begin);
      object o = formatter.Deserialize(stream);
      return o;
      //catch (Exception ex) { Console.WriteLine("DeserializeFromStream");Console.WriteLine(ex.Source); Console.WriteLine(ex.Message); Console.WriteLine(ex.StackTrace); return null; }
    }

    private static string StreamToJson(Stream stream)
    {
      StreamReader reader = new StreamReader(stream); string ResponseBody = reader.ReadToEnd(); reader.Close(); return ResponseBody;
    }
  }
}