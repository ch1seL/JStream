# JStreamAsyncNet

Easy way to serialize and desirialize objects from/to a async stream

## How to use

```powershell
Install-Package JStreamAsyncNet -Version 0.0.4
```

### Using with HttpResponseMessage

```c#
MyObject @object = await HttpClient.GetAsync(uri).ToObject<MyObject>();
MyObject array = await HttpClient.GetAsync(uri).ToArray<MyObject>();
```

or if you want to have control with the response(here's implementation of methods used above)

```c#
HttpResponseMessage responseObject = await client.GetAsync(url);
responseObject.EnsureSuccessStatusCode();
MyObject @object = await responseObject.Content.ReadAsStreamAsync().ToObject<MyObject>();

HttpResponseMessage responseArray = await client.GetAsync(url);
responseArray.EnsureSuccessStatusCode();
MyObject[] array = await responseArray.Content.ReadAsStreamAsync().ToArray<MyObject>();
```

### Using with FileStream

```c#
MyObject @object = await Task.Run(() => (Stream)File.OpenRead(filePath)).ToObject<MyObject>();
//some act for @object
await Task.Run(() => (Stream)File.OpenWrite(filePath)).FromObject(@object);

MyObject[] array = await Task.Run(() => (Stream)File.OpenRead(filePath)).ToArray<MyObject>();
//some act for array
await Task.Run(() => (Stream)File.OpenWrite(filePath)).FromArray(array);
```
