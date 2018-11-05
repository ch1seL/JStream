# JStreamAsyncNet

Easy way to serialize/desirialize objects to/from an async stream

## How to use

```powershell
Install-Package JStreamAsyncNet -Version 0.0.6
```

### Using with HttpResponseMessage

```c#
MyObject @object = await client.GetAsync(uriObject).ToObject<MyObject>();
MyObject[] array = await client.GetAsync(uriArray).ToArray<MyObject>();
```

or if you want to manage the response(here's implementation of methods used above)

```c#
HttpResponseMessage responseObject = await client.GetAsync(uriObject);
responseObject.EnsureSuccessStatusCode();
MyObject @object = await responseObject.Content.ReadAsStreamAsync().ToObject<MyObject>();

HttpResponseMessage responseArray = await client.GetAsync(uriArray);
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
