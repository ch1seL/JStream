# JStreamAsyncNet
Easy way to serialize and desirialize objects from/to a stream

## How to use

### Using with HttpResponseMessage
```
HttpResponseMessage objectResponse = await client.GetObjectResponse(url);
MyObject @object = await objectResponse.Content.ReadAsStreamAsync().ToObject<MyObject>();

HttpResponseMessage arrayResponse = await client.GetArrayResponse(url);
MyObject[] array = await arrayResponse.Content.ReadAsStreamAsync().ToArray<MyObject>();
```

### Using with FileStream
```
MyObject @object = await Task.Run(() => (Stream)File.OpenRead(filePath)).ToObject<MyObject>();
...
await Task.Run(() => (Stream)File.OpenWrite(filePath)).FromObject(@object);

MyObject[] array = await Task.Run(() => (Stream)File.OpenRead(filePath)).ToArray<MyObject>();
...
await Task.Run(() => (Stream)File.OpenWrite(filePath)).FromArray(array);
```
