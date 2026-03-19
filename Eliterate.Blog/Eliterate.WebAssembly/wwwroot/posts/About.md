### Welcome!

Have you ever wanted to do something but you just can't find a good existing tool to do it with?

I'm sure every software dev who loves what they do know the feeling.

Well, I wanted to start a blog, but I wanted to host it in GitHub Pages, because that's just kinda easy (and free).

But I also wanted to write it in C# / .Net, because it wasn't a big enough project to warrant wrangling a language I rarely use into getting it how I want it.

So I wrote an overly complicated Blazor / WASM app to write a blog to.


<div class="sticker" style="rotate:-12deg;margin-right:4rem;">🛠</div>

As one does.

#### Balancing ease of use and ease of building

Although I'm mainly a Backend dev, I didn't feel like doing my usual spiel of building an entire API just to fetch some .md files, 
since this project was supposed to be quick and dirty. Basically a static page, but with just enough automation to simplify general operations.

Technically this could all be done with JavaScript pretty easily, but I don't enjoy writing JavaScript code all that much. No shade to anyone using it, I just think the language is a bit of a mess.

So I turned to a relative newcommer in C# space: WASM (**W**eb **AS**se**M**bly (No I don't know why they abbreviated it this way)).

Compiling to WASM almost entierly eliminates the need for JavaScript (apart from maybe a service worker).

Combined with Blazor, the current .Net framework for frontend stuff, I can comfortably write my code in C# and pure HTML / CSS.

As posts are static files, they're easy to change and reload - however the small downside is that the keeping of metadata (such as "Last Edited Date") is entirely manual. I'm fine with that.

#### Styling & Design

Although I have some <a href="https://getbootstrap.com/" tabindex="2">Bootstrap</a> experience, I decided against using it for this project.

CSS has become quite powerful over the decades, and far too many of us still don't utilize it to the fullest extent.

So to not use any framework as a crutch, I'm writing all the CSS for this project myself.

Since I have decided on the name "Eliterate", I chose to go with a book theme for the site. 

<div class="sticker" style="rotate:9deg;margin-right:3rem;">📓</div>

##### Navigation

I went through a few itterations of designs before I settled on the current one.

At first I wanted the Nav menu to be a book spine, but you don't really put "chapters" or similar on a spine - not to mention it didn't really fit into the mobile view.

Thinking of pages and content as "chapters" (although not exactly correct) led me to just style it as a book's chapter page.

How and why one would keep the book's chapter page constantly open while reading the book are questions I pointedly decided to ignore forever.

I went through a lot of images on google searching for a book content page I liked and eventually landed on the style of "chapter name.....page" I use now.

A simple call to the function `"Introduction".PadRight(20, '.')` allows to keep the number of characters consistent between "chapter names" and dots.

However to make sure it really looks good, I also had to use a monospace font, otherwise the width of each nav element would be all over the place.

##### Posts (Pages)

<div class="sticker" style="rotate:-8deg;">📝</div>

In keeping with the book theme, every blog post is going to be its own "page" of the book.

Apart from the small styling on the borders there isn't much complicated about pages.

A service I've built gets the .md file containing the post data, after which I use <a href="https://github.com/xoofx/markdig" tabindex="2">Markdig</a>, a common C# Markdown library to convert the markdown into HTML code.

##### Tags

At first I simply styled them as stickers (like they still exist on the "cards" elements).

They did not have any functionality yet at that point, and I thought I'd use them more as a gag (like the "Why not?" tag at the top of this page).

<div class="sticker" style="rotate:14deg;">📎</div>

I quickly decided however, that they would make for a good way to filter posts a bit. Not that there were any posts to filter yet, but I do suffer from premature optimization.

So for content pages I went for the little sticky-notes you put in a book to remember where important stuff is. I liked the look of that.

A small struggle was their colors. I knew I wanted them pastel, like the stick notes usually are.

Assigning them a random color is easy, however I also wanted to keep the color consistent for each tag.

The solution was calculating the color from the tag name:

    var hue = tag.Sum(c => c) % 360

Would give me a consistent hue on the color circle. Full saturation and a high "lightness" value ensure it's a nice pastel.

    style="background-color: hsl(@hue, 100% 80%)"

##### Cards

To make it possible to have multiple posts on a webpage, I couldn't go with the full page layout I used for posts.

After another google image binge for inspiration and halfway into an attempt of writing my own Dewey Decimal categorizer, I decided on a simple flashcard design instead.

They're simple, decorated with stickers.

##### Stickers

I like stickers. You should see my laptop or my travelling suitcase!

So I wanted stickers on my digital book and my posts.

The tag stickers on the cards kinda naturally evolved out of my first idea for tags.

The concept of using emojis as stickers is blatantly stolen from the very creative and inspiring <a href="https://eev.ee/">Evelyn Woods</a>, who has mastered CSS to an astonishing level. I mean, check out those ripped paper and punch-hole masks...

I wrote my own implementation of them though. I got manners and shit.

I grab my emojis from <a href="https://symbl.cc/">Symbl</a> - my go to resource for Unicode.