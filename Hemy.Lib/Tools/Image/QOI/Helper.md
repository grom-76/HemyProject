
### Encoding

Prefere the encoding stream to the byte array encoder for maximal performance

```csharp
int width = 1920;
int height = 1080;
var channels = Channels.RgbWithAlpha;

byte[] data = GetRawPixels();
byte[] qoiData = QoiEncoder.Encode(new QoiImage(data, width, height, channels));
```

### Decoding

Prefere the byte array decoder to the decoding stream for maximal performance, if you have the memory
```csharp
var qoiImage = QoiDecoder.Decode(qoiData);
Console.WriteLine($"Width: {qoiImage.Width}");
Console.WriteLine($"Height: {qoiImage.Height}");
Console.WriteLine($"Channels: {qoiImage.Channels}");
Console.WriteLine($"Color space: {qoiImage.ColorSpace}");
Console.WriteLine($"Data length: {qoiImage.Pixels.Length}");


```
