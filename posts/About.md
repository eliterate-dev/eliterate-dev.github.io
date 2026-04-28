### Welcome!

I made this.

#### Why have I made this?

Have you ever wanted to do something but you just can't find a good existing tool to do it with?

I'm sure every software dev who loves what they do know the feeling.

Well, I wanted to start a blog, but I wanted to host it in GitHub Pages, because that's just kinda easy (and free) and I'm not the biggest star at setting up servers and networks and all that jazz.

But I also wanted to write it in C# / .Net, because it wasn't a big enough project to warrant wrangling a language I rarely use into getting it how I want it.

So I wrote an overly complicated Blazor / WASM app to write a blog to.

<div class="sticker" style="rotate:-12deg;margin-right:4rem;" role="presentation">🛠</div>

As one does.

#### Balancing ease of use and ease of building

Although I'm mainly a Backend dev, I didn't feel like doing my usual spiel of building an entire API just to fetch some .md files, 
since this project was supposed to be quick and dirty. Basically a static page, but with just enough automation to simplify general operations.

Technically this could all be done with JavaScript pretty easily, but I don't enjoy writing JavaScript code all that much. No shade to anyone using it, I just think the language is a bit of a mess.

So I turned to a relative newcommer in Webdev space: WASM (**W**eb **AS**se**M**bly (No I don't know why they abbreviated it this way)).

The .Net framework has the capability to compile my usual C# code directly into WASM, meaning I can just write my code normally - interfaces, services and all, run it through a build and bam, compiled WASM code.

Using to WASM like that almost entierly eliminates the need for JavaScript (apart from maybe a service worker) - to be clear, you don't have to replace any JS. You can still use it anywhere, but *anything done in WASM* is something *I don't need to do in JS*, which is perfect for me.

Combined with [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), the current modern .Net framework for frontend stuff, I can comfortably write my code in pretty much just C# and pure HTML / CSS.

As posts are static Markdown files, they're easy to change and reload - however the small downside is that the keeping of metadata (such as the title and tags) is entirely manual. I'm fine with that, but if that's too much hassle for you, this solution won't work.
