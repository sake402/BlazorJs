OK! Blazor is cool🔥🔥🔥.

Ah well, until you host it and your website visitors have a poor bandwidth.😠😠😠

Blazor typically has two hosting model, each with its pros and cons.

## Server Hosting
Here your app visitor connect to your app over signalR socket while the app and the client sends events and UI updates back and forth.

It is great, fast, until you have som poor bandwidth users. They'd keep getting disconnected every now and then and UI responsiveness is poor. Even when you want to show a loading indicator, this wont happen until the server can send that UI update to the client.
Also doesnt scale too well for a site with hundreds of thousands of visitors, as each visitor is using the server resource in connections and memory.

## Webassemby Hosting
Here the whole app is downloaded into the client/browser. Performance is good when loaded, but statup time is poor.

The first time the visitor visit, they'd have to downloas 10s of MB of wasm files into the browser, which for a relatively large website, is very slow.
On subsequent visit, the browser uses the cached files, but startup is still very poor because the dotnet runtime has to load and initialize before user code can even run. 
And the webassembly is mostly interpreted in the browser, making it much slower than javascript itself.
Of course, you also have the option of AOT, but that is way worse as the binary size is just too large for you to want to use it in production.

# Enter BlazorJS
But what it we can compile the blazor down to javascript?

BlazorJs provided a light weight blazor runtime
Provides a generator than transpile razor files into C# code.
Then uses the H3 transpiler to compile it all down to javascript.
