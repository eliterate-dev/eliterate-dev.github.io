### Pure CSS

Although I have some <a href="https://getbootstrap.com/">Bootstrap</a> experience and I think it's a fine framework, I decided against using it for this project.

CSS has become quite powerful over the decades, and far too many of us still don't utilize it to the fullest potential.

So to not use any framework as a crutch, I'm writing all the CSS for this project myself.

Since I have decided on the name "Eliterate", I chose to go with a book theme for the site.

...that makes sense or something, right?

<div class="sticker" style="rotate:9deg;margin-right:2rem;" role="presentation">📂</div>

#### Navigation

I went through a few iterations of navigation designs before I settled on the current one.

At first I wanted the Nav menu to be a book spine, but you don't really put "chapters" or similar on a spine - not to mention it didn't really fit into the mobile view.

Thinking of pages and content as "chapters" (although not exactly correct) led me to just style it as a book's chapter page.

How and why one would keep the book's chapter page constantly open while reading the book are questions I pointedly decided to ignore forever.

I went through a lot of images on google searching for a book content page I liked and eventually landed on the style of [chapter name.....page number] I use now.

A simple call to the string function `"ChapterName".PadRight(20, '.')` allows to keep the number of characters consistent between "chapter names" and dots.

However, just having a consistent number of characters does not mean every line is of consistent length. In most fonts, letters like "i" or "l" do not take up as much space as an "m", for example.

Thankfully, there are [monospace fonts](https://en.wikipedia.org/wiki/List_of_monospaced_typefaces), which, as their name suggests, exist exactly to fix this problem. So I applied one of those to the nav links and now all my lines are of equal width.

#### Posts (Pages)

<div class="sticker" style="rotate:-8deg;" role="presentation">📝</div>

In keeping with the book theme, every blog post is going to be its own "page" of the book.

Apart from the small styling on the borders there isn't much complicated about pages.

Like all textures on this website, the "notebook" texture comes from [Transparent Textures](https://www.transparenttextures.com/), which is a great resource for people who don't have the skills to make textures themselves (like me).

A service injected through [dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview) gets the .md file containing the post data, after which I use [Markdig](https://github.com/xoofx/markdig), a common C# Markdown library to convert the markdown into HTML code.

#### Pictures

I'm a millenial and basic af, so I like polaroids.

They also fit the scrapbook / notebook look of the project, so of course I put in some effort into styling my pictures like that.

It's pretty simple pure CSS, just some padding and some borders, but I think it looks good.

I'm using a different font on the polaroids, to give them a bit more of a handwritten feel - though to be honest it's way more legible than my handwriting would be.

#### Tags

At first I simply styled them as stickers (like they still exist on the "cards" elements).

They did not have any functionality yet at that point, and I thought I'd use them more as a gag (like the "Why not?" tag at the top of this page).

<div class="sticker" style="rotate:14deg;" role="presentation">📎</div>

I quickly decided however, that they would make for a good way to filter posts a bit. Not that there were any posts to filter yet, but I do often suffer from premature optimization.

So for content pages I went for the little sticky-notes you put in a book to remember where important stuff is. I liked the look of that.

A small struggle was their colors. I knew I wanted them pastel, like sticky notes usually are.

Assigning them a random color is easy, however I also wanted to keep the color consistent for each tag. That way, no matter if it's a sticky note tag or a sticker tag, they are easily recognizable by color.

The solution was calculating the color from the tag name:

    var hue = tag.Sum(c => c) % 360

The `.Sum()` method used on a string treats the string as a list of `char` and as `char` implicitly converts to `int` types in C#, it can be summed.

This sum, mod 360, gives me a consistent hue on the color circle. Full saturation and a high "lightness" value ensure it's a nice pastel.

    style="background-color: hsl(@hue, 100% 80%)"

It was a tad tedious to have to place the tags at the bottom of the post (you can see that by using inspect on this page) and then fix them to the top with `position:absolute;`, but I felt like prioritzing logical dom and tab order over small inconvinences for myself.

#### Cards

To make it possible to have multiple posts on one webpage I couldn't go with the full "page" layout described above, which I used for posts.

Should it be a chapter page? It would make sense, but I already used that for the navigation.

Besides, a post selection should have more info than just the name of the post. Maybe a short description? Tags?

No, a chapter selection would be too limited.

Libraries use cards and the [Dewey Decimal System](https://en.wikipedia.org/wiki/Dewey_Decimal_Classification) to quickly find books anywhere in the shelves.

Taking that for inspiration I decided for a sort of "card" look.

I'm technically showing the location of "pages" not "books" on them, but let's not sweat the details. It'll look cool and that's all that matters.

After another google image binge for creative stimulation (and halfway into an attempt of writing my own Dewey Decimal categorizer), I decided on a simple flashcard design instead.

The result is what you see on the [posts page](/posts).

They're simple and look nice when decorated with stickers.

The same injected service as for posts pulls their information from a simple .json file.

#### Stickers

I like stickers. You should see my laptop or my travelling suitcase!

So I wanted stickers on my digital book and my posts.

The "tag stickers" on the cards kinda naturally evolved out of my first idea for tags - simple "word boxes" with a white outline to give it that sticker look.

Taking that thought to the next level, I first tried to implement some pngs with white outlines. It worked fine, but putting dozens of pngs on every page grated on my optimisation sensibilities, so I searched for an alternative.

The concept of using emojis as stickers is blatantly stolen from the very creative and inspiring <a href="https://eev.ee/">Evelyn Woods</a>, who has mastered CSS to an astonishing level. I mean, check out those ripped paper and punch-hole masks...

I wrote my own implementation of them though. I got manners and shit.

It's essentially just few text-shadows and filters. I could have probably done with just one of the two, but I felt I got the most convincing effect by using both.

I grab my emojis from <a href="https://symbl.cc/">Symbl</a> - my go to resource for Unicode, though basically any unicode character list will do.

#### The idea board

The spark for the ["plans"](/plans) page came partially from real world post boards in my area, and partially again from [Evelyn Woods](https://eev.ee/), who's whole home page is basically that concept. Though again, implementation is entirely my own.

Brick, cork and paper textures are once again from [Transparent Textures](https://www.transparenttextures.com/), wheras the pins are just a repurposed form of the "emojis as stickers" concept.

### Any questions? Anything unclear?

The entire code is open source and viewable [here](https://github.com/eliterate-dev/eliterate-dev.github.io).

Feel free to fork or copy anything you want. 

If you find an error (not unlikely) or simply want to shoot me a question, send me an email @ [contact@eliterate.blog](mailto:contact@eliterate.blog)!

Can't promise I'll reply right away, but I'll get to it eventually.

Let's make the web weird again.