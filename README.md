# JStreamAsyncNet

Easy way to serialize/deserialize objects to/from an async stream

**Attention**: The stream will be disposed

## How to use

```powershell
Install-Package JStreamAsyncNet -Version 4.7.0
```

### Using with HttpResponseMessage

```c#
MyObject @object = await client.GetAsync(uriObject).ToObjectAsync<MyObject>();
MyObject[] array = await client.GetAsync(uriArray).ToArrayAsync<MyObject>();
```

or if you want to manage the response(here's implementation of methods used above)

```c#
HttpResponseMessage responseObject = await client.GetAsync(uriObject);
responseObject.EnsureSuccessStatusCode();
MyObject @object = await responseObject.Content.ReadAsStreamAsync().ToObjectAsync<MyObject>();

HttpResponseMessage responseArray = await client.GetAsync(uriArray);
responseArray.EnsureSuccessStatusCode();
MyObject[] array = await responseArray.Content.ReadAsStreamAsync().ToArrayAsync<MyObject>();
```

### Using with FileStream and Stream

```c#
MyObject @object = await File.OpenRead(filePath).ToObjectAsync<MyObject>();
//some act for @object
await File.OpenWrite(filePath).WriteFromObjectAsync(@object);

MyObject[] array = await File.OpenRead(filePath).ToArrayAsync<MyObject>();
//some act for array
await File.OpenWrite(filePath).WriteFromArrayAsync(array);
```
